﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessTrackingApp.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using static FitnessTrackingApp.Common.ApplicationConstants;

namespace FitnessTrackingApp.Data.Models;

public class GoalPlan
{
    [Key]
    public long Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser ApplicationUser { get; set; } = null!;
    
    public Guid TrainerId { get; set; }
    
    [ForeignKey(nameof(TrainerId))]
    public Trainer Trainer { get; set; } = null!;

    [Required]
    public string GoalName { get; set; } = null!; // Consider making this an ENUM - WEight gain, Weight loss, Maintain weight

    [Range(BodyWeightMinRange, BodyWeightMaxRange)]
    [Precision(5, 2)]
    public decimal GoalWeigh { get; set; }

    [Range(BodyWeightMinRange, BodyWeightMaxRange)]
    [Precision(5, 2)]
    public decimal CurrentWeight { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    public GoalPlanStatus GoalPlanStatus { get; set; } = GoalPlanStatus.Pending;

    public CustomerDetails CustomerDetails { get; set; } = null!;

    public ICollection<WeeklyPlan> WeeklyPlans { get; set; } = new HashSet<WeeklyPlan>();
}