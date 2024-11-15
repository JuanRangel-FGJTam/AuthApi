using System;

namespace AuthApi.Models
{
    public class ValidateRegisterRequest
    {

        public string? Rfc {get;set;}
        
        public string? Curp {get;set;}
        
        public string? Name {get;set;}
        
        public string? FirstName {get;set;}

        public string? LastName {get;set;}
        
        public DateTime? Birthdate {get;set;}

        public int? GenderId {get; set;}
        
        public int? MaritalStatusId {get;set;}
        
        public int? NationalityId {get;set;}
        
        public int? OccupationId {get;set;}

        public string? AppName {get;set;}
        
        public string? Token {get;set;}

    }
}