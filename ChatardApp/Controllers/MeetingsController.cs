﻿using ChatardApp.Models;
using ChatardApp.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ChatardApp.Controllers
{
    public class MeetingsController : Controller
    {

            private readonly ApplicationDbContext _context;

            public MeetingsController()
            {
                _context = new ApplicationDbContext();
            }

            [Authorize]
            public ActionResult Following()
            {

            var userId = User.Identity.GetUserId();

            var teams = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();

                return View(teams);
            }
        [Authorize]
            public ActionResult Attending()
            {
                var userId = User.Identity.GetUserId();

                var meetings = _context.Attendances
                        .Where(a => a.AttendeeId == userId)
                        .Select(a => a.Meeting)
                        .Include(m => m.Coach)
                        .Include(m => m.Event)
                        .ToList();


                var viewModel = new MeetingsViewModel()
                {
                    UpcomingMeetings = meetings,
                    ShowActions = User.Identity.IsAuthenticated
                };

            return View(viewModel);
            }

        [Authorize]
            public ActionResult Create()
            {
                var viewModel = new MeetingFormViewModel
                {
                    Events = _context.Events.ToList()
                };
                return View(viewModel);
            }

            
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeetingFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Events = _context.Events.ToList();
                return View("Create", viewModel);
            }
            var meeting = new Meeting
            {
                CoachId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                EventId = viewModel.Event,
                Venue = viewModel.Venue
            };
            _context.Meetings.Add(meeting);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}