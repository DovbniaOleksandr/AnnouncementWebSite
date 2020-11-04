using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncementWebSite.Models.Entities;
using AnnouncementWebSite.Models.Repos.Interfaces;

namespace AnnouncementWebSite.Models.Repos
{
    public class AnnouncementMockRepo : IAnnouncementRepo
    {
        private List<Announcement> _list { get; set; }
        public AnnouncementMockRepo()
        {
            _list = new List<Announcement>()
            {
                new Announcement()
                {
                    CreatedAt = new DateTime(year:2020, month:10, day:20),
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Gravida quis blandit turpis cursus in hac habitasse.",
                    Id = 1,
                    PhoneNumber = "0967583885",
                    Title = "Sell bike"
                },
                new Announcement()
                {
                    CreatedAt = new DateTime(year:2020, month:10, day:15),
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Gravida quis blandit turpis cursus in hac habitasse.",
                    Id = 2,
                    PhoneNumber = "0987538885",
                    Title = "Sell home"
                },
                new Announcement()
                {
                    CreatedAt = new DateTime(year:2020, month:10, day:20),
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Gravida quis blandit turpis cursus in hac habitasse.",
                    Id = 3,
                    PhoneNumber = "0667563385",
                    Title = "Sell new PC"
                },
                new Announcement()
                {
                    CreatedAt = new DateTime(year:2020, month:10, day:17),
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Gravida quis blandit turpis cursus in hac habitasse.",
                    Id = 4,
                    PhoneNumber = "0967453888",
                    Title = "Sell car"
                },
                new Announcement()
                {
                    CreatedAt = new DateTime(year:2020, month:11, day:2),
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Gravida quis blandit turpis cursus in hac habitasse.",
                    Id = 5,
                    PhoneNumber = "0966983885",
                    Title = "Sell telephone"
                },
                new Announcement()
                {
                    CreatedAt = new DateTime(year:2020, month:10, day:20),
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Gravida quis blandit turpis cursus in hac habitasse.",
                    Id = 6,
                    PhoneNumber = "0967583885",
                    Title = "Sell boat"
                }
            };
        }
        public Announcement Add(Announcement announcement)
        {
            if (announcement == null)
            {
                throw new ArgumentNullException();
            }
            _list.Add(announcement);
            return announcement;
        }

        public void Delete(int id)
        {
            var announcement = _list.FirstOrDefault(a => a.Id == id);
            if (announcement == null)
            {
                throw new ArgumentException("Announcement with given id doesn't exist");
            }
            _list.Remove(announcement);
        }

        public void Edit(Announcement announcement)
        {
            var announcementIndex = _list.FindIndex(a => a.Id == announcement.Id);
            if (announcementIndex == -1)
            {
                throw new ArgumentException("Announcement with given id doesn't exist");
            }

            _list[announcementIndex] = announcement;
        }

        public Announcement GetById(int id)
        {
            var announcement = _list.FirstOrDefault(a => a.Id == id);
            if (announcement != null)
            {
                return announcement;
            }
            throw new ArgumentException("Announcement with given id doesn't exist");
        }

        public IEnumerable<Announcement> GetList() => _list;
    }
}
