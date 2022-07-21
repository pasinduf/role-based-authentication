

using System.Collections.Generic;

namespace RoleBasedAuthentication.Exceptions
{
    public static class ExceptionReasonConvertor
    {
        private static Dictionary<string, string> ParsedReasons { get; set; }
        static ExceptionReasonConvertor()
        {
            ParsedReasons = new Dictionary<string, string>
            {
                { "CouldNotInitiateAuth", "Couldn't initiate authentication" },
                { "PasswordResetRequired", "Password reset required" },
                { "TooManyRequests", "Too many requests" },
            };
        }

        public static string Convert(string reason)
        {
            if (ParsedReasons.ContainsKey(reason))
            {
                return ParsedReasons[reason];
            }

            return reason;
        }
    }

}
