using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using VOMO.Common;
using VOMO.Common.Exceptions;
using VOMO.Context.Entities;
using VOMO.Context.Interfaces;
using VOMO.Context.Mappings;

namespace VOMO.Context
{
    public class VomoContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        public VomoContext()
            : base("VomoDb")
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AttachmentMap());
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new UserMap());
        }

        public static VomoContext Create()
        {
            return new VomoContext();
        }

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;

            foreach (var entry in (this as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {
                if (entry.IsRelationship)
                    continue;

                var audittedRecord = entry.Entity as IHasAuditFields;

                if (audittedRecord == null)
                    continue;

                audittedRecord.UpdatedAt = now;

                if (entry.State == EntityState.Added)
                    audittedRecord.CreatedAt = now;
            }

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ve)
            {
                var validationErrors = string.Join("; ",
                    ve.EntityValidationErrors.SelectMany(result => result.ValidationErrors)
                        .Select(error => error.ErrorMessage));

                throw new FriendlyException(Constants.ExceptionSeverity.Error,
                        "Entity Framework validation errors occurred while trying to save record. Check log for details.",
                        "Entity Framework validation errors occurred while trying to save record: " + validationErrors);
            }
        }

        public override Task<int> SaveChangesAsync()
        {
            var now = DateTime.UtcNow;

            foreach (var entry in (this as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {   
                if (entry.IsRelationship)
                    continue;

                var audittedRecord = entry.Entity as IHasAuditFields;

                if (audittedRecord == null)
                    continue;

                audittedRecord.UpdatedAt = now;

                if (entry.State == EntityState.Added)
                    audittedRecord.CreatedAt = now;
            }

            try
            {
                return base.SaveChangesAsync();
            }
            catch (DbEntityValidationException ve)
            {
                var validationErrors = string.Join("; ",
                    ve.EntityValidationErrors.SelectMany(result => result.ValidationErrors)
                        .Select(error => error.ErrorMessage));

                throw new FriendlyException(Constants.ExceptionSeverity.Error,
                        "Entity Framework validation errors occurred while trying to save record. Check log for details.",
                        "Entity Framework validation errors occurred while trying to save record: " + validationErrors);
            }
        }
    }
}
