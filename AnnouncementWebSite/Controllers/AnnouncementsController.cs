using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncementWebSite.Models.Entities;
using AnnouncementWebSite.Models.Repos.Interfaces;
using AnnouncementWebSite.ViewModels.Announcements;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

namespace AnnouncementWebSite.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly IAnnouncementRepo _announcementRepo;
        private readonly ILogger<AnnouncementsController> _logger;
        private readonly IMapper _mapper;

        public AnnouncementsController(IAnnouncementRepo announcementRepo, IMapper mapper, ILogger<AnnouncementsController> logger)
        {
            _announcementRepo = announcementRepo;
            _logger = logger;
            this._mapper = mapper;
        }

        public IActionResult GetById(int id)
        {
            Announcement ann = null;
            try
            {
                ann = _announcementRepo.GetById(id);
                
            }
            catch (ArgumentException e)
            {
                _logger.LogWarning(e.Message);
                ViewBag.ErrorMessage = e.Message;
                return View("StatusCodes/NotFound");
            }

            var model = _mapper.Map<DetailsAnnouncementViewModel>(ann);
            model.SimilarAnnouncements =
                GetSimilarAnnouncements(ann).Select(a => _mapper.Map<CardAnnouncementViewModel>(a)).ToList();
            return View("Details",model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddAnnouncementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var announcement = _mapper.Map<Announcement>(model);
                announcement.CreatedAt = DateTime.Now;
                try
                {
                    _announcementRepo.Add(announcement);
                }
                catch (ArgumentNullException e)
                {
                    ViewBag.ErrorMessage = e.Message;
                    _logger.LogWarning(e.Message);
                    throw;
                }
                return RedirectToAction("GetById", new { id = announcement.Id });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Announcement ann = null;
            try
            {
                ann = _announcementRepo.GetById(id);
            }
            catch (ArgumentException e)
            {
                ViewBag.ErrorMessage = e.Message;
                _logger.LogWarning(e.Message);
                return View("StatusCodes/NotFound", id);
            }

            var model = _mapper.Map<EditAnnouncementViewModel>(ann);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditAnnouncementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var announcement = _mapper.Map<Announcement>(model);
                try
                {
                    _announcementRepo.Edit(announcement);
                }
                catch (ArgumentException e)
                {
                    ViewBag.ErrorMessage = e.Message;
                    _logger.LogWarning(e.Message);
                    return View("StatusCodes/NotFound", announcement.Id);
                }
                return RedirectToAction("GetById", new {id = announcement.Id});
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _announcementRepo.Delete(id);
            }
            catch (ArgumentException e)
            {
                ViewBag.ErrorMessage = e.Message;
                _logger.LogWarning(e.Message);
                return View("StatusCodes/NotFound", id);
            }
            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<Announcement> GetSimilarAnnouncements(Announcement announcement)
        {
            List<Announcement> res = new List<Announcement>();
            foreach (var ann in _announcementRepo.GetList().Where(a => a.Id != announcement.Id))
            {
                if (ann.Description.ToLower().Split(' ').Intersect(announcement.Description.ToLower().Split(' ')).Count() != 0 &&
                    ann.Title.ToLower().Split(' ').Intersect(announcement.Title.ToLower().Split(' ')).Count() != 0)
                {
                    res.Add(ann);
                }
            }

            return res.Take(3);
        }
    }
}