using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static FitnessTrackingApp.Common.ApplicationConstants;

namespace FitnessTrackingApp.Data.Models;

public class BodyWeightLog
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long GoalPlanId { get; set; }

    [ForeignKey(nameof(GoalPlanId))]
    public GoalPlan GoalPlan { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateLogged { get; set; }

    [Required]
    [Range(BodyWeightMinRange, BodyWeightMaxRange)]
    [Precision(5, 2)]
    public decimal CurrentWeight { get; set; }
}