using FitnessTrackingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTrackingApp.Data.Configurations;

public class TrainerEntityConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.User)
            .WithOne()
            .HasForeignKey<Trainer>(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.GoalPlans)
            .WithOne(gp => gp.Trainer)
            .HasForeignKey(gp => gp.TrainerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}