using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AuthApi.Models;
using AuthApi.Entities;
using AuthApi.Data;
using AuthApi.Services;
using AuthApi.Data.Exceptions;
using AuthApi.Models.Responses;
using AuthApi.Validators.Preregistration;

namespace AuthApi.Controllers
{

    /// <summary></summary>
    [Authorize]
    [ApiController]
    [Route("api/pre-registration")]
    public class PreregistrationController(DirectoryDBContext context, PreregisterService preregisterService, ILogger<PreregistrationController> logger, SessionService sessionService ) : ControllerBase
    {
        private readonly DirectoryDBContext dbContext = context;
        private readonly PreregisterService preregisterService = preregisterService;
        private readonly SessionService sessionService = sessionService;
        private readonly ILogger<PreregistrationController> logger = logger;

        /// <summary>
        /// Pre register the user and send a email to verify his information
        /// </summary>
        /// <response code="201">Succsessfull create the pre-register record</response>
        /// <response code="409">The request is not valid ore some error are present</response>
        /// <response code="422">The request params are not valid</response>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PreRegisterUserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ConflictResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(UnprocesableResponse), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> RegisterUser(PreregistrationRequest request)
        {

            // * Validate request
            var validator = new NewRegisterValidator();
            var validationResults = validator.Validate(request);
            if (!validationResults.IsValid) {
                return UnprocessableEntity( new UnprocesableResponse(validationResults.Errors));
            }

            // * Create the pre-register record
            try{
                var _preRegisterId = await this.preregisterService.CreatePreregister(request);
                return Created( "", new PreRegisterUserResponse {
                    Id = _preRegisterId!,
                    Email = request.Mail
                });
            }catch(SimpleValidationException ve){
                return UnprocessableEntity(
                    new UnprocesableResponse( ve.ValidationErrors.ToDictionary() )
                );
            }catch(Exception err){
                logger.LogError(err, "Error at trying to generate a new preregistration record; {message}", err.Message );
                return Conflict( new ConflictResponse {
                    Title = "Error no controlado al generar la solicitud.",
                    Message = err.Message
                });
            }
        }

        /// <summary>
        /// Retrive all the preregisters stored
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Preregistration>?> GetAllPreregisters()
        {
            return Ok( dbContext.Preregistrations.ToArray() );
        }

        /// <summary>
        /// Store the new person using the pre-register record for retriving the email and password
        /// </summary>
        /// <remarks>
        /// Sample request with the minal data required:
        /// 
        ///     POST api/people
        ///     {
        ///       "token": string,
        ///       "curp": "RAAE190394MTSNLL02",
        ///       "name": "Juan Salvador",
        ///       "firstName": "Rangel",
        ///       "lastName": "Almaguer",
        ///       "birthdate": "1993-12-17",
        ///       "appName" : string
        ///     }
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="201">Succsessfull stored the person</response>
        /// <response code="404">The preregister record was not found by matching the token passed by the request</response>
        /// <response code="422">Some request params are not valid</response>
        /// <response code="409">Internal error</response>
        [HttpPost("validate")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ValidateRegisterResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(UnprocesableResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ConflictResponse), StatusCodes.Status409Conflict)]
        public IActionResult ValidateRegister(ValidateRegisterRequest request){

            // * Validate the request
            var validationResults = new ValidateRegistrationValidator().Validate(request);
            if(!validationResults.IsValid){
                return UnprocessableEntity( new UnprocesableResponse(validationResults.Errors));
            }

            try {

                // * Validate token
                var preregister = this.preregisterService.GetPreregistrationByToken(request.Token!);
                if( preregister == null){
                    return NotFound( new NotFoundResponse {
                        Title = "El código de prerregistro no es válido.",
                        Message = $"No se encontró registro que corresponda al código '{request.Token!}'."
                    });
                }

                // * Store the person data
                Person newPerson = this.preregisterService.ValidateRegister( preregister.Id, request );

                // * Create a session
                string ipAddress = HttpContext.Connection.RemoteIpAddress!.ToString();
                string userAgent = Request.Headers["User-Agent"].ToString();
                var sessionToken = sessionService.StartPersonSession( newPerson, ipAddress, userAgent );

                // * Return the data
                return Created("", new ValidateRegisterResponse {
                    PersonId = newPerson.Id.ToString(),
                    FullName = newPerson.FullName,
                    SessionToken = sessionToken
                });

            }
            catch(ValidationException ve){
                var errorsData = (Dictionary<string, string>) ve.Value!;
                return UnprocessableEntity(
                    new UnprocesableResponse(errorsData)
                );
            }
            catch (Exception err) {
                logger.LogError(err, "Error at validate the registration code.");
                return Conflict( new ConflictResponse {
                    Title = "Error no controlado al validar el registro.",
                    Message = err.Message
                });
            }
        }


        /// <summary>
        /// Send a mail of welcoming if the email is stored in the db (for testing)
        /// </summary>
        /// <returns code="200">Mail sended to the server provider</returns>
        /// <returns code="404">Email not found</returns>
        /// <returns code="409">Error at attempting to send the mail to the server</returns>
        [Authorize]
        [HttpPost("send/mail/welcome/to/{email}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(SendWelcomeMailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResponse), StatusCodes.Status409Conflict)]
        public IActionResult SendWelcomeMail([FromRoute] string email)
        {
            // * attempt to find the person
            Person? person = dbContext.People.Where(item => item.Email == email).FirstOrDefault();
            if(person == null){
                return NotFound( new NotFoundResponse {
                    Title = "El correo no se encuentra registrado en el sistema.",
                    Message = $"No se encontró persona asociada con el correo '{email}', revisé e intenté de nuevo."
                });
            }

            // * send the email
            try {
                var sendEmailTask = preregisterService.SendWelcomeMail(person);
                sendEmailTask.Wait();

                // return the response
                return Ok( new SendWelcomeMailResponse {
                    Email = email,
                    EmailResponse = sendEmailTask.Result
                });

            }catch(Exception ex){
                logger.LogError(ex, "Error at send the welcome mail");
                return Conflict(
                    new ConflictResponse("Error al enviar el mensage", ex)
                );
            }
            
        }

    }
}