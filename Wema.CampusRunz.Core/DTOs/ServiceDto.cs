using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wema.CampusRunz.Core.DTOs
{
    public class ServiceDto
    {
        [Required]
        public string BusinessName { get; set; }
        [Required]
        public int BusinessPhoneNumber { get; set; }
        public string BusinessDescription { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Address { get; set; }
        public string TwitterHandle { get; set; }
        public string InstagramHandle { get; set; }
        public List<string> UploadedImageList { get; set; }
    }
}
