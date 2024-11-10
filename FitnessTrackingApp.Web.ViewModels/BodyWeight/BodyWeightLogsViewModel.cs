namespace FitnessTrackingApp.Web.ViewModels.BodyWeight;

public class BodyWeightLogsViewModel
{
    public List<BodyWeightLogViewModel> Logs { get; set; } = new();
    public BodyWeightLogViewModel NewLog { get; set; } = new BodyWeightLogViewModel();
}