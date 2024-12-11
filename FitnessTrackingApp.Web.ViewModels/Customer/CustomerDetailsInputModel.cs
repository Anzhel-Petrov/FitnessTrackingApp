using System.ComponentModel.DataAnnotations;
using FitnessTrackingApp.Data.Models.Enums;
using static FitnessTrackingApp.Common.EntityValidationMessages;
using static FitnessTrackingApp.Common.ApplicationConstants;

namespace FitnessTrackingApp.Web.ViewModels.Customer;

public class CustomerDetailsInputModel
{
    [Required]
    public Guid TrainerId { get; set; }

    [Required]
    [Display(Name = "What is Your goal?")]
    public GoalType GoalType { get; set; }

    [Display(Name = "Additional information: your activity, fitness history, sports, etc.")]
    [MaxLength(AdditionalNotesMaxLength)]
    public string AdditionalNotes { get; set; }  = null!;

    [Required]
    [Range(BodyWeightMinRange, BodyWeightMaxRange, ErrorMessage = CustomerDetailsWeight)]
    [Display(Name = "Starting Weight (kg)")]
    public decimal StartingWeight { get; set; }
 
    [Required]
    [Range(BodyWeightMinRange, BodyWeightMaxRange, ErrorMessage = CustomerDetailsWeight)]
    [Display(Name = "Target Weight (kg)")]
    public decimal TargetWeight { get; set; }
}