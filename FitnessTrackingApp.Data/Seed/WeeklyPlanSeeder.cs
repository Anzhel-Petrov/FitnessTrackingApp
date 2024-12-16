using FitnessTrackingApp.Data.Models;

namespace FitnessTrackingApp.Data.Seed;

public class WeeklyPlanSeeder
{
    public ICollection<WeeklyPlan> GenerateWeeklyPlans()
    {
        return new HashSet<WeeklyPlan>()
        {
            new WeeklyPlan()
            {
                Id = 1,
                GoalPlanId = 1,
                Week = 1,
                StartDate = new DateTime(2024, 12, 01),
                EndDate = new DateTime(2024, 12, 08),
                MacroId = 1,
                CardioSessionId = 1,
            },
            new WeeklyPlan()
            {
                Id = 2,
                GoalPlanId = 1,
                Week = 2,
                StartDate = new DateTime(2024, 12, 09),
                EndDate = new DateTime(2024, 12, 16),
                MacroId = 2,
                CardioSessionId = 2,
            },
            new WeeklyPlan()
            {
                Id = 3,
                GoalPlanId = 1,
                Week = 3,
                StartDate = new DateTime(2024, 12, 17),
                EndDate = new DateTime(2024, 12, 24),
                MacroId = 3,
                CardioSessionId = 3,
            },
            new WeeklyPlan()
            {
                Id = 4,
                GoalPlanId = 1,
                Week = 4,
                StartDate = new DateTime(2025, 01, 03),
                EndDate = new DateTime(2025, 01, 10),
                MacroId = 4,
                CardioSessionId = 4,
            },
            new WeeklyPlan()
            {
                Id = 5,
                GoalPlanId = 1,
                Week = 5,
                StartDate = new DateTime(2025, 01, 11),
                EndDate = new DateTime(2025, 01, 18),
                MacroId = 5,
                CardioSessionId = 5,
            },
            new WeeklyPlan()
            {
                Id = 6,
                GoalPlanId = 1,
                Week = 6,
                StartDate = new DateTime(2025, 01, 19),
                EndDate = new DateTime(2025, 01, 26),
                MacroId = 6,
                CardioSessionId = 6,
            },
            new WeeklyPlan()
            {
                Id = 7,
                GoalPlanId = 1,
                Week = 7,
                StartDate = new DateTime(2025, 01, 27),
                EndDate = new DateTime(2025, 02, 03),
                MacroId = 7,
                CardioSessionId = 7,
            },
            new WeeklyPlan()
            {
                Id = 8,
                GoalPlanId = 1,
                Week = 8,
                StartDate = new DateTime(2025, 02, 04),
                EndDate = new DateTime(2025, 02, 11),
                MacroId = 8,
                CardioSessionId = 8,
            },
            new WeeklyPlan()
            {
                Id = 9,
                GoalPlanId = 1,
                Week = 9,
                StartDate = new DateTime(2025, 02, 12),
                EndDate = new DateTime(2025, 02, 19),
                MacroId = 9,
                CardioSessionId = 9,
            },
            new WeeklyPlan()
            {
                Id = 10,
                GoalPlanId = 1,
                Week = 10,
                StartDate = new DateTime(2025, 02, 20),
                EndDate = new DateTime(2025, 02, 27),
                MacroId = 10,
                CardioSessionId = 10,
            },
        };
    }
}