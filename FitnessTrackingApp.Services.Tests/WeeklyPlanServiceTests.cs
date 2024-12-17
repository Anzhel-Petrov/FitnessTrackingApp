using AutoFixture;
using FitnessTrackingApp.Data;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Services.Data;
using Microsoft.EntityFrameworkCore;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Web.ViewModels.WeeklyPlan;
using FitnessTrackingApp.Common;

namespace FitnessTrackingApp.Services.Tests;

[TestFixture]
public class WeeklyPlanServiceTests
{
    private IFixture _fixture;
    private DbContextOptions<FitnessTrackingAppDbContext> _dbOptions;
    private FitnessTrackingAppDbContext _dbContext;

    private IWeeklyPlanService _weeklyPlanService;

    [SetUp]
    public async Task SetUp()
    {
        _fixture = new Fixture();

        this._dbOptions = new DbContextOptionsBuilder<FitnessTrackingAppDbContext>()
            .UseInMemoryDatabase(databaseName: "FitnessTrackingAppInMemory")
            .Options;

        this._dbContext = new FitnessTrackingAppDbContext(this._dbOptions);

        await this._dbContext.Database.EnsureCreatedAsync();

        this._weeklyPlanService = new WeeklyPlanService(this._dbContext);
    }

    [TearDown]
    public async Task TearDown()
    {
        await this._dbContext.Database.EnsureDeletedAsync();
        await this._dbContext.DisposeAsync();
    }

    [Test]
    public async Task GetTrainerPrimaryKeyAsync_Should_Return_TrainerPrimaryKey()
    {
        var result = await this._weeklyPlanService.GetWeeklyPlanByIdAsync(1);

        Assert.That(result, Is.TypeOf<WeeklyPlan>());
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(1));
    }

    [Test]
    public async Task AssignWeeklyPlanAsync_Creates_WeeklyPlan_Success()
    {
        AssignWeeklyPanViewModel assignWeeklyPanViewModel = _fixture.Build<AssignWeeklyPanViewModel>()
            .With(wp => wp.GoalPlanId, 1)
            .With(wp => wp.Week, 11)
            .Create();

        var result = await this._weeklyPlanService.AssignWeeklyPlanAsync(assignWeeklyPanViewModel,
            Guid.Parse("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"));

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Message, Is.Not.Null);
        Assert.That(result.Message, Is.EqualTo($"Weekly plan for week {assignWeeklyPanViewModel.Week} was added to Goal Plan."));
    }

    [Test]
    public async Task GetWeeklyPlansByGoalPlanIdAsync_Should_Return_WeeklyPlans_Success()
    {
        var result = await this._weeklyPlanService.GetWeeklyPlansByGoalPlanIdAsync(1);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<TrainerWeeklyPlanViewModel>());
        Assert.That(result.GoalPlanId, Is.EqualTo(1));
    }

    [Test]
    public async Task GetAllWeeklyPlansForCustomerAsync_Should_Return_WeeklyPlans_Success()
    {
        var result = await this._weeklyPlanService.GetAllWeeklyPlansForCustomerAsync(Guid.Parse("998CD43D-18C0-45A1-8945-AD10A045879C"),1);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<WeeklyPlanIndexViewModel>());
        Assert.That(result.CurrentPage, Is.EqualTo(1));
        Assert.That(result.TotalPages, Is.EqualTo(2));
        Assert.That(result.WeeklyPlansAll.Count(), Is.EqualTo(10));
        Assert.That(result.WeeklyPlans.Count(), Is.EqualTo(5));
    }
}