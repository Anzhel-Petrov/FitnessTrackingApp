using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Models.Enums;

namespace FitnessTrackingApp.Services.Tests;

public static class DatabaseSeeder
{
    public static Trainer trainer1;
    public static Trainer trainer2;
    public static Trainer trainer3;
    public static Trainer trainer4;
    public static Trainer trainer5;

    public static ApplicationUser trainer1User;
    public static ApplicationUser trainer2User;
    public static ApplicationUser trainer3User;
    public static ApplicationUser trainer4User;
    public static ApplicationUser trainer5User;
    public static ApplicationUser customer1;
    public static ApplicationUser customer2;
    public static ApplicationUser customer3;

    public static GoalPlan goalPlan1;
    public static GoalPlan goalPlan2;
    public static GoalPlan goalPlan3;
    public static GoalPlan goalPlan4;
    public static GoalPlan goalPlan5;
    public static GoalPlan goalPlan6;
    public static GoalPlan goalPlan7;

    public static WeeklyPlan weeklyPlan1;
    public static WeeklyPlan weeklyPlan2;
    public static WeeklyPlan weeklyPlan3;
    public static WeeklyPlan weeklyPlan4;
    public static WeeklyPlan weeklyPlan5;
    public static WeeklyPlan weeklyPlan6;
    public static WeeklyPlan weeklyPlan7;
    public static WeeklyPlan weeklyPlan8;
    public static WeeklyPlan weeklyPlan9;
    public static WeeklyPlan weeklyPlan10;

    public static CustomerDetails customerDetailsGoalPlan1;
    public static CustomerDetails customerDetailsGoalPlan2;
    public static CustomerDetails customerDetailsGoalPlan3;
    public static CustomerDetails customerDetailsGoalPlan5;
    public static CustomerDetails customerDetailsGoalPlan6;

    public static void SeedDatabase(FitnessTrackingAppDbContext fitnessTrackingAppDbContext)
    {
        fitnessTrackingAppDbContext.Users.AddRange(SeedApplicationUsers());
        fitnessTrackingAppDbContext.Trainers.AddRange(SeedTrainers());
        fitnessTrackingAppDbContext.GoalPlans.AddRange(SeedGoalPlans());
        fitnessTrackingAppDbContext.CustomerDetails.AddRange(SeedCustomerDetails());
        //fitnessTrackingAppDbContext.WeeklyPlans.AddRange(SeedWeeklyPlans());
    }

