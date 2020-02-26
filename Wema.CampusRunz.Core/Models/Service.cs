using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class Service : BaseEntity
    {
        public string BusinessName { get; set; }
        public int BusinessPhoneNumber { get; set; }
        public string BusinessDescription { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string TwitterHandle { get; set; }
        public string InstagramHandle { get; set; }


    }
}
