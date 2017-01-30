using System;
using System.ComponentModel.DataAnnotations;

namespace ChatardApp.Models
{
    public class Meeting
    {
        public int Id { get; set; }

        public ApplicationUser Coach { get; set; }

        [Required]
        public string CoachId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Event Event { get; set; }

        [Required]
        public byte EventId { get; set; }
    }
}