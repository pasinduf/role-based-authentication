
using System;

namespace RoleBasedAuthentication.Exceptions
{
    public class ApiException : Exception
    {
        public string Reason { get; }

        public ApiException(string reason) : base("")
        {
            Reason = reason;
        }

        public ApiException(string reason, string message) : base(message)
        {
            Reason = reason;
        }

        public override string ToString()
        {
            return String.IsNullOrEmpty(Message) ? ExceptionReasonConvertor.Convert(Reason) : Message;
        }
    }
}
