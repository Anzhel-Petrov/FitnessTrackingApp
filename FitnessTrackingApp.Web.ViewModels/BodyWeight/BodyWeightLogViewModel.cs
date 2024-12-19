using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using FitnessTrackingApp.Common;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

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
    [Range(BodyWeightMinRange, BodyWeightMaxRange)]
    [Precision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    [BodyWeightPrecision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    [Display(Name = "Weight (kg)")]
    public decimal Weight { get; set; }
}