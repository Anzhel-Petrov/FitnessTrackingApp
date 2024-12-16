using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTrackingApp.Data.Configurations;

public class CardioSessionConfigurations : IEntityTypeConfiguration<CardioSession>
{
    private readonly CardioSessionSeeder _seeder;
    public CardioSessionConfigurations()
    {
        _seeder = new CardioSessionSeeder();
    }
    public void Configure(EntityTypeBuilder<CardioSession> builder)
    {
        builder.HasData(_seeder.GenerateCardioSessions());
    }
}