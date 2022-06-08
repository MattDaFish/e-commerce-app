using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace JustSports.WebApi.Models
{
    public class ErrorResponse
    {
        public ErrorResponse(ModelStateDictionary modelState)
        {
            var errors = new List<Error>();

            foreach (var modelStateItem in modelState)
            {
                foreach (var errorItem in modelStateItem.Value.Errors)
                {
                    errors.Add(new Error(errorItem));
                }
            }

            Errors = errors;
        }

        public ErrorResponse(Exception ex)
        {
            Errors = new List<Error>() { new Error(ex) };
        }

        public ErrorResponse(string message)
        {
            Errors = new List<Error>() { new Error(message) };
        }

        public IEnumerable<Error> Errors { get; }
    }
}
