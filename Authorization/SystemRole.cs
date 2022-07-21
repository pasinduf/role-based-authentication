

namespace RoleBasedAuthentication.Authorization
{
    public class SystemRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum ESystemRoles
    {
        Admin = 1,
        User = 2
    }
}
