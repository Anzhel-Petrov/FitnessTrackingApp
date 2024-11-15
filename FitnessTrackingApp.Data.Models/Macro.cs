using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FitnessTrackingApp.Common.ApplicationConstants;

namespace FitnessTrackingApp.Data.Models;

public class Macro
{
    [Key]
    public long Id { get; set; }
    
    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser ApplicationUser { get; set; } = null!;
    
    [Required]
    public int TotalDailyCalories => CalculateTotalCalories();

    [Required] 
    public int DailyCarbohydrates { get; set; }

    [Required]
    public int DailyProtein { get; set; }
    
    [Required]
    public int DailyFat { get; set; }
    
    private int CalculateTotalCalories()
    {
        return (DailyCarbohydrates * CaloriesPerGramOfCarbohydrates) + (DailyProtein * CaloriesPerGramOfProtein) + (DailyFat * CaloriesPerGramOfFat);
    }
}