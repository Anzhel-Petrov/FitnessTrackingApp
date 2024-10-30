using FitnessTrackingApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Data;

public class FitnessTrackingDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public FitnessTrackingDbContext()
    {
        
    }

    public FitnessTrackingDbContext(DbContextOptions options)
        : base(options)
    {
        
    }
}