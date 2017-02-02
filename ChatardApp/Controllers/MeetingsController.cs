using ChatardApp.Models;
using ChatardApp.ViewModels;
using Microsoft.AspNet.Identity;
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