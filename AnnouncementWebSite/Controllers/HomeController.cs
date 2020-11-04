using System.Diagnostics;
using System.Linq;
using AnnouncementWebSite.Models.Repos.Interfaces;
using AnnouncementWebSite.ViewModels.Announcements;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnnouncementWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnnouncementRepo _announcementRepo;
        private readonly IMapper _mapper;

        public HomeController(IAnnouncementRepo announcementRepo, IMapper mapper)
        {
            _announcementRepo = announcementRepo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var announcements = _announcementRepo.GetList().Select(a => _mapper.Map<CardAnnouncementViewModel>(a));
            return View(announcements);
        }
    }
}
