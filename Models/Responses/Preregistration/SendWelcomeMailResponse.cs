using System;

namespace AuthApi.Models.Responses {
    public class SendWelcomeMailResponse {
        public string Email {get;set;} = default!;
        public string EmailResponse {get;set;} = default!;

    }
}