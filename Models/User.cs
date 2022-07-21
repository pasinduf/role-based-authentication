
using RoleBasedAuthentication.Authorization;

namespace RoleBasedAuthentication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public SystemRole SystemRole { get; set; }
        public virtual bool IsAdmin => SystemRole.Id == (int)ESystemRoles.Admin;
        public virtual bool IsUser => SystemRole.Id == (int)ESystemRoles.User;
    }
}
