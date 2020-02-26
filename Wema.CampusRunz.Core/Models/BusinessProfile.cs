using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    [Table("BusinessProfiles")]
    public class BusinessProfile : BaseEntity
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string CategoryId { get; set; }
        public string LogoPath { get; set; }
    }
}
