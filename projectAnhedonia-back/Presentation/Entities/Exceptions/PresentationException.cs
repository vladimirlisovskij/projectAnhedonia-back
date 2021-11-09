using System;

namespace projectAnhedonia_back.Presentation.Entities.Exceptions
{
    public abstract class PresentationException : Exception
    {
        protected PresentationException(string s) : base(s)
        {
        }
    }

    public class UnknownException : PresentationException
    {
        public UnknownException() : base("Presentation layer has no reflect for this error")
        {
        }

        public UnknownException(string message) : base(message)
        {
        }
    }

    public class RequireAuthorizationException : PresentationException
    {
        public RequireAuthorizationException(string message) : base(message)
        {
        }
    }
}