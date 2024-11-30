﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FitnessTrackingApp.Common.ApplicationConstants;

namespace FitnessTrackingApp.Data.Models;

public class CustomerDetails
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long GoalPlanId { get; set; }

    [ForeignKey(nameof(GoalPlanId))] 
    public GoalPlan GoalPlan { get; set; } = null!;

    [Required]
    [MaxLength(GoalDescriptionMaxLength)]
    public string GoalDescription { get; set; } = null!;

    [MaxLength(AdditionalNotesMaxLength)]
    public string? AdditionalNotes { get; set; }
    
    [Required]
    [Range(BodyWeightMinRange, BodyWeightMaxRange)]
    [Precision(5, 2)]
    public decimal StartingWeight { get; set; }
    
    [Required]
    [Range(BodyWeightMinRange, BodyWeightMaxRange)]
    [Precision(5, 2)]
    public decimal TargetWeight { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateCreated { get; set; }
}