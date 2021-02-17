using System;
using System.Runtime.Serialization;

namespace Skolplattformen
{
    internal class EtjanstException : Exception
    {
        public EtjanstException(string message) : base(message)
        {
        }

        public EtjanstException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}