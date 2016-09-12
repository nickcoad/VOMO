using System;
using System.Collections.Generic;
using VOMO.Context.Interfaces;

namespace VOMO.Context.Entities
{
    public class Attachment : EntityBase, IHasAuditFields
    {
        #region Relationships

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        #endregion

        #region Metadata

        public string Title { get; set; }
        public Guid Guid { get; set; }
        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }

        #endregion

        #region Auditing

        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion
    }
}
