using System;
using System.Collections.Generic;
using VOMO.Context.Interfaces;

namespace VOMO.Context.Entities
{
    public class Tag : EntityBase, IHasAuditFields
    {
        #region Relationships

        public virtual ICollection<Post> Posts { get; set; }

        #endregion

        #region Metadata

        public string Name { get; set; }
        public string Stub { get; set; }

        #endregion
        
        #region Auditing

        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion
    }
}
