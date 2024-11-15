using System;

namespace AuthApi.Models.Responses.People {
    public class AuthPersonResponse {
        public Guid Id {get;set;}
        public string Name {get;set;} = default!;
        public string Email {get;set;} = default!;

    }
}