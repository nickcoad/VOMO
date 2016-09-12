using System;
using System.Collections.Generic;
using VOMO.Context.Interfaces;

namespace VOMO.Context.Entities
{
    public class Post : EntityBase, IHasAuditFields
    {
        #region Relationships

        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Metadata

        public string Title { get; set; }
        public string Content { get; set; }

        #endregion
        
        #region Auditing

        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion
    }
}
