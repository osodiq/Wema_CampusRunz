using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class Tokens: BaseEntity
    {
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string Token { get; set; }
        

    }
}
