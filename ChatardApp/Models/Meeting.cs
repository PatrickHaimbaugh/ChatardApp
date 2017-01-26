using System;
using System.ComponentModel.DataAnnotations;

namespace ChatardApp.Models
{
    public class Meeting
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Coach { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        [Required]
        public Event Event { get; set; }
    }
}