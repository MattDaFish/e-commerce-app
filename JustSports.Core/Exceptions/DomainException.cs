using System;

namespace JustSports.Core.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }

        public DomainException(Exception ex) :
            base(ex.Message, ex)
        { }

        public DomainException(string message, Exception ex) :
            base(ex.Message, ex)
        { }
    }
}
