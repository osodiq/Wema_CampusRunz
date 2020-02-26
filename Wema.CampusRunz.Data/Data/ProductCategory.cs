using System;
using System.Collections.Generic;
using System.Text;
using Wema.CampusRunz.Core.Models;

namespace Wema.CampusRunz.Data.Data
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
