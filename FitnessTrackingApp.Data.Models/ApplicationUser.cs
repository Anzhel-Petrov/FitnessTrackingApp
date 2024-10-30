﻿using Microsoft.AspNetCore.Identity;

namespace FitnessTrackingApp.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
