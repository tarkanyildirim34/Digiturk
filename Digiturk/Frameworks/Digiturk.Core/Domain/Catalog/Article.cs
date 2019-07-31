using System;
using System.Collections.Generic;
using System.Text;

namespace Digiturk.Core.Domain.Catalog
{
    public class Article : BaseEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; } 
         
    }
}
