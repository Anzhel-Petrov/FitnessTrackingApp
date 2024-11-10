using FitnessTrackingApp.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FitnessTrackingApp.Common.ApplicationConstants;

namespace FitnessTrackingApp.Web.ViewModels.BodyWeight;

public class BodyWeightGoalCreateViewModel
{
    [Required]
    [Range(BodyWeightMinRange, BodyWeightMaxRange)]
    [Precision(5, 2)]
    [BodyWeightPrecision(5, 2)]
    public decimal GoalWeight { get; set; }
}