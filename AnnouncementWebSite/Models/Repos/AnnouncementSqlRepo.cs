using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncementWebSite.Models.Entities;
using AnnouncementWebSite.Models.Repos.Interfaces;

namespace AnnouncementWebSite.Models.Repos
{
    public class AnnouncementSqlRepo:IAnnouncementRepo
    {
        private readonly AppDbContext _context;

        public AnnouncementSqlRepo(AppDbContext context)
        {
            this._context = context;
        }
        public Announcement GetById(int id)
        {
            var ann = _context.Announcements.FirstOrDefault(a => a.Id == id);
            if (ann == null)
            {
                throw new ArgumentException("Announcement with given id doesn't exist");
            }

            return ann;
        }

        public IEnumerable<Announcement> GetList() => _context.Announcements.ToList();

        public Announcement Add(Announcement announcement)
        {
            if (announcement == null)
            {
                throw new ArgumentNullException();
            }

            _context.Announcements.Add(announcement);
            _context.SaveChanges();
            return announcement;
        }

        public void Edit(Announcement announcement)
        {
            var editAnnouncement = _context.Announcements.FirstOrDefault(a => a.Id == announcement.Id);
            if (editAnnouncement == null)
            {
                throw new ArgumentException("Announcement with given id doesn't exist");
            }

            editAnnouncement.Title = announcement.Title;
            editAnnouncement.Description = announcement.Description;
            editAnnouncement.PhoneNumber = announcement.PhoneNumber;
            editAnnouncement.ShortDescription = announcement.ShortDescription;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ann = _context.Announcements.FirstOrDefault(a => a.Id == id);
            if (ann == null)
            {
                throw new ArgumentException("Announcement with given id doesn't exist");
            }

            _context.Announcements.Remove(ann);
            _context.SaveChanges();
        }
    }
}
