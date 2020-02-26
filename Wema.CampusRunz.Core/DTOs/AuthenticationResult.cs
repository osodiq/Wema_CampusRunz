using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.DTOs
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public string RstPassToken { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Category { get; set; }
        public string businessName { get; set; }
        public string businessLogo { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Error { get; set; }

    }
}
