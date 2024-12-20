﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessTrackingApp.Common;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Data.Models;

public class BodyWeightGoal
{
    [Key]
    public long Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser ApplicationUser { get; set; } = null!;

    [Required]
    [Range(BodyWeightMinRange, BodyWeightMaxRange)]
    [Precision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    [BodyWeightPrecision(BodyWeightDecimalPrecision, BodyWeightDecimalScale)]
    public decimal GoalWeight { get; set; }

    [Required] 
    public bool IsActive { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateAdded { get; set; }
}