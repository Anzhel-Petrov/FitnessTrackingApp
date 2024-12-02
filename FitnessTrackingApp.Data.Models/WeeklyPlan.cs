using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackingApp.Data.Models;

public class WeeklyPlan
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long GoalPlanId { get; set; }

    [ForeignKey(nameof(GoalPlanId))]
    public GoalPlan GoalPlan { get; set; } = null!;

    [Required]
    public int Week { get; set; }

    [Required]
    public long MacroId { get; set; }

    [ForeignKey(nameof(MacroId))]
    public Macro Macro { get; set; } = null!;
    
    public long? CardioSessionId { get; set; }

    [ForeignKey(nameof(CardioSessionId))]
    public CardioSession? CardioSession { get; set; }
}