    private static IList<ApplicationUser> SeedApplicationUsers()
    {
        List<ApplicationUser> applicationUsers = new List<ApplicationUser>();

        trainer1User = new ApplicationUser()
        {
            Id = new Guid(),
            UserName = "trainer@getfit.com",
            NormalizedUserName = "TRAINER@GETFIT.COM",
            Email = "trainer@getfit.com",
            NormalizedEmail = "TRAINER@GETFIT.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAELgDoi5HDG8Pug6HCYSQo6/+SA6L54OY4AGwUyjd0USCYX57uHHIIiuFLC3bJxuafA==",
            SecurityStamp = "4JZZ3RICHGHZ3WDZWHJICS76QRJAESPV"
        };

        trainer2User = new ApplicationUser()
        {
            Id = new Guid(),
            UserName = "trainer2@getfit.com",
            NormalizedUserName = "TRAINER2@GETFIT.COM",
            Email = "trainer2@getfit.com",
            NormalizedEmail = "TRAINER2@GETFIT.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEKi4X8jlIeKb2Ks+WTYxDzXEtjWoEEUxXkHQwV4gNQ4Y55lp3v9e73xxGJRC82dC6A==",
            SecurityStamp = "3AYQOQVOUTYD57DGY46IMWFVAQFC7BXE"
        };

        trainer3User = new ApplicationUser()
        {
            Id = new Guid(),
            UserName = "trainer3@getfit.com",
            NormalizedUserName = "TRAINER3@GETFIT.COM",
            Email = "trainer3@getfit.com",
            NormalizedEmail = "TRAINER3@GETFIT.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEM091clNOAmxwsYSHkdKdFrIX9VqVNOlisCtHCMQsHrCwjO8n3FkR/aTOzjO7U39rA==",
            SecurityStamp = "PS3NQ5SUDKLIPXVZUOLB2WUVYWSCGT4B"
        };

        trainer4User = new ApplicationUser()
        {
            Id = new Guid(),
            UserName = "trainer4@getfit.com",
            NormalizedUserName = "TRAINER4@GETFIT.COM",
            Email = "trainer4@getfit.com",
            NormalizedEmail = "TRAINER4@GETFIT.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAED2P7oQH2z6h/CMWDPHngCMirJN+RM3sCXtpmUdMSkRd2HzDYMyxw1Vnu0/ynO1BHA==",
            SecurityStamp = "CPRDG6HRGDF2RZSL25ZQTAQN6CCFN3OU"
        };

        trainer5User = new ApplicationUser()
        {
            Id = new Guid(),
            UserName = "trainer5@getfit.com",
            NormalizedUserName = "TRAINER5@GETFIT.COM",
            Email = "trainer5@getfit.com",
            NormalizedEmail = "TRAINER5@GETFIT.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEBlaW8OGa3wuT5fTPou0rvz6TpIbQo8fuiXX64BxjqQDguHMTGANK8dsSA2yotbUig==",
            SecurityStamp = "KLUU7OY42MOI2B6YKLLUTT5KTZX5P4SN"
        };

        customer1 = new ApplicationUser()
        {
            Id = new Guid(),
            UserName = "customer@getfit.com",
            NormalizedUserName = "CUSTOMER@GETFIT.COM",
            Email = "customer@getfit.com",
            NormalizedEmail = "CUSTOMER@GETFIT.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEEGajbY5tkobSYD+nF2Gg7/r5/1jfdmmZ9EwiLi8CuuoEBPjTLnUK4NKkgukS1WMug==",
            SecurityStamp = "XSQNL6UP4MS75TOZ6ZSUU2KWLYQ544CH"
        };

        customer2 = new ApplicationUser()
        {
            Id = new Guid(),
            UserName = "customer2@getfit.com",
            NormalizedUserName = "CUSTOMER2@GETFIT.COM",
            Email = "customer2@getfit.com",
            NormalizedEmail = "CUSTOMER2@GETFIT.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEEGajbY5tkobSYD+nF2Gg7/r5/1jfdmmZ9EwiLi8CuuoEBPjTLnUK4NKkgukS1WMug==",
            SecurityStamp = "XSQNL6UP4MS75TOZ6ZSUU2KWLYQ544CH"
        };

        customer3 = new ApplicationUser()
        {
            Id = new Guid(),
            UserName = "customer3@getfit.com",
            NormalizedUserName = "CUSTOMER3@GETFIT.COM",
            Email = "customer3@getfit.com",
            NormalizedEmail = "CUSTOMER3@GETFIT.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEEGajbY5tkobSYD+nF2Gg7/r5/1jfdmmZ9EwiLi8CuuoEBPjTLnUK4NKkgukS1WMug==",
            SecurityStamp = "XSQNL6UP4MS75TOZ6ZSUU2KWLYQ544CH"
        };

        applicationUsers.Add(trainer1User);
        applicationUsers.Add(trainer2User);
        applicationUsers.Add(trainer3User);
        applicationUsers.Add(trainer4User);
        applicationUsers.Add(trainer5User);
        applicationUsers.Add(customer1);
        applicationUsers.Add(customer2);
        applicationUsers.Add(customer3);

        return applicationUsers;
    }

