using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class AppUser: IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Category { get; set; }
        public string Businessname { get; set; }
        public string BusinessDescription { get; set; }
        public string BusinessLogo { get; set; }

    }
}
