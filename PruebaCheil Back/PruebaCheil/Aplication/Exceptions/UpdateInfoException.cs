using System;

namespace PruebaCheil.Aplication.Exceptions
{
    public class UpdateInfoException : Exception
    {
        public UpdateInfoException()
        {
        }

        public UpdateInfoException(string message) : base(message)
        {
        }

        public UpdateInfoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
