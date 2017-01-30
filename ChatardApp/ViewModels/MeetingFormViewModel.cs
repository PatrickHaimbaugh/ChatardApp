using ChatardApp.Models;
using System.Collections.Generic;

namespace ChatardApp.ViewModels
{
    public class MeetingFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Event { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}