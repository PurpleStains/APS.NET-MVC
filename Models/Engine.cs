using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace APS.NET_MVC.Models
{
    public class Engine
    {
        [Key]
        public int EngineId { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public int? HorsePower { get; set; }
        public int? Capacity { get; set; }
        public FuelType Petrol { get; set; }
    }

    public enum FuelType
    {
        [Display(Name = "Gasoline")]
        Gasoline,
        [Display(Name = "Diesel")]
        Diesel,
        [Display(Name = "Electric")]
        Electric,
        [Display(Name = "Hybrid")]
        Hybrid,
        [Display(Name = "Hydrogen")]
        Hydrogen
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field.GetCustomAttribute<DisplayAttribute>();
            return attribute == null ? value.ToString() : attribute.Name;
        }
    }
}
