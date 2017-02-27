using ChatardApp.Dtos;
using ChatardApp.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace ChatardApp.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.MeetingId == dto.MeetingId))
                return BadRequest("The attendance already exists.");

            var attendance = new Attendance
            {
                MeetingId = dto.MeetingId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
