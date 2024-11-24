using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackingApp.Data.Models;

public class Trainer
{
    public Trainer()
    {
        this.Id = Guid.NewGuid();
    }
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
    
    public int YearsOfExperience { get; set; }
    public bool IsAvailable { get; set; }
    public double AverageRating { get; set; }
    public ICollection<GoalPlan> GoalPlans { get; set; } = new HashSet<GoalPlan>();
}