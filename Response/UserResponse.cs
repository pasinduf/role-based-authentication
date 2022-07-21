

using RoleBasedAuthentication.Authorization;

namespace RoleBasedAuthentication.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SystemRole SystemRole { get; set; }
        public virtual bool IsAdmin => SystemRole.Id == (int)ESystemRoles.Admin;
    }
}
