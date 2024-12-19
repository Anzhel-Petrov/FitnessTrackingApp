using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Data.Configurations;

public class CustomerDetailsConfiguration : IEntityTypeConfiguration<CustomerDetails>
{
    private readonly CustomerDetailsSeeder _seeder;

    public CustomerDetailsConfiguration()
    {
        _seeder = new CustomerDetailsSeeder();
    }
    public void Configure(EntityTypeBuilder<CustomerDetails> builder)
    {
        builder.HasKey(cd => cd.Id);

        builder.HasOne(cd => cd.GoalPlan)
            .WithOne(gp => gp.CustomerDetails)
            .HasForeignKey<CustomerDetails>(cd => cd.GoalPlanId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(gp => gp.StartingWeight).HasPrecision(BodyWeightDecimalPrecision, BodyWeightDecimalScale);

        builder.Property(gp => gp.TargetWeight).HasPrecision(BodyWeightDecimalPrecision, BodyWeightDecimalScale);

        builder.HasData(_seeder.GenerateCustomerDetails());
    }
}