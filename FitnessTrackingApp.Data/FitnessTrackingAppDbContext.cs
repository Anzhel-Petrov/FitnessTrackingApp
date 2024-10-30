using FitnessTrackingApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Data;

public class FitnessTrackingAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public FitnessTrackingAppDbContext()
    {
        
    }

    public FitnessTrackingAppDbContext(DbContextOptions options)
        : base(options)
    {
        
    }
}