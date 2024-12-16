using FitnessTrackingApp.Data.Models;

namespace FitnessTrackingApp.Data.Seed;

public class BodyWeightLogSeeder
{
    public ICollection<BodyWeightLog> GenerateBodyWeightLogs()
    {
        return new HashSet<BodyWeightLog>()
        {
            new BodyWeightLog()
            {
                Id = 1,
                WeeklyPlanId = 1,
                DateLogged = new DateTime(2024, 12, 01),
                CurrentWeight = 93.4m
            },
            new BodyWeightLog()
            {
                Id = 2,
                WeeklyPlanId = 1,
                DateLogged = new DateTime(2024, 12, 02),
                CurrentWeight = 93.2m
            },
            new BodyWeightLog()
            {
                Id = 3,
                WeeklyPlanId = 1,
                DateLogged = new DateTime(2024, 12, 03),
                CurrentWeight = 93m
            },
            new BodyWeightLog()
            {
                Id = 4,
                WeeklyPlanId = 1,
                DateLogged = new DateTime(2024, 12, 04),
                CurrentWeight = 92.8m
            },
            new BodyWeightLog()
            {
                Id = 5,
                WeeklyPlanId = 1,
                DateLogged = new DateTime(2024, 12, 05),
                CurrentWeight = 92.6m
            },
            new BodyWeightLog()
            {
                Id = 6,
                WeeklyPlanId = 1,
                DateLogged = new DateTime(2024, 12, 06),
                CurrentWeight = 92.4m
            },
            new BodyWeightLog()
            {
                Id = 7,
                WeeklyPlanId = 1,
                DateLogged = new DateTime(2024, 12, 07),
                CurrentWeight = 92.1m
            },
            new BodyWeightLog()
            {
                Id = 8,
                WeeklyPlanId = 1,
                DateLogged = new DateTime(2024, 12, 08),
                CurrentWeight = 91.7m
            },
            new BodyWeightLog()
            {
                Id = 9,
                WeeklyPlanId = 2,
                DateLogged = new DateTime(2024, 12, 09),
                CurrentWeight = 91.4m
            },
            new BodyWeightLog()
            {
                Id = 10,
                WeeklyPlanId = 2,
                DateLogged = new DateTime(2024, 12, 10),
                CurrentWeight = 91.4m
            },
            new BodyWeightLog()
            {
                Id = 11,
                WeeklyPlanId = 2,
                DateLogged = new DateTime(2024, 12, 11),
                CurrentWeight = 91.1m
            },
            new BodyWeightLog()
            {
                Id = 12,
                WeeklyPlanId = 2,
                DateLogged = new DateTime(2024, 12, 12),
                CurrentWeight = 89.7m
            },
            new BodyWeightLog()
            {
                Id = 13,
                WeeklyPlanId = 2,
                DateLogged = new DateTime(2024, 12, 13),
                CurrentWeight = 89.7m
            },
            new BodyWeightLog()
            {
                Id = 14,
                WeeklyPlanId = 2,
                DateLogged = new DateTime(2024, 12, 14),
                CurrentWeight = 89.6m
            },
            new BodyWeightLog()
            {
                Id = 15,
                WeeklyPlanId = 2,
                DateLogged = new DateTime(2024, 12, 15),
                CurrentWeight = 89.5m
            },
            new BodyWeightLog()
            {
                Id = 16,
                WeeklyPlanId = 2,
                DateLogged = new DateTime(2024, 12, 16),
                CurrentWeight = 90m
            },
            new BodyWeightLog()
            {
                Id = 17,
                WeeklyPlanId = 3,
                DateLogged = new DateTime(2024, 12, 17),
                CurrentWeight = 89.8m
            },
            new BodyWeightLog()
            {
                Id = 18,
                WeeklyPlanId = 3,
                DateLogged = new DateTime(2024, 12, 18),
                CurrentWeight = 89.8m
            },
            new BodyWeightLog()
            {
                Id = 19,
                WeeklyPlanId = 3,
                DateLogged = new DateTime(2024, 12, 19),
                CurrentWeight = 89.6m
            },
            new BodyWeightLog()
            {
                Id = 20,
                WeeklyPlanId = 3,
                DateLogged = new DateTime(2024, 12, 20),
                CurrentWeight = 89.5m
            },
            new BodyWeightLog()
            {
                Id = 21,
                WeeklyPlanId = 3,
                DateLogged = new DateTime(2024, 12, 21),
                CurrentWeight = 89.4m
            },
            new BodyWeightLog()
            {
                Id = 22,
                WeeklyPlanId = 3,
                DateLogged = new DateTime(2024, 12, 22),
                CurrentWeight = 89.3m
            },
            new BodyWeightLog()
            {
                Id = 23,
                WeeklyPlanId = 3,
                DateLogged = new DateTime(2024, 12, 23),
                CurrentWeight = 89.4m
            },
            new BodyWeightLog()
            {
                Id = 24,
                WeeklyPlanId = 3,
                DateLogged = new DateTime(2024, 12, 24),
                CurrentWeight = 89.4m
            },
            new BodyWeightLog()
            {
                Id = 25,
                WeeklyPlanId = 4,
                DateLogged = new DateTime(2025, 01, 03),
                CurrentWeight = 89.2m
            },
            new BodyWeightLog()
            {
                Id = 26,
                WeeklyPlanId = 4,
                DateLogged = new DateTime(2025, 01, 04),
                CurrentWeight = 89m
            },
            new BodyWeightLog()
            {
                Id = 27,
                WeeklyPlanId = 4,
                DateLogged = new DateTime(2025, 01, 05),
                CurrentWeight = 89m
            },
            new BodyWeightLog()
            {
                Id = 28,
                WeeklyPlanId = 4,
                DateLogged = new DateTime(2025, 01, 06),
                CurrentWeight = 88.8m
            },
            new BodyWeightLog()
            {
                Id = 29,
                WeeklyPlanId = 4,
                DateLogged = new DateTime(2025, 01, 07),
                CurrentWeight = 88.8m
            },
            new BodyWeightLog()
            {
                Id = 30,
                WeeklyPlanId = 4,
                DateLogged = new DateTime(2025, 01, 08),
                CurrentWeight = 88.6m
            },
            new BodyWeightLog()
            {
                Id = 31,
                WeeklyPlanId = 4,
                DateLogged = new DateTime(2025, 01, 09),
                CurrentWeight = 88.5m
            },
            new BodyWeightLog()
            {
                Id = 32,
                WeeklyPlanId = 4,
                DateLogged = new DateTime(2025, 01, 10),
                CurrentWeight = 88.4m
            },
            new BodyWeightLog()
            {
                Id = 33,
                WeeklyPlanId = 5,
                DateLogged = new DateTime(2025, 01, 11),
                CurrentWeight = 88.4m
            },
            new BodyWeightLog()
            {
                Id = 34,
                WeeklyPlanId = 5,
                DateLogged = new DateTime(2025, 01, 12),
                CurrentWeight = 88.2m
            },
            new BodyWeightLog()
            {
                Id = 35,
                WeeklyPlanId = 5,
                DateLogged = new DateTime(2025, 01, 13),
                CurrentWeight = 88.2m
            },
            new BodyWeightLog()
            {
                Id = 36,
                WeeklyPlanId = 5,
                DateLogged = new DateTime(2025, 01, 14),
                CurrentWeight = 88m
            },
            new BodyWeightLog()
            {
                Id = 37,
                WeeklyPlanId = 5,
                DateLogged = new DateTime(2025, 01, 15),
                CurrentWeight = 88m
            },
            new BodyWeightLog()
            {
                Id = 38,
                WeeklyPlanId = 5,
                DateLogged = new DateTime(2025, 01, 16),
                CurrentWeight = 87.9m
            },
            new BodyWeightLog()
            {
                Id = 39,
                WeeklyPlanId = 5,
                DateLogged = new DateTime(2025, 01, 17),
                CurrentWeight = 87.8m
            },
            new BodyWeightLog()
            {
                Id = 40,
                WeeklyPlanId = 5,
                DateLogged = new DateTime(2025, 01, 18),
                CurrentWeight = 87.5m
            },
            new BodyWeightLog()
            {
                Id = 41,
                WeeklyPlanId = 6,
                DateLogged = new DateTime(2025, 01, 19),
                CurrentWeight = 87.3m
            },
            new BodyWeightLog()
            {
                Id = 42,
                WeeklyPlanId = 6,
                DateLogged = new DateTime(2025, 01, 20),
                CurrentWeight = 87.1m
            },
            new BodyWeightLog()
            {
                Id = 43,
                WeeklyPlanId = 6,
                DateLogged = new DateTime(2025, 01, 21),
                CurrentWeight = 87.1m
            },
            new BodyWeightLog()
            {
                Id = 44,
                WeeklyPlanId = 6,
                DateLogged = new DateTime(2025, 01, 22),
                CurrentWeight = 87m
            },
            new BodyWeightLog()
            {
                Id = 45,
                WeeklyPlanId = 6,
                DateLogged = new DateTime(2025, 01, 23),
                CurrentWeight = 86.6m
            },
            new BodyWeightLog()
            {
                Id = 46,
                WeeklyPlanId = 6,
                DateLogged = new DateTime(2025, 01, 24),
                CurrentWeight = 86.8m
            },
            new BodyWeightLog()
            {
                Id = 47,
                WeeklyPlanId = 6,
                DateLogged = new DateTime(2025, 01, 25),
                CurrentWeight = 86.7m
            },
            new BodyWeightLog()
            {
                Id = 48,
                WeeklyPlanId = 6,
                DateLogged = new DateTime(2025, 01, 26),
                CurrentWeight = 86.5m
            },
            new BodyWeightLog()
            {
                Id = 49,
                WeeklyPlanId = 7,
                DateLogged = new DateTime(2025, 01, 27),
                CurrentWeight = 86.3m
            },
            new BodyWeightLog()
            {
                Id = 50,
                WeeklyPlanId = 7,
                DateLogged = new DateTime(2025, 01, 28),
                CurrentWeight = 86.1m
            },
            new BodyWeightLog()
            {
                Id = 51,
                WeeklyPlanId = 7,
                DateLogged = new DateTime(2025, 01, 29),
                CurrentWeight = 86m
            },
            new BodyWeightLog()
            {
                Id = 52,
                WeeklyPlanId = 7,
                DateLogged = new DateTime(2025, 01, 30),
                CurrentWeight = 86m
            },
            new BodyWeightLog()
            {
                Id = 53,
                WeeklyPlanId = 7,
                DateLogged = new DateTime(2025, 01, 31),
                CurrentWeight = 85.8m
            },
            new BodyWeightLog()
            {
                Id = 54,
                WeeklyPlanId = 7,
                DateLogged = new DateTime(2025, 02, 01),
                CurrentWeight = 85.7m
            },
            new BodyWeightLog()
            {
                Id = 55,
                WeeklyPlanId = 7,
                DateLogged = new DateTime(2025, 02, 02),
                CurrentWeight = 85.6m
            },
            new BodyWeightLog()
            {
                Id = 56,
                WeeklyPlanId = 7,
                DateLogged = new DateTime(2025, 02, 03),
                CurrentWeight = 85.5m
            },
            new BodyWeightLog()
            {
                Id = 57,
                WeeklyPlanId = 8,
                DateLogged = new DateTime(2025, 02, 04),
                CurrentWeight = 85.3m
            },
            new BodyWeightLog()
            {
                Id = 58,
                WeeklyPlanId = 8,
                DateLogged = new DateTime(2025, 02, 05),
                CurrentWeight = 85.7m
            },
            new BodyWeightLog()
            {
                Id = 59,
                WeeklyPlanId = 8,
                DateLogged = new DateTime(2025, 02, 06),
                CurrentWeight = 85.1m
            },
            new BodyWeightLog()
            {
                Id = 60,
                WeeklyPlanId = 8,
                DateLogged = new DateTime(2025, 02, 07),
                CurrentWeight = 85m
            },
            new BodyWeightLog()
            {
                Id = 61,
                WeeklyPlanId = 8,
                DateLogged = new DateTime(2025, 02, 08),
                CurrentWeight = 84.8m
            },
            new BodyWeightLog()
            {
                Id = 62,
                WeeklyPlanId = 8,
                DateLogged = new DateTime(2025, 02, 09),
                CurrentWeight = 84.8m
            },
            new BodyWeightLog()
            {
                Id = 63,
                WeeklyPlanId = 8,
                DateLogged = new DateTime(2025, 02, 10),
                CurrentWeight = 84.8m
            },
            new BodyWeightLog()
            {
                Id = 64,
                WeeklyPlanId = 8,
                DateLogged = new DateTime(2025, 02, 11),
                CurrentWeight = 84.7m
            },
            new BodyWeightLog()
            {
                Id = 65,
                WeeklyPlanId = 9,
                DateLogged = new DateTime(2025, 02, 12),
                CurrentWeight = 84.7m
            },
            new BodyWeightLog()
            {
                Id = 66,
                WeeklyPlanId = 9,
                DateLogged = new DateTime(2025, 02, 13),
                CurrentWeight = 84.7m
            },
            new BodyWeightLog()
            {
                Id = 67,
                WeeklyPlanId = 9,
                DateLogged = new DateTime(2025, 02, 14),
                CurrentWeight = 84.7m
            },
            new BodyWeightLog()
            {
                Id = 68,
                WeeklyPlanId = 9,
                DateLogged = new DateTime(2025, 02, 15),
                CurrentWeight = 84.4m
            },
            new BodyWeightLog()
            {
                Id = 69,
                WeeklyPlanId = 9,
                DateLogged = new DateTime(2025, 02, 16),
                CurrentWeight = 84.2m
            },
            new BodyWeightLog()
            {
                Id = 70,
                WeeklyPlanId = 9,
                DateLogged = new DateTime(2025, 02, 17),
                CurrentWeight = 84.2m
            },
            new BodyWeightLog()
            {
                Id = 71,
                WeeklyPlanId = 9,
                DateLogged = new DateTime(2025, 02, 18),
                CurrentWeight = 84m
            },
            new BodyWeightLog()
            {
                Id = 72,
                WeeklyPlanId = 9,
                DateLogged = new DateTime(2025, 02, 19),
                CurrentWeight = 83.8m
            },
            new BodyWeightLog()
            {
                Id = 73,
                WeeklyPlanId = 10,
                DateLogged = new DateTime(2025, 02, 20),
                CurrentWeight = 83.7m
            },
            new BodyWeightLog()
            {
                Id = 74,
                WeeklyPlanId = 10,
                DateLogged = new DateTime(2025, 02, 21),
                CurrentWeight = 83.7m
            },
            new BodyWeightLog()
            {
                Id = 75,
                WeeklyPlanId = 10,
                DateLogged = new DateTime(2025, 02, 22),
                CurrentWeight = 83.6m
            },
            new BodyWeightLog()
            {
                Id = 76,
                WeeklyPlanId = 10,
                DateLogged = new DateTime(2025, 02, 23),
                CurrentWeight = 83.8m
            },
            new BodyWeightLog()
            {
                Id = 77,
                WeeklyPlanId = 10,
                DateLogged = new DateTime(2025, 02, 24),
                CurrentWeight = 83.4m
            },
            new BodyWeightLog()
            {
                Id = 78,
                WeeklyPlanId = 10,
                DateLogged = new DateTime(2025, 02, 25),
                CurrentWeight = 83.4m
            },
            new BodyWeightLog()
            {
                Id = 79,
                WeeklyPlanId = 10,
                DateLogged = new DateTime(2025, 02, 26),
                CurrentWeight = 83.3m
            },
            new BodyWeightLog()
            {
                Id = 80,
                WeeklyPlanId = 10,
                DateLogged = new DateTime(2025, 02, 27),
                CurrentWeight = 83m
            },
        };
    }
}