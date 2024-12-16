using FitnessTrackingApp.Data.Models;

namespace FitnessTrackingApp.Data.Seed;

public class CardioSessionSeeder
{
    public ICollection<CardioSession> GenerateCardioSessions()
    {
        return new HashSet<CardioSession>()
        {
            new CardioSession()
            {
                Id = 1,
                Calories = 300,
                IsHIIT = false,
                SessionsPerWeek = 1
            },
            new CardioSession()
            {
                Id = 2,
                Calories = 300,
                IsHIIT = false,
                SessionsPerWeek = 2
            },
            new CardioSession()
            {
                Id = 3,
                Calories = 300,
                IsHIIT = false,
                SessionsPerWeek = 2
            },
            new CardioSession()
            {
                Id = 4,
                Calories = 300,
                IsHIIT = false,
                SessionsPerWeek = 3
            },
            new CardioSession()
            {
                Id = 5,
                Calories = 300,
                IsHIIT = false,
                SessionsPerWeek = 3
            },
            new CardioSession()
            {
                Id = 6,
                Calories = 300,
                IsHIIT = false,
                SessionsPerWeek = 3
            },
            new CardioSession()
            {
                Id = 7,
                Calories = 300,
                IsHIIT = false,
                SessionsPerWeek = 4
            },
            new CardioSession()
            {
                Id = 8,
                Calories = 300,
                IsHIIT = false,
                SessionsPerWeek = 4
            },
            new CardioSession()
            {
                Id = 9,
                Calories = 300,
                IsHIIT = true,
                SessionsPerWeek = 4
            },
            new CardioSession()
            {
                Id = 10,
                Calories = 300,
                IsHIIT = true,
                SessionsPerWeek = 4
            },
        };
    }
}