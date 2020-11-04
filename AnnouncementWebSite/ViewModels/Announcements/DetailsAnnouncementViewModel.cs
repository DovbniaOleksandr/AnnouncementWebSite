using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementWebSite.ViewModels.Announcements
{
    public class DetailsAnnouncementViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CardAnnouncementViewModel> SimilarAnnouncements { get; set; }
    }
}
