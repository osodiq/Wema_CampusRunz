using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class CustomerOrder: BaseEntity
    {
        public Product Product { get; set; }
        public string Detail { get; set; }
        public string DeliveryAddress { get; set; }
        public Payment Payment { get; set; }
        public OrderAggregate Aggregate { get; set; }
        public MediaOrder MediaOrder { get; set; }
    }
}
