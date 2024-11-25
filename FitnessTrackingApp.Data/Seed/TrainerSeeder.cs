using FitnessTrackingApp.Data.Models;

namespace FitnessTrackingApp.Data.Seed;

public class TrainerSeeder
{
    public ICollection<Trainer> GenerateTrainers()
    {
        return new HashSet<Trainer>()
        {
            new Trainer()
            {
                Id = Guid.Parse("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"),
                UserId = Guid.Parse("417ae2a4-ffbb-4e27-855e-d353004e0e91"),
                AverageRating = 6.4D,
                IsAvailable = true,
                YearsOfExperience = 7
            },
            new Trainer()
            {
                Id = Guid.Parse("ec163c02-6fdd-4e66-bec7-a1418a2fe85a"),
                UserId = Guid.Parse("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                AverageRating = 8.2D,
                IsAvailable = true,
                YearsOfExperience = 12
            },
            new Trainer()
            {
                Id = Guid.Parse("d6644f7d-214a-4295-a971-7b065bd5c5ac"),
                UserId = Guid.Parse("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                AverageRating = 3.9D,
                IsAvailable = true,
                YearsOfExperience = 4
            },
            new Trainer()
            {
                Id = Guid.Parse("df3e0b57-1b43-497a-87d0-97a34ba21c92"),
                UserId = Guid.Parse("90162da5-8408-493a-8dae-99995094cf09"),
                AverageRating = 2.2D,
                IsAvailable = false,
                YearsOfExperience = 2
            },
            new Trainer()
            {
                Id = Guid.Parse("538c0f88-cd08-4dff-9a9e-0b612e436f03"),
                UserId = Guid.Parse("b0209e85-b41c-472b-a767-037253b72665"),
                AverageRating = 0,
                IsAvailable = true,
                YearsOfExperience = 0
            }
        };
    }
}