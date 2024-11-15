using System;

namespace AuthApi.Models.Responses {
    public class BadrequestResponse {
        public string Title {get;set;} = default!;
        public string Message {get;set;} = default!;

        public BadrequestResponse(){
            this.Title = "";
            this.Message = "";
        }

        public BadrequestResponse(string title, string message){
            this.Title = title;
            this.Message = message;
        }

        public BadrequestResponse(string title, Exception err){
            this.Title = title;
            this.Message = err.Message;
        }

    }
}