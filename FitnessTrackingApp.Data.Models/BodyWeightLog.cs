using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FitnessTrackingApp.Common;
using Microsoft.EntityFrameworkCore;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Data.Models;

public class BodyWeightLog
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long WeeklyPlanId { get; set; }

    [ForeignKey(nameof(WeeklyPlanId))]
    public WeeklyPlan WeeklyPlan { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateLogged { get; set; }

    [Required]
    [Range(BodyWeightMinRange, BodyWeightMaxRange)]
    [Precision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    [BodyWeightPrecision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    public decimal CurrentWeight { get; set; }
}