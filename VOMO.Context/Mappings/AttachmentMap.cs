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
    public class AttachmentMap : EntityTypeConfiguration<Attachment>
    {
        public AttachmentMap()
        {
            HasKey(a => a.Id);
            
            Property(x => x.UserId).IsRequired();
            Property(x => x.Title).HasMaxLength(100).IsOptional();
            Property(x => x.Guid).IsRequired();
            Property(x => x.FileName).HasMaxLength(255).IsOptional();
            Property(x => x.MimeType).HasMaxLength(50).IsRequired();
            Property(x => x.CreatedAt).IsRequired();
            Property(x => x.UpdatedAt).IsRequired();

            HasMany(x => x.Posts)
                .WithMany(y => y.Attachments);
        }
    }
}
