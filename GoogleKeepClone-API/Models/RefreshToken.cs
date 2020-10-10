using System;
using System.Collections.Generic;

namespace GoogleKeepClone_API.Models
{
    public partial class RefreshToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime? Expires { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
    }
}
