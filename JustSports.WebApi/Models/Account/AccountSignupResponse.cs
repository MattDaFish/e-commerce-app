using System;
using System.ComponentModel.DataAnnotations;

namespace JustSports.WebApi.Models
{
    public class AccountSignupResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
