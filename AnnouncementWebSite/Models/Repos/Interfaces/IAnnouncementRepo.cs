using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncementWebSite.Models.Entities;

namespace AnnouncementWebSite.Models.Repos.Interfaces
{
    public interface IAnnouncementRepo
    {
        Announcement GetById(int id);
        IEnumerable<Announcement> GetList();
        Announcement Add(Announcement announcement);
        void Edit(Announcement announcement);
        void Delete(int id);
    }
}
