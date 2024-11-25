using FitnessTrackingApp.Data.Models;

namespace FitnessTrackingApp.Data.Seed;

public class ApplicationUserSeeder
{
    public ICollection<ApplicationUser> GenerateUsers()
    {
        return new HashSet<ApplicationUser>()
        {
            new ApplicationUser()
            {
                Id = Guid.Parse("417ae2a4-ffbb-4e27-855e-d353004e0e91"),
                UserName = "trainer@getfit.com",
                NormalizedUserName = "TRAINER@GETFIT.COM",
                Email = "trainer@getfit.com",
                NormalizedEmail = "TRAINER@GETFIT.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAELgDoi5HDG8Pug6HCYSQo6/+SA6L54OY4AGwUyjd0USCYX57uHHIIiuFLC3bJxuafA==",
                SecurityStamp = "4JZZ3RICHGHZ3WDZWHJICS76QRJAESPV"
            },
            new ApplicationUser()
            {
                Id = Guid.Parse("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                UserName = "trainer2@getfit.com",
                NormalizedUserName = "TRAINER2@GETFIT.COM",
                Email = "trainer2@getfit.com",
                NormalizedEmail = "TRAINER2@GETFIT.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEKi4X8jlIeKb2Ks+WTYxDzXEtjWoEEUxXkHQwV4gNQ4Y55lp3v9e73xxGJRC82dC6A==",
                SecurityStamp = "3AYQOQVOUTYD57DGY46IMWFVAQFC7BXE"
            },
            new ApplicationUser()
            {
                Id = Guid.Parse("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                UserName = "trainer3@getfit.com",
                NormalizedUserName = "TRAINER3@GETFIT.COM",
                Email = "trainer3@getfit.com",
                NormalizedEmail = "TRAINER3@GETFIT.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEM091clNOAmxwsYSHkdKdFrIX9VqVNOlisCtHCMQsHrCwjO8n3FkR/aTOzjO7U39rA==",
                SecurityStamp = "PS3NQ5SUDKLIPXVZUOLB2WUVYWSCGT4B"
            },
            new ApplicationUser()
            {
                Id = Guid.Parse("90162da5-8408-493a-8dae-99995094cf09"),
                UserName = "trainer4@getfit.com",
                NormalizedUserName = "TRAINER4@GETFIT.COM",
                Email = "trainer4@getfit.com",
                NormalizedEmail = "TRAINER4@GETFIT.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAED2P7oQH2z6h/CMWDPHngCMirJN+RM3sCXtpmUdMSkRd2HzDYMyxw1Vnu0/ynO1BHA==",
                SecurityStamp = "CPRDG6HRGDF2RZSL25ZQTAQN6CCFN3OU"
            },
            new ApplicationUser()
            {
                Id = Guid.Parse("b0209e85-b41c-472b-a767-037253b72665"),
                UserName = "trainer5@getfit.com",
                NormalizedUserName = "TRAINER5@GETFIT.COM",
                Email = "trainer5@getfit.com",
                NormalizedEmail = "TRAINER5@GETFIT.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEBlaW8OGa3wuT5fTPou0rvz6TpIbQo8fuiXX64BxjqQDguHMTGANK8dsSA2yotbUig==",
                SecurityStamp = "KLUU7OY42MOI2B6YKLLUTT5KTZX5P4SN"
            }
        };
    }
}