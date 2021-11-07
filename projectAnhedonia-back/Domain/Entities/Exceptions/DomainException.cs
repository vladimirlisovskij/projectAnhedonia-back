using System;

namespace projectAnhedonia_back.Domain.Entities.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string s) : base(s)
        {
        }
    }

    public class UnknownException : DomainException
    {
        public UnknownException() : base("Domain layer has no reflect for this error")
        {
        }

        public UnknownException(string message) : base(message)
        {
        }
    }
}