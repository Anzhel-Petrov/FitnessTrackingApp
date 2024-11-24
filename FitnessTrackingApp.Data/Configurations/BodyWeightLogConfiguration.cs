using FitnessTrackingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTrackingApp.Data.Configurations;

public class BodyWeightLogConfiguration : IEntityTypeConfiguration<BodyWeightLog>
{
    public void Configure(EntityTypeBuilder<BodyWeightLog> builder)
    {
        builder.HasIndex(l => l.DateLogged)
            .IsUnique();
    }
}