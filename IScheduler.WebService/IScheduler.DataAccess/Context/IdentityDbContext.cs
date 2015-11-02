using System.Data.Common;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IScheduler.DataAccess.Context
{
    public class IdentityDbContext <TUser, TRole>
        : IdentityDbContext<TUser, TRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
        where TUser : IdentityUser
        where TRole : IdentityRole
    {
        /// <summary>
        ///     Default constructor which uses the DefaultConnection
        /// </summary>
        public IdentityDbContext()
            : this("DefaultConnection")
        {
        }

        /// <summary>
        ///     Constructor which takes the connection string to use
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public IdentityDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        /// <summary>
        ///     Constructs a new context instance using the existing connection to connect to a database, and initializes it from
        ///     the given model.  The connection will not be disposed when the context is disposed if contextOwnsConnection is
        ///     false.
        /// </summary>
        /// <param name="existingConnection">An existing connection to use for the new context.</param>
        /// <param name="model">The model that will back this context.</param>
        /// <param name="contextOwnsConnection">
        ///     Constructs a new context instance using the existing connection to connect to a
        ///     database, and initializes it from the given model.  The connection will not be disposed when the context is
        ///     disposed if contextOwnsConnection is false.
        /// </param>
        public IdentityDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        /// <summary>
        ///     Constructs a new context instance using conventions to create the name of
        ///     the database to which a connection will be made, and initializes it from
        ///     the given model.  The by-convention name is the full name (namespace + class
        ///     name) of the derived context class.  See the class remarks for how this is
        ///     used to create a connection.
        /// </summary>
        /// <param name="model">The model that will back this context.</param>
        public IdentityDbContext(DbCompiledModel model)
            : base(model)
        {
        }

        /// <summary>
        ///     Constructs a new context instance using the existing connection to connect
        ///     to a database.  The connection will not be disposed when the context is disposed
        ///     if contextOwnsConnection is false.
        /// </summary>
        /// <param name="existingConnection">An existing connection to use for the new context.</param>
        /// <param name="contextOwnsConnection">If set to true the connection is disposed when the context is disposed, otherwise
        ///     the caller must dispose the connection.
        /// </param>
        public IdentityDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        /// <summary>
        ///     Constructs a new context instance using the given string as the name or connection
        ///     string for the database to which a connection will be made, and initializes
        ///     it from the given model.  See the class remarks for how this is used to create
        ///     a connection.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        /// <param name="model">The model that will back this context.</param>
        public IdentityDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }
    }
}