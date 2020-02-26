using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class Payment: BaseEntity
    {
        public Product Product { get; set; }
        //User
        public decimal TotalAmount { get; set; }
        public string Method { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
