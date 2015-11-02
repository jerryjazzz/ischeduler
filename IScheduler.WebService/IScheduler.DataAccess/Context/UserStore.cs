using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IScheduler.DataAccess.Context
{
    public class UserStore<TUser, TRole> 
        : UserStore<TUser, TRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>,
        IUserStore<TUser>
        where TUser : IdentityUser
        where TRole : IdentityRole
    {
        /// <summary>
        ///     Default constuctor which uses a new instance of a default EntityyDbContext
        /// </summary>
        public UserStore()
            : this(new IdentityDbContext())
        {
            DisposeContext = true;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="context"></param>
        public UserStore(DbContext context)
            : base(context)
        {
        }
    }
}