using System;

namespace AuthApi.Models.Responses {
    public class PreRegisterUserResponse {
        public string Id {get;set;} = default!;
        public string Email {get;set;} = default!;

    }
}