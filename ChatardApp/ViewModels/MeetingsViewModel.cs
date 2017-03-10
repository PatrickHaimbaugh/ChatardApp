using ChatardApp.Models;
using System.Collections.Generic;

namespace ChatardApp.ViewModels
{
    public class MeetingsViewModel
    {
        public IEnumerable<Meeting> UpcomingMeetings { get; set; }
        public bool ShowActions { get; set; }
    }
}