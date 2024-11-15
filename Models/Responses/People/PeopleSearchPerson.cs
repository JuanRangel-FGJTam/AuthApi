using System;

namespace AuthApi.Models.Responses.People {
    public class PeopleSearchPerson {
        public Guid Id {get;set;}
        public string FullName {get;set;} = default!;
        public string Birthdate {get;set;} = default!;
        public string? Email {get;set;}
        public string Gender {get;set;} = default!;
        public string Curp {get;set;} = default!;

    }
}