    private static IList<Trainer> SeedTrainers()
    {
        List<Trainer> trainers = new List<Trainer>();

        trainer1 = new Trainer()
        {
            Id = new Guid(),
            UserId = trainer1User.Id,
            AverageRating = 6.4D,
            IsAvailable = true,
            YearsOfExperience = 7
        };

        trainer2 = new Trainer()
        {
            Id = new Guid(),
            UserId = trainer2User.Id,
            AverageRating = 8.2D,
            IsAvailable = true,
            YearsOfExperience = 12
        };

        trainer3 = new Trainer()
        {
            Id = new Guid(),
            UserId = trainer3User.Id,
            AverageRating = 3.9D,
            IsAvailable = true,
            YearsOfExperience = 4
        };

        trainer4 = new Trainer()
        {
            Id = new Guid(),
            UserId = trainer4User.Id,
            AverageRating = 2.2D,
            IsAvailable = false,
            YearsOfExperience = 2
        };

        trainer5 = new Trainer()
        {
            Id = new Guid(),
            UserId = trainer5User.Id,
            AverageRating = 0,
            IsAvailable = true,
            YearsOfExperience = 0
        };

        trainers.Add(trainer1);
        trainers.Add(trainer2);
        trainers.Add(trainer3);
        trainers.Add(trainer4);
        trainers.Add(trainer5);

        return trainers;
    }

    private static IList<GoalPlan> SeedGoalPlans()
    {
        List<GoalPlan> goalPlans = new List<GoalPlan>();

        goalPlan1 = new GoalPlan()
        {
            Id = 1,
            UserId = customer1.Id,
            TrainerId = trainer1.Id,
            GoalType = GoalType.WightLoss,
            GoalWeigh = 78m,
            CurrentWeight = 93m,
            StartDate = new DateTime(2024, 12, 01),
            EndDate = new DateTime(2025, 02, 23),
            GoalPlanStatus = GoalPlanStatus.Active,
            RejectionReason = null
        };

        goalPlan2 = new GoalPlan()
        {
            Id = 2,
            UserId = customer1.Id,
            TrainerId = trainer1.Id,
            GoalType = GoalType.WightLoss,
            GoalWeigh = 90m,
            CurrentWeight = 102m,
            StartDate = new DateTime(2024, 10, 01),
            EndDate = new DateTime(2024, 11, 14),
            GoalPlanStatus = GoalPlanStatus.Completed,
            RejectionReason = null
        };

        goalPlan3 = new GoalPlan()
        {
            Id = 3,
            UserId = customer1.Id,
            TrainerId = trainer1.Id,
            GoalType = GoalType.WightLoss,
            GoalWeigh = 100m,
            CurrentWeight = 113m,
            StartDate = new DateTime(2024, 08, 01),
            EndDate = new DateTime(2024, 10, 07),
            GoalPlanStatus = GoalPlanStatus.Completed,
            RejectionReason = null
        };

        goalPlan4 = new GoalPlan()
        {
            Id = 4,
            UserId = customer1.Id,
            TrainerId = trainer1.Id,
            GoalType = GoalType.WightLoss,
            GoalWeigh = 78m,
            CurrentWeight = 123m,
            StartDate = new DateTime(2024, 06, 01),
            EndDate = new DateTime(2024, 08, 07),
            GoalPlanStatus = GoalPlanStatus.Rejected,
            RejectionReason = "The desired weight loss for that period is not achievable. Let's do something realistic."
        };

        goalPlan5 = new GoalPlan()
        {
            Id = 5,
            UserId = customer1.Id,
            TrainerId = trainer1.Id,
            GoalType = GoalType.WightLoss,
            GoalWeigh = 110m,
            CurrentWeight = 123m,
            StartDate = new DateTime(2024, 04, 01),
            EndDate = new DateTime(2024, 06, 17),
            GoalPlanStatus = GoalPlanStatus.Cancelled,
            RejectionReason = null
        };

        goalPlan6 = new GoalPlan()
        {
            Id = 6,
            UserId = customer1.Id,
            TrainerId = trainer1.Id,
            GoalType = GoalType.WightLoss,
            GoalWeigh = 124m,
            CurrentWeight = 132m,
            StartDate = new DateTime(2024, 02, 11),
            EndDate = new DateTime(2024, 03, 17),
            GoalPlanStatus = GoalPlanStatus.Cancelled,
            RejectionReason = null
        };

        goalPlan7 = new GoalPlan()
        {
            Id = 7,
            UserId = customer3.Id,
            TrainerId = trainer1.Id,
            GoalType = GoalType.WightLoss,
            GoalWeigh = 124m,
            CurrentWeight = 132m,
            StartDate = new DateTime(2024, 02, 11),
            EndDate = new DateTime(2024, 03, 17),
            GoalPlanStatus = GoalPlanStatus.Pending,
            RejectionReason = null
        };

        goalPlans.Add(goalPlan1);
        goalPlans.Add(goalPlan2);
        goalPlans.Add(goalPlan3);
        goalPlans.Add(goalPlan4);
        goalPlans.Add(goalPlan5);
        goalPlans.Add(goalPlan6);
        goalPlans.Add(goalPlan7);

        return goalPlans;
    }

