using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleKeepClone_API.Repository
{
    public interface IDel<T>
    {
        Nullable<bool> IsDeleted { get; set; }
    }
}