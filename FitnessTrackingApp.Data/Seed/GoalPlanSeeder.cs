using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Models.Enums;

namespace FitnessTrackingApp.Data.Seed;

public class GoalPlanSeeder
{
    public ICollection<GoalPlan> GenerateGoalPlans()
    {
        return new HashSet<GoalPlan>()
        {
            new GoalPlan()
            {
                Id = 1,
                UserId = Guid.Parse("998CD43D-18C0-45A1-8945-AD10A045879C"),
                TrainerId = Guid.Parse("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"),
                GoalType = GoalType.WightLoss,
                GoalWeigh = 78m,
                CurrentWeight = 93m,
                StartDate = new DateTime(2024, 12, 01),
                EndDate = new DateTime(2025, 02, 23),
                GoalPlanStatus = GoalPlanStatus.Active,
                RejectionReason = null
            },
            new GoalPlan()
            {
                Id = 2,
                UserId = Guid.Parse("998CD43D-18C0-45A1-8945-AD10A045879C"),
                TrainerId = Guid.Parse("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"),
                GoalType = GoalType.WightLoss,
                GoalWeigh = 90m,
                CurrentWeight = 102m,
                StartDate = new DateTime(2024, 10, 01),
                EndDate = new DateTime(2024, 11, 14),
                GoalPlanStatus = GoalPlanStatus.Completed,
                RejectionReason = null
            },
            new GoalPlan()
            {
                Id = 3,
                UserId = Guid.Parse("998CD43D-18C0-45A1-8945-AD10A045879C"),
                TrainerId = Guid.Parse("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"),
                GoalType = GoalType.WightLoss,
                GoalWeigh = 100m,
                CurrentWeight = 113m,
                StartDate = new DateTime(2024, 08, 01),
                EndDate = new DateTime(2024, 10, 07),
                GoalPlanStatus = GoalPlanStatus.Completed,
                RejectionReason = null
            },
            new GoalPlan()
            {
                Id = 4,
                UserId = Guid.Parse("998CD43D-18C0-45A1-8945-AD10A045879C"),
                TrainerId = Guid.Parse("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"),
                GoalType = GoalType.WightLoss,
                GoalWeigh = 78m,
                CurrentWeight = 123m,
                StartDate = new DateTime(2024, 06, 01),
                EndDate = new DateTime(2024, 08, 07),
                GoalPlanStatus = GoalPlanStatus.Rejected,
                RejectionReason = "The desired weight loss for that period is not achievable. Let's do something realistic."
            },
            new GoalPlan()
            {
                Id = 5,
                UserId = Guid.Parse("998CD43D-18C0-45A1-8945-AD10A045879C"),
                TrainerId = Guid.Parse("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"),
                GoalType = GoalType.WightLoss,
                GoalWeigh = 110m,
                CurrentWeight = 123m,
                StartDate = new DateTime(2024, 04, 01),
                EndDate = new DateTime(2024, 06, 17),
                GoalPlanStatus = GoalPlanStatus.Cancelled,
                RejectionReason = null
            },
            new GoalPlan()
            {
                Id = 6,
                UserId = Guid.Parse("998CD43D-18C0-45A1-8945-AD10A045879C"),
                TrainerId = Guid.Parse("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"),
                GoalType = GoalType.WightLoss,
                GoalWeigh = 124m,
                CurrentWeight = 132m,
                StartDate = new DateTime(2024, 02, 11),
                EndDate = new DateTime(2024, 03, 17),
                GoalPlanStatus = GoalPlanStatus.Cancelled,
                RejectionReason = null
            }
        };
    }
}