using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOMO.Context.Entities;

namespace VOMO.Context.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            Property(x => x.GivenName).HasMaxLength(50).IsOptional();
            Property(x => x.Surname).HasMaxLength(50).IsOptional();
            Property(x => x.DisplayName).HasMaxLength(50).IsRequired();
        }
    }
}
