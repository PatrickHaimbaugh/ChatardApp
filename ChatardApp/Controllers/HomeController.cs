using ChatardApp.Models;
using ChatardApp.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ChatardApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        
        public ActionResult Index()
        {
            var upcomingMeetings = _context.Meetings
                .Include(m => m.Coach)
                .Include(m => m.Event)
                .Where(g => g.DateTime > DateTime.Now)
                .OrderBy(m => m.DateTime);

            var viewModel = new MeetingsViewModel
            {
                UpcomingMeetings = upcomingMeetings,
                ShowActions = User.Identity.IsAuthenticated

            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }


}