using FitnessTrackingApp.Data.Models;

namespace FitnessTrackingApp.Data.Seed;

public class MacroSeeder
{
    public ICollection<Macro> GenerateMacros()
    {
        return new HashSet<Macro>()
        {
            new Macro()
            {
                Id = 1,
                DailyCarbohydrates = 225,
                DailyFat = 55,
                DailyProtein = 190
            },
            new Macro()
            {
                Id = 2,
                DailyCarbohydrates = 250,
                DailyFat = 55,
                DailyProtein = 190
            },
            new Macro()
            {
                Id = 3,
                DailyCarbohydrates = 250,
                DailyFat = 55,
                DailyProtein = 190
            },
            new Macro()
            {
                Id = 4,
                DailyCarbohydrates = 250,
                DailyFat = 55,
                DailyProtein = 190
            },
            new Macro()
            {
                Id = 5,
                DailyCarbohydrates = 250,
                DailyFat = 55,
                DailyProtein = 190
            },
            new Macro()
            {
                Id = 6,
                DailyCarbohydrates = 250,
                DailyFat = 55,
                DailyProtein = 190
            },
            new Macro()
            {
                Id = 7,
                DailyCarbohydrates = 250,
                DailyFat = 55,
                DailyProtein = 190
            },
            new Macro()
            {
                Id = 8,
                DailyCarbohydrates = 225,
                DailyFat = 50,
                DailyProtein = 180
            },
            new Macro()
            {
                Id = 9,
                DailyCarbohydrates = 225,
                DailyFat = 50,
                DailyProtein = 180
            },
            new Macro()
            {
                Id = 10,
                DailyCarbohydrates = 225,
                DailyFat = 50,
                DailyProtein = 180
            },
        };
    }
}