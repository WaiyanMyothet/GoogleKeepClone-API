using System;
using System.Collections.Generic;

namespace GoogleKeepClone_API.Models
{
    public partial class Labels
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
