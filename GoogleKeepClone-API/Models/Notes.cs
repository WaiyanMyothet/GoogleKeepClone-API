using System;
using System.Collections.Generic;

namespace GoogleKeepClone_API.Models
{
    public partial class Notes
    {
        public Guid Id { get; set; }
        public string Labels { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
