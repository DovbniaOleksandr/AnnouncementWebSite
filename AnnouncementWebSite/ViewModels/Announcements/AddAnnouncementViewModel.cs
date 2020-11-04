using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementWebSite.ViewModels.Announcements
{
    public class AddAnnouncementViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Title { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 20)]
        public string ShortDescription { get; set; }
        [Required]
        [StringLength(5000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 30)]
        public string Description { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
