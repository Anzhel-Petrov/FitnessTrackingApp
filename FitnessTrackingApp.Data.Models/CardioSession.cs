using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackingApp.Data.Models;

public class CardioSession
{
    [Key]
    public long Id { get; set; }

    [Required]
    public int Calories { get; set; }

    [Required]
    public int SessionsPerWeek { get; set; }

    public bool IsHIIT { get; set; }
}