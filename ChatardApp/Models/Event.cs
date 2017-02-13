using System.ComponentModel.DataAnnotations;

namespace ChatardApp.Models
{
    public class Event
    {
        public byte? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}