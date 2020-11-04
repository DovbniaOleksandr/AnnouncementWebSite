using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementWebSite.ViewModels.Announcements
{
    public class EditAnnouncementViewModel:AddAnnouncementViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
