using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class Order: BaseEntity
    {
        public Product Product { get; set; }
    }
}
