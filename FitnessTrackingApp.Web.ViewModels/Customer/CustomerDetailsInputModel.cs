using System.ComponentModel.DataAnnotations;
using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using static FitnessTrackingApp.Common.EntityValidationMessages;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Web.ViewModels.Customer;

public class CustomerDetailsInputModel
{
    [Required(ErrorMessage = GoalPlanTrainerIdRequired)]
    public Guid TrainerId { get; set; }

    [Required(ErrorMessage = GoalPlanTypeRequired)]
    [Display(Name = "What is Your goal?")]
    public GoalType GoalType { get; set; }

    [Required(ErrorMessage = GoalPlanAdditionalDetailsIdRequired)]
    [Display(Name = "Additional information: your activity, fitness history, sports, etc.")]
    [MaxLength(AdditionalNotesMaxLength)]
    public string AdditionalNotes { get; set; }  = null!;

    [Required]
    [Range(BodyWeightMinRange, BodyWeightMaxRange, ErrorMessage = CustomerDetailsWeight)]
    [Precision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    [BodyWeightPrecision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    [Display(Name = "Starting Weight (kg)")]
    public decimal StartingWeight { get; set; }
 
    [Required]
    [Range(BodyWeightMinRange, BodyWeightMaxRange, ErrorMessage = CustomerDetailsWeight)]
    [Precision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    [BodyWeightPrecision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    [Display(Name = "Target Weight (kg)")]
    public decimal TargetWeight { get; set; }
}