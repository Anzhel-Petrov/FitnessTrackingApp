using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Data.Configurations;

public class BodyWeightLogConfiguration : IEntityTypeConfiguration<BodyWeightLog>
{
    private readonly BodyWeightLogSeeder _seeder;

    public BodyWeightLogConfiguration()
    {
        _seeder = new BodyWeightLogSeeder();
    }
    public void Configure(EntityTypeBuilder<BodyWeightLog> builder)
    {
        builder.HasIndex(l => new { l.DateLogged, l.WeeklyPlanId})
            .IsUnique();
        
        builder.HasOne(b => b.WeeklyPlan)
            .WithMany(w => w.BodyWeightLogs)
            .HasForeignKey(b => b.WeeklyPlanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(gp => gp.CurrentWeight).HasPrecision(BodyWeightDecimalPrecision, BodyWeightDecimalScale);

        builder.HasData(_seeder.GenerateBodyWeightLogs());
    }
}