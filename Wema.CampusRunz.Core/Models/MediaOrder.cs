using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class MediaOrder: BaseEntity
    {
        public string DocumentPath { get; set; }
        public string DeliveryAddress { get; set; }
        public string PrintingType { get; set; }
        public string ExtraDetail { get; set; }
        
    }
}
