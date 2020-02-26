using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class DeliveryMethod : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
