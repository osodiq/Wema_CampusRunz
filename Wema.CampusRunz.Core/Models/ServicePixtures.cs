using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class ServicePictures : BaseEntity
    {
        public string ServiceId { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
