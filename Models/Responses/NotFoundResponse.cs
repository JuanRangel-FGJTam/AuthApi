using System;

namespace AuthApi.Models.Responses {
    public class NotFoundResponse {
        public string? Title {get;set;}
        public string Message {get;set;} = default!;

        public NotFoundResponse(){
            this.Title = "";
            this.Message = "";
        }

        public NotFoundResponse(string title, string message){
            this.Title = title;
            this.Message = message;
        }

        public NotFoundResponse(string message){
            this.Message = message;
        }

    }
}