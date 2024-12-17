using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Models.Enums;

namespace FitnessTrackingApp.Data.Seed;

public class CustomerDetailsSeeder
{
    public ICollection<CustomerDetails> GenerateCustomerDetails()
    {
        return new HashSet<CustomerDetails>()
        {
            new CustomerDetails()
            {
                Id = 1,
                GoalPlanId = 1,
                GoalType = GoalType.WightLoss,
                AdditionalNotes = "I am back for more - more motivated than ever to get leaner and stronger.",
                StartingWeight = 93m,
                TargetWeight = 78m,
                DateCreated = new DateTime(2024, 12, 01)
            },
            new CustomerDetails()
            {
                Id = 2,
                GoalPlanId = 2,
                GoalType = GoalType.WightLoss,
                AdditionalNotes = "The last session was great, but I think I am able to cut down more and get in better shape.",
                StartingWeight = 102m,
                TargetWeight = 90m,
                DateCreated = new DateTime(2024, 10, 01)
            },
            new CustomerDetails()
            {
                Id = 3,
                GoalPlanId = 3,
                GoalType = GoalType.WightLoss,
                AdditionalNotes = "Having hypothyroidism I started to realize I was gaining weight easier than before and not the good kind of weight wither. " +
                                  "With the help of Matt the focus was to stay active, hit my macros on a daily basis and the change will come. " +
                                  "I wasn't perfect but I was able to go down in weight and was able to fit on my old clothes that haven't been able to wear in 2 years. " +
                                  "Staying consistent, active and still eating the things I love, made it very enjoyable for me. I am extremely happy of my progress and have" +
                                  " re-found my confidence I was missing.",
                StartingWeight = 113m,
                TargetWeight = 110m,
                DateCreated = new DateTime(2024, 08, 01)
            },
            new CustomerDetails()
            {
                Id = 4,
                GoalPlanId = 4,
                GoalType = GoalType.WightLoss,
                AdditionalNotes = "I need to loose some weight. I have a condition called hypothyroidism and over the past years I gained a lot of weight. " +
                                  "I am ready to do whatever it takes to loose that weight fast!",
                StartingWeight = 123m,
                TargetWeight = 78m,
                DateCreated = new DateTime(2024, 06, 01)
            },
            new CustomerDetails()
            {
                Id = 5,
                GoalPlanId = 5,
                GoalType = GoalType.WightLoss,
                AdditionalNotes = "",
                StartingWeight = 123m,
                TargetWeight = 110m,
                DateCreated = new DateTime(2024, 04, 01)
            },
            new CustomerDetails()
            {
                Id = 6,
                GoalPlanId = 6,
                GoalType = GoalType.WightLoss,
                AdditionalNotes = "",
                StartingWeight = 132m,
                TargetWeight = 124m,
                DateCreated = new DateTime(2024, 02, 11)
            }
        };
    }
}