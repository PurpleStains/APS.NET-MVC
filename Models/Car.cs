using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APS.NET_MVC.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [MaxLength(70)]
        public string? Brand { get; set; }
        [MaxLength(100)]
        public string? Model { get; set; }
        [Required]
        public DateTime Production { get; set; }

        public int? EngineID { get; set; }
        public virtual Engine? Engine { get; set; }
    }
}
