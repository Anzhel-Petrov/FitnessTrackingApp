namespace FitnessTrackingApp.Web.ViewModels.User;

public class AllUsersViewModel
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public IEnumerable<string> Roles { get; set; } = null!;

    public string Status { get; set; } = null!;
}