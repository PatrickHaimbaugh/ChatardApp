using ChatardApp.Models;
using System;
using System.Collections.Generic;

namespace ChatardApp.ViewModels
{
    public class MeetingFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Event { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public DateTime DateTime
        {
            get
            {
                return DateTime.Parse(string.Format("{0} {1}", Date, Time));
            }
        }
    }
}