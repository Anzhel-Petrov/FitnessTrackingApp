using FitnessTrackingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTrackingApp.Data.Configurations;

public class CustomerDetailsConfiguration : IEntityTypeConfiguration<CustomerDetails>
{
    public void Configure(EntityTypeBuilder<CustomerDetails> builder)
    {
        builder.HasKey(cd => cd.Id);

        builder.HasOne(cd => cd.GoalPlan)
            .WithOne(gp => gp.CustomerDetails)
            .HasForeignKey<CustomerDetails>(cd => cd.GoalPlanId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}