using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class ForgetPasswordModel
    {
        [Required]
        public string UserName { get; set; }
    }
}
