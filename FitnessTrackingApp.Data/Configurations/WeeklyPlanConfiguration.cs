using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTrackingApp.Data.Configurations;

public class WeeklyPlanConfiguration : IEntityTypeConfiguration<WeeklyPlan>
{
    private readonly WeeklyPlanSeeder _seeder;

    public WeeklyPlanConfiguration()
    {
        _seeder = new WeeklyPlanSeeder();
    }

    public void Configure(EntityTypeBuilder<WeeklyPlan> builder)
    {
        builder.HasIndex(w => new { w.Week, w.GoalPlanId })
            .IsUnique();

        builder.HasData(_seeder.GenerateWeeklyPlans());
    }
}