using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VOMO.Context.Interfaces;

namespace VOMO.Context.Entities
{
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>, IHasAuditFields
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string DisplayName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
