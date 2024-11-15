using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Models
{
    public class PreregistrationRequest
    {
        public string Mail {get;set;} = null!;
        
        public string Password {get;set;} = null!;

        public string ConfirmPassword {get;set;} = null!;

        public string? Url {get;set;} = null;
    }
}