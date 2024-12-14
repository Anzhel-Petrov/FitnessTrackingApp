﻿using System.ComponentModel.DataAnnotations;
using static FitnessTrackingApp.Common.ApplicationConstants;
using static FitnessTrackingApp.Common.EntityValidationMessages;

namespace FitnessTrackingApp.Web.ViewModels.GoalPlan;

public class RejectGoalPlanViewModel
{
    [Required]
    public long GoalPlanId { get; set; }

    [Required(ErrorMessage = GoalPlanRejectionReasonRequired)]
    [Length(RejectionReasonMinLength, RejectionReasonMaxLength, ErrorMessage = GoalPlanRejectionLength)]
    public string RejectionReason { get; set; } = null!;
}