using System;
using System.Collections.Generic;
using System.Text;

namespace Digiturk.Core.Domain.Catalog
{
    public class ArticleComment : BaseEntity
    {
        public int ArticleId { get; set; }
        public string Content { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
    }
}
