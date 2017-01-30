using ChatardApp.Models;
using ChatardApp.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace ChatardApp.Controllers
{
    public class MeetingController : Controller
    {

            private readonly ApplicationDbContext _context;

            public MeetingController()
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
        public ActionResult Create(MeetingFormViewModel viewModel)
        {
            var meeting = new Meeting
            {
                CoachId = User.Identity.GetUserId(),
                DateTime = viewModel.DateTime,
                EventId = viewModel.Event,
                Venue = viewModel.Venue
            };
            _context.Meetings.Add(meeting);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}