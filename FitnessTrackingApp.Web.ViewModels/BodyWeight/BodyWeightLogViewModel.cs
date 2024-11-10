using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using FitnessTrackingApp.Common;

namespace FitnessTrackingApp.Web.ViewModels.BodyWeight;

public class BodyWeightLogViewModel
{
    public long Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date")]
    public DateTime LogDate { get; set; } = DateTime.Today;

    [Required]
    [Range(30, 300)]
    [Precision(5, 2)]
    [BodyWeightPrecision(5,2)]
    [Display(Name = "Weight (kg)")]
    public decimal Weight { get; set; }
}