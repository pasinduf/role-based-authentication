

namespace RoleBasedAuthentication.Exceptions
{
    public class UserException : ApiException
    {
        public UserException(string reason) : base(reason) { }
        public UserException(string reason, string message) : base(reason, message) { }
    }

    public class UserErrors
    {
        public static string UserNotFound => nameof(UserNotFound);
    }
}
