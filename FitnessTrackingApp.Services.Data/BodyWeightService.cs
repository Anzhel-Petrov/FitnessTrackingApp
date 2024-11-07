﻿using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Services.Data;

public class BodyWeightService : IBodyWeightService
{
    private readonly FitnessTrackingAppDbContext _dbContext;

    public BodyWeightService(FitnessTrackingAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<BodyWeightGoal?> GetBodyWeightGoalAsync(Guid? userId)
    {
        var bodyWeightGoal = await _dbContext.BodyWeightGoals
            .FirstOrDefaultAsync(g => g.IsActive && g.UserId == userId);

        return bodyWeightGoal;
    }

    public async Task AddBodyWeightGoal(Guid userId, BodyWeightGoal? bodyWeightGoal, decimal goalWeight)
    {
        if (bodyWeightGoal != null)
        {
            bodyWeightGoal.IsActive = false;  // Deactivate the current goal
            _dbContext.BodyWeightGoals.Update(bodyWeightGoal);
        }

        BodyWeightGoal newBodyWeightGoal = new BodyWeightGoal()
        {
            UserId = userId,
            GoalWeight = goalWeight,
            IsActive = true,
            DateAdded = DateTime.Today
        };

        _dbContext.BodyWeightGoals.Add(newBodyWeightGoal);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<BodyWeightLog>> GetWeeklyBodyWeightLogs(Guid userId)
    {
        var startOfWeek = DateTime.Today.AddDays(-7);
        return await _dbContext.BodyWeightLogs
            .Where(r => r.UserId == userId && r.DateLogged >= startOfWeek)
            .OrderByDescending(r => r.DateLogged)
            .ToListAsync();
    }

    public async Task<ICollection<BodyWeightLog>> GetMonthlyBodyWeightLogs(Guid userId)
    {
        var startOfMonth = DateTime.Today.AddMonths(-1);
        return await _dbContext.BodyWeightLogs
            .Where(r => r.UserId == userId && r.DateLogged >= startOfMonth)
            .OrderByDescending(r => r.DateLogged)
            .ToListAsync();
    }

    public async Task<ICollection<BodyWeightLog>> GetAllBodyWeightLogs(Guid userId)
    {
        return await _dbContext.BodyWeightLogs
            .Where(r => r.UserId == userId)
            .OrderByDescending(r => r.DateLogged)
            .ToListAsync();
    }
}