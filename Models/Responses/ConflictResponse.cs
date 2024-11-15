using System;

namespace AuthApi.Models.Responses {
    public class ConflictResponse {
        public string Title {get;set;} = default!;
        public string Message {get;set;} = default!;

        public ConflictResponse(){
            this.Title = "";
            this.Message = "";
        }

        public ConflictResponse(string title, string message){
            this.Title = title;
            this.Message = message;
        }

        public ConflictResponse(string title, Exception err){
            this.Title = title;
            this.Message = err.Message;
        }

    }
}