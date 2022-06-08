using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace JustSports.WebApi.Models
{
    /// <summary>
    /// This is modelled on best practices from Twitter and Facebook, for more info see https://nordicapis.com/best-practices-api-error-handling/
    /// </summary>
    public class Error
    {
        public Error(string message)
        {
            Type = "Unknown";
            Message = message;
        }

        public Error(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
        }

        public Error(ModelError modelError)
        {
            Type = "ValidationException";
            Message = modelError.ErrorMessage;
        }

        public string Type { get; set; }

        public string Message { get; set; }
    }
}
