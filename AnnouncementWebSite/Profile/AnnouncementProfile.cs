using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncementWebSite.Models.Entities;
using AnnouncementWebSite.ViewModels.Announcements;

namespace AnnouncementWebSite.Profile
{
    public class AnnouncementProfile:AutoMapper.Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<Announcement, CardAnnouncementViewModel>()
                .ReverseMap();
            CreateMap<Announcement, DetailsAnnouncementViewModel>()
                .ReverseMap();
            CreateMap<AddAnnouncementViewModel, Announcement>()
                .ReverseMap();
            CreateMap<EditAnnouncementViewModel, Announcement>()
                .ReverseMap();
        }
    }
}
