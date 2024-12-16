using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTrackingApp.Data.Configurations;

public class MacroConfigurations : IEntityTypeConfiguration<Macro>
{
    private readonly MacroSeeder _seeder;
    public MacroConfigurations()
    {
        _seeder = new MacroSeeder();
    }
    public void Configure(EntityTypeBuilder<Macro> builder)
    {
        builder.HasData(_seeder.GenerateMacros());
    }
}