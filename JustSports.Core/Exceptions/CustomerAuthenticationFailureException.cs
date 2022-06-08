using System;

namespace JustSports.Core.Exceptions;

public class CustomerAuthenticationFailureException : Exception
{
    private const string defaultMessage = "Incorrect username or password.";

    public CustomerAuthenticationFailureException() : base(defaultMessage) { }

}
