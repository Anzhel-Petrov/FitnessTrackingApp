using System.ComponentModel.DataAnnotations;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Data.Models.Enums;

public enum GoalType
{
    [Display(Name = WeightLossDisplay)]
    WightLoss = 0,
    [Display(Name = WeightGainDisplay)]
    WeightGain = 1,
    [Display(Name = WeightMaintainDisplay)]
    MaintainWeight = 2

}