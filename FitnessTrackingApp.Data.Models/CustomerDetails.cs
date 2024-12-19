using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data.Models.Enums;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Data.Models;

public class CustomerDetails
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long GoalPlanId { get; set; }

    [ForeignKey(nameof(GoalPlanId))] 
    public GoalPlan GoalPlan { get; set; } = null!;

    [Required]
    public GoalType GoalType { get; set; }

    [MaxLength(AdditionalNotesMaxLength)]
    public string? AdditionalNotes { get; set; }
    
    [Required]
    [Range(BodyWeightMinRange, BodyWeightMaxRange)]
    [Precision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    [BodyWeightPrecision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    public decimal StartingWeight { get; set; }
    
    [Required]
    [Range(BodyWeightMinRange, BodyWeightMaxRange)]
    [Precision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    [BodyWeightPrecision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    public decimal TargetWeight { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateCreated { get; set; }
}