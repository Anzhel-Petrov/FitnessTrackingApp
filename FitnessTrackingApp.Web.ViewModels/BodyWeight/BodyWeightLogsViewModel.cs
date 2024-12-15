namespace FitnessTrackingApp.Web.ViewModels.BodyWeight;

public class BodyWeightLogsViewModel
{
    public long WeeklyPlanId { get; set; }
    public DateTime WeeklyPlanStartDate { get; set; }
    public DateTime WeeklyPlanEndDate { get; set; }
    public List<BodyWeightLogViewModel> Logs { get; set; } = new();
    public BodyWeightLogViewModel NewLog { get; set; } = new BodyWeightLogViewModel();
}