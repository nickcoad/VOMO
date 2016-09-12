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
    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            HasKey(a => a.Id);

            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.Stub).HasMaxLength(50).IsRequired();
            Property(x => x.CreatedAt).IsRequired();
            Property(x => x.UpdatedAt).IsRequired();
        }
    }
}
