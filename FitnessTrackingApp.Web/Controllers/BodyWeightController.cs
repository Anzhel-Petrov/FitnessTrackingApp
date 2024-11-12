﻿using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Web.Controllers
{
    public class BodyWeightController : BaseController
    {
        private readonly IBodyWeightService _bodyWeightService;

        public BodyWeightController(IBodyWeightService bodyWeightService)
        {
            _bodyWeightService = bodyWeightService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUserId = this.GetUserId();
            
            var bodyWeightGoal = await _bodyWeightService.GetBodyWeightGoalAsync(currentUserId);

            var weeklyBodyWeightProgress = await _bodyWeightService.GetWeeklyBodyWeightLogs(currentUserId);

            var monthlyBodyWeightProgress = await _bodyWeightService.GetMonthlyBodyWeightLogs(currentUserId);

            var lastLoggedBodyWeight = weeklyBodyWeightProgress.Select(l => l.CurrentWeight).LastOrDefault();

            var lastBodyWeightLoggedDate = weeklyBodyWeightProgress.Select(l => l.DateLogged).LastOrDefault();

            BodyWeightDetailsViewModel bodyWeightDetailsViewModel = new BodyWeightDetailsViewModel()
            {
                BodyWeightGoal = bodyWeightGoal,
                MonthlyRecords = monthlyBodyWeightProgress,
                WeeklyRecords = weeklyBodyWeightProgress,
                MostRecentWeight = lastLoggedBodyWeight,
                MostRecentWeightDate = lastBodyWeightLoggedDate,
            };

            return View(bodyWeightDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBodyWeightGoal(
            BodyWeightGoalCreateViewModel bodyWeightGoalCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                //var existingWeightGoal = await _bodyWeightService.GetBodyWeightGoalAsync(userId);

                await _bodyWeightService.AddBodyWeightGoal(this.GetUserId(), bodyWeightGoalCreateViewModel.GoalWeight);

                return RedirectToAction(nameof(Index));
            }

            return View(nameof(Index),
                new BodyWeightDetailsViewModel { GoalWeightViewModel = bodyWeightGoalCreateViewModel });
        }

        [HttpGet]
        public async Task<IActionResult> EditBodyWeightLogs()
        {
            var bodyWeightLogs = await _bodyWeightService.GetAllBodyWeightLogs(this.GetUserId());

            return View(bodyWeightLogs);
        }

        [HttpPost]
        public async Task<IActionResult> AddLog(BodyWeightLogsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(EditBodyWeightLogs), model);
            }

            await _bodyWeightService.AddLogAsync(model.NewLog, this.GetUserId());

            return RedirectToAction(nameof(EditBodyWeightLogs));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveLog(long id)
        {
            await _bodyWeightService.DeleteLogAsync(id, this.GetUserId());

            return RedirectToAction(nameof(EditBodyWeightLogs));
        }
    }
}