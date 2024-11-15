using System;

namespace AuthApi.Models
{
    public class AuthenticateRequest
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
    }
}