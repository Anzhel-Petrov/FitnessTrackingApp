using Microsoft.AspNetCore.Identity;

namespace FitnessTrackingApp.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }
        
        public ICollection<GoalPlan> GoalPlans { get; set; } = new List<GoalPlan>();
    }
}
