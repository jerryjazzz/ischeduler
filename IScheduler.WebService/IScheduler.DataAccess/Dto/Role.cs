using Microsoft.AspNet.Identity.EntityFramework;

namespace IScheduler.DataAccess.Dto
{
    public class Role : IdentityRole
    {
        public Role() { }

        public Role(string roleName) : base (roleName) { }

        public string Description { get; set; }
    }
}
