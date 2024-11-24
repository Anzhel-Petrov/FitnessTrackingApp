using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTrackingApp.Data.Configurations;

public class TrainerEntityConfiguration : IEntityTypeConfiguration<Trainer>
{
    private readonly TrainerSeeder _seeder;

    public TrainerEntityConfiguration()
    {
        this._seeder = new TrainerSeeder();
    }
    
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

        builder.HasData(this._seeder.GenerateTrainers());
    }
}