using System;

namespace AuthApi.Models.Responses {
    public class ValidateRegisterResponse {
        public string PersonId {get;set;} = default!;
        public string FullName {get;set;} = default!;
        public string SessionToken {get;set;} = default!;

    }
}