    private static IList<CustomerDetails> SeedCustomerDetails()
    {
        List<CustomerDetails> customerDetails = new List<CustomerDetails>();

        customerDetailsGoalPlan1 = new CustomerDetails()
        {
            Id = 1,
            GoalPlanId = goalPlan1.Id,
            GoalType = GoalType.WightLoss,
            AdditionalNotes = "I am back for more - more motivated than ever to get leaner and stronger.",
            StartingWeight = 93m,
            TargetWeight = 78m,
            DateCreated = new DateTime(2024, 12, 01)
        };

        customerDetailsGoalPlan2 = new CustomerDetails()
        {
            Id = 2,
            GoalPlanId = goalPlan2.Id,
            GoalType = GoalType.WightLoss,
            AdditionalNotes =
                "The last session was great, but I think I am able to cut down more and get in better shape.",
            StartingWeight = 102m,
            TargetWeight = 90m,
            DateCreated = new DateTime(2024, 10, 01)
        };

        customerDetailsGoalPlan3 = new CustomerDetails()
        {
            Id = 3,
            GoalPlanId = goalPlan3.Id,
            GoalType = GoalType.WightLoss,
            AdditionalNotes =
                "Having hypothyroidism I started to realize I was gaining weight easier than before and not the good kind of weight wither. " +
                "With the help of Matt the focus was to stay active, hit my macros on a daily basis and the change will come. " +
                "I wasn't perfect but I was able to go down in weight and was able to fit on my old clothes that haven't been able to wear in 2 years. " +
                "Staying consistent, active and still eating the things I love, made it very enjoyable for me. I am extremely happy of my progress and have" +
                " re-found my confidence I was missing.",
            StartingWeight = 113m,
            TargetWeight = 110m,
            DateCreated = new DateTime(2024, 08, 01)
        };

        customerDetailsGoalPlan5 = new CustomerDetails()
        {
            Id = 5,
            GoalPlanId = goalPlan5.Id,
            GoalType = GoalType.WightLoss,
            AdditionalNotes = "",
            StartingWeight = 123m,
            TargetWeight = 110m,
            DateCreated = new DateTime(2024, 04, 01)
        };

        customerDetailsGoalPlan6 = new CustomerDetails()
        {
            Id = 6,
            GoalPlanId = goalPlan6.Id,
            GoalType = GoalType.WightLoss,
            AdditionalNotes = "",
            StartingWeight = 132m,
            TargetWeight = 124m,
            DateCreated = new DateTime(2024, 02, 11)
        };

        customerDetails.Add(customerDetailsGoalPlan1);
        customerDetails.Add(customerDetailsGoalPlan2);
        customerDetails.Add(customerDetailsGoalPlan3);
        customerDetails.Add(customerDetailsGoalPlan5);
        customerDetails.Add(customerDetailsGoalPlan6);

        return customerDetails;
    }

    private static IList<WeeklyPlan> SeedWeeklyPlans()
    {
        List<WeeklyPlan> weeklyPlans = new List<WeeklyPlan>();
        weeklyPlan1 = new WeeklyPlan()
        {
            Id = 1,
            GoalPlanId = goalPlan1.Id,
            Week = 1,
            StartDate = new DateTime(2024, 12, 01),
            EndDate = new DateTime(2024, 12, 08),
            MacroId = 1,
            CardioSessionId = 1,
        };
        weeklyPlan2 = new WeeklyPlan()
        {
            Id = 2,
            GoalPlanId = goalPlan1.Id,
            Week = 2,
            StartDate = new DateTime(2024, 12, 09),
            EndDate = new DateTime(2024, 12, 16),
            MacroId = 2,
            CardioSessionId = 2,
        };

        weeklyPlan3 = new WeeklyPlan()
        {
            Id = 3,
            GoalPlanId = goalPlan1.Id,
            Week = 3,
            StartDate = new DateTime(2024, 12, 17),
            EndDate = new DateTime(2024, 12, 24),
            MacroId = 3,
            CardioSessionId = 3,
        };

        weeklyPlan4 = new WeeklyPlan()
        {
            Id = 4,
            GoalPlanId = goalPlan1.Id,
            Week = 4,
            StartDate = new DateTime(2025, 01, 03),
            EndDate = new DateTime(2025, 01, 10),
            MacroId = 4,
            CardioSessionId = 4,
        };

        weeklyPlan5 = new WeeklyPlan()
        {
            Id = 5,
            GoalPlanId = goalPlan1.Id,
            Week = 5,
            StartDate = new DateTime(2025, 01, 11),
            EndDate = new DateTime(2025, 01, 18),
            MacroId = 5,
            CardioSessionId = 5,
        };

        weeklyPlan6 = new WeeklyPlan()
        {
            Id = 6,
            GoalPlanId = goalPlan6.Id,
            Week = 6,
            StartDate = new DateTime(2025, 01, 19),
            EndDate = new DateTime(2025, 01, 26),
            MacroId = 6,
            CardioSessionId = 6,
        };
        weeklyPlan7 = new WeeklyPlan()
        {
            Id = 7,
            GoalPlanId = goalPlan1.Id,
            Week = 7,
            StartDate = new DateTime(2025, 01, 27),
            EndDate = new DateTime(2025, 02, 03),
            MacroId = 7,
            CardioSessionId = 7,
        };
        weeklyPlan8 = new WeeklyPlan()
        {
            Id = 8,
            GoalPlanId = goalPlan1.Id,
            Week = 8,
            StartDate = new DateTime(2025, 02, 04),
            EndDate = new DateTime(2025, 02, 11),
            MacroId = 8,
            CardioSessionId = 8,
        };

        weeklyPlan8 = new WeeklyPlan()
        {
            Id = 9,
            GoalPlanId = goalPlan1.Id,
            Week = 9,
            StartDate = new DateTime(2025, 02, 12),
            EndDate = new DateTime(2025, 02, 19),
            MacroId = 9,
            CardioSessionId = 9,
        };

        weeklyPlan10 = new WeeklyPlan()
        {
            Id = 10,
            GoalPlanId = goalPlan1.Id,
            Week = 10,
            StartDate = new DateTime(2025, 02, 20),
            EndDate = new DateTime(2025, 02, 27),
            MacroId = 10,
            CardioSessionId = 10,
        };

        weeklyPlans.Add(weeklyPlan1);
        weeklyPlans.Add(weeklyPlan2);
        weeklyPlans.Add(weeklyPlan3);
        weeklyPlans.Add(weeklyPlan4);
        weeklyPlans.Add(weeklyPlan5);
        weeklyPlans.Add(weeklyPlan6);
        weeklyPlans.Add(weeklyPlan7);
        weeklyPlans.Add(weeklyPlan8);
        weeklyPlans.Add(weeklyPlan9);
        weeklyPlans.Add(weeklyPlan10);

        return weeklyPlans;
    }
}