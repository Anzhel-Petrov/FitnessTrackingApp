using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackingApp.Data.Models;

public class GoalPlan
{
    [Key]
    public long Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [Required]
    public string GoalName { get; set; } = null!; // Consider making this an ENUM - WEight gain, Weight loss, Maintain weight

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public ICollection<WeeklyPlan> WeeklyPlans { get; set; } = new List<WeeklyPlan>();
}