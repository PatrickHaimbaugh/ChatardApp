using ChatardApp.Models;
using ChatardApp.ViewModels;
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

            public ActionResult Create()
            {
                var viewModel = new MeetingFormViewModel
                {
                    Events = _context.Events.ToList()
                };
                return View(viewModel);
            }
        }
}