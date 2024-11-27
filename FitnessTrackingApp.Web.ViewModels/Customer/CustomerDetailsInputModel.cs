using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.Web.ViewModels.Customer;

public class CustomerDetailsInputModel
{
    [Required]
    public Guid TrainerId { get; set; }

    [Required]
    [Display(Name = "Goal Description")]
    public string GoalDescription { get; set; } = null!;

    [Display(Name = "Additional Notes")]
    public string AdditionalNotes { get; set; }  = null!;

    [Required]
    [Range(30, 300, ErrorMessage = "Weight must be between 30 and 300 kg.")]
    [Display(Name = "Starting Weight (kg)")]
    public decimal StartingWeight { get; set; }
 
    [Required]
    [Range(30, 300, ErrorMessage = "Target weight must be between 30 and 300 kg.")]
    [Display(Name = "Target Weight (kg)")]
    public decimal TargetWeight { get; set; }
}