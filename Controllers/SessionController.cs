using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthApi.Data;
using AuthApi.Models;
using AuthApi.Helper;
using AuthApi.Entities;
using AuthApi.Data.Exceptions;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AuthApi.Services;

namespace AuthApi.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/session")]
    public class SessionController(ILogger<SessionController> logger, DirectoryDBContext directoryDBContext, PersonService personService, SessionService sessionService ) : ControllerBase
    {
        private readonly ILogger<SessionController> _logger = logger;
        private readonly DirectoryDBContext directoryDBContext = directoryDBContext;
        private readonly PersonService personService = personService;
        private readonly SessionService sessionService = sessionService;
        

        /// <summary>
        /// Authenticate the person and init a session
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///     {
        ///       Id: int,
        ///       Name: string,
        ///       SessionToken: string
        ///     }
        /// 
        /// </remarks>
        /// <param name="authenticateRequest"></param>
        /// <response code="200">Succsessfull stored the person</response>
        /// <response code="400">The request is not valid or are parameters missing</response>
        /// <response code="401">Credentials are not valid</response>
        /// <response code="409">Unhandle exception at created the session record</response>
        [HttpPost]
        [Route("auth")]
        public IActionResult AuthenticatePerson([FromBody] AuthenticateRequest authenticateRequest)
        {
            
            //  * Validate request
            if( !ModelState.IsValid){
                return BadRequest(ModelState);
            }

            // * Validate credentials
            var person = this.personService.AuthPerson( authenticateRequest.Email!, authenticateRequest.Password!);
            if( person == null){
                return Unauthorized(new {
                    Message = "Usuario y/o contraseña incorrectos"
                });
            }

            // * Create a session record
            try{
                // * Get the ipAddress and userAgent
                string ipAddress = Request.Headers.ContainsKey("X-Forwarded-For")
                ? Request.Headers["X-Forwarded-For"].ToString()
                : HttpContext.Connection.RemoteIpAddress!.ToString();
                string userAgent = Request.Headers["User-Agent"].ToString();

                // * Make the session
                var SessionToken = sessionService.StartPersonSession( person, ipAddress, userAgent);

                // * Set the cookie for the response
                Response.Cookies.Append("FGJTamSession", SessionToken, new CookieOptions
                {
                    Path = "/",
                    HttpOnly = true,
                    Secure = false,
                    SameSite = SameSiteMode.Strict
                });

                // * Return all data
                return Ok(new{
                    Id = person.Id,
                    Name = person.FullName,
                    SessionToken
                });

            }catch(Exception err){
                this._logger.LogError(err, "" );
                return Conflict(
                    new {
                        Title = "Error al generar la session",
                        Message = "Error no controlado al tratar de iniciar la sesión."
                    }
                );
            }
        }


        /// <summary>
        /// Attempting to retrive the person data by the session token, loaded first from the query parameter "t" or the cookie named "FGJTamSession"
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Succsessfull stored the person</response>
        /// <response code="400">The session cookie was not found</response>
        /// <response code="403">The session token is not valid or expired</response>
        /// <response code="409">Unhandle exception</response>
        [HttpGet]
        [Route("me")]
        public ActionResult<PersonResponse?> GetSessionPerson([FromQuery] string? t)
        {
            // * Retrieve the sessionToken by the query param or cookie value
            var sessionToken =  t ?? Request.Cookies["FGJTamSession"];
            if (sessionToken == null) {
                return BadRequest( new {
                    Message = "Sesion token no encontrado."
                });
            }

            // * Validate the token 
            string ipAddress = Request.Headers.ContainsKey("X-Forwarded-For")
                ? Request.Headers["X-Forwarded-For"].ToString()
                : HttpContext.Connection.RemoteIpAddress!.ToString();
            string userAgent = Request.Headers["User-Agent"].ToString();
            var session = sessionService.ValidateSession( sessionToken, ipAddress, userAgent, out string message );
            if( session == null){
                return StatusCode( 403, new { message });
            }

            // * Attempt to get the person data
            try{

                var person = sessionService.GetPersonSession(sessionToken) ?? throw new Exception("La respuesta es nula");
                return Ok( PersonResponse.FromEntity(person!) );

            }catch(SessionNotValid sbv){
                _logger.LogError(sbv, "Session token not valid");
                return StatusCode( 403, new { sbv.Message });
            }catch(Exception err){
                _logger.LogError(err, "Error no controlado al obtener los datos de la sesion");
                return Conflict( new {
                    Message = "Error no controlado al obtener los datos de la sesion"
                });
            } 
        }

        /// <summary>
        /// Get all the sessions data
        /// </summary>
        /// <response code="200">Get all the session</response>
        /// <response code="401">No authenticated</response>
        [HttpGet]
        [Route("")]
        public IActionResult GetAllSessions( int take = 10, int skip = 0)
        {
            // * Get data
            var data = this.directoryDBContext.Sessions
                .OrderByDescending( item => item.BegginAt)
                .Take(50)
                .Skip(0)
                .ToArray();

            // * Get the total sessions
            var total = directoryDBContext.Sessions.Count();
          
            // * Return the data
            return Ok( new {
                take,
                skip,
                total,
                data
            });
        }

    }
}