using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.DTOs.Request
{
    public class UserRegistrationRequest
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string confirmPassword { get; set; }
        public string phoneNo { get; set; }
        public string Category { get; set; }
        public string businessName { get; set; }
        public string businessDescription { get; set; }
        public string businessLogo { get; set; }


    }
}
