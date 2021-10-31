namespace projectAnhedonia_back.Domain.Exceptions
{
    public abstract class DataBaseException : DomainException
    {
        protected DataBaseException(string s) : base(s)
        {
        }
    }

    public class InvalidEntityKeyException : DataBaseException
    {
        public InvalidEntityKeyException() : base("Invalid primary key")
        {
        }

        public InvalidEntityKeyException(string message) : base(message)
        {
        }
    }
}