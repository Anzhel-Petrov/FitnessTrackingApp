using System.Runtime.InteropServices.JavaScript;
using AutoFixture;
using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Models.Enums;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Services.Data;
using Microsoft.EntityFrameworkCore;
using static FitnessTrackingApp.Services.Tests.DatabaseSeeder;
using static FitnessTrackingApp.Common.ErrorMessageConstants;
using FitnessTrackingApp.Web.ViewModels.Customer;
using System.Numerics;
using FitnessTrackingApp.Web.ViewModels.GoalPlan;

namespace FitnessTrackingApp.Services.Tests;

[TestFixture]
public class GoalPlanServiceTests
{
    private IFixture _fixture;
    private Random _random;
    private DbContextOptions<FitnessTrackingAppDbContext> _dbOptions;
    private FitnessTrackingAppDbContext _dbContext;

    private IGoalPlanService _goalPlanService;

    [SetUp]
    public async Task SetUp()
    {
        _fixture = new Fixture();
        _random = new Random();

        this._dbOptions = new DbContextOptionsBuilder<FitnessTrackingAppDbContext>()
            .UseInMemoryDatabase(databaseName: "FitnessTrackingAppInMemory")
            .Options;

        this._dbContext = new FitnessTrackingAppDbContext(this._dbOptions);

        SeedDatabase(_dbContext);

        await _dbContext.SaveChangesAsync();
        //await this._dbContext.Database.EnsureCreatedAsync();

        this._goalPlanService = new GoalPlanService(this._dbContext);
    }

    [TearDown]
    public async Task TearDown()
    {
        await this._dbContext.Database.EnsureDeletedAsync();
        await this._dbContext.DisposeAsync();
    }

    [Test]
    public async Task FindGoalPlanByIdAsync_Should_Return_GoalPlan()
    {
        var result = await this._goalPlanService.FindGoalPlanByIdAsync(goalPlan1.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<GoalPlan>());
        Assert.That(result.Id, Is.EqualTo(goalPlan1.Id));
    }

    [Test]
    public async Task ExistsByIdAndStatusAsync_Should_Return_True_By_Status()
    {
        var result = await this._goalPlanService.ExistsByIdAndStatusAsync(goalPlan1.Id, GoalPlanStatus.Active);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Message, Is.Null);
    }

    [Test]
    public async Task ExistsByIdAndStatusAsync_Should_Return_True_Without_Status_Parameter()
    {
        var result = await this._goalPlanService.ExistsByIdAndStatusAsync(goalPlan2.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Message, Is.Null);
    }


    [Test]
    public async Task ExistsByIdAndStatusAsync_Should_Return_False_Non_Existing_GoalPlan()
    {
        var result = await this._goalPlanService.ExistsByIdAndStatusAsync(99);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Message, Is.Not.Null);
        Assert.That(result.Message, Is.EqualTo("Goal plan invalid."));
    }

    [Test]
    public async Task CreateGoalPlanRequestAsync_Should_Create_GoalPlanRequest()
    {
        CustomerDetailsInputModel customerDetailsInputModel = _fixture.Build<CustomerDetailsInputModel>()
            .With(c => c.TrainerId, trainer1.Id)
            .With(c => c.StartingWeight, _random.Next(30, 300))
            .Create();

        var result = await this._goalPlanService.CreateGoalPlanRequestAsync(customerDetailsInputModel, customer2.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Message, Is.Not.Null);
        Assert.That(result.Message, Is.EqualTo("Goal Plan created successfully."));
    }

    [Test]
    public async Task CreateGoalPlanRequestAsync_Should_Not_Create_GoalPlanRequest_ActiveGoalPlan_With_Trainer()
    {
        CustomerDetailsInputModel customerDetailsInputModel = _fixture.Build<CustomerDetailsInputModel>()
            .With(c => c.TrainerId, trainer1.Id)
            .With(c => c.StartingWeight, _random.Next(30, 300))
            .Create();

        var result = await this._goalPlanService.CreateGoalPlanRequestAsync(customerDetailsInputModel, customer1.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Message, Is.Not.Null);
        Assert.That(result.Message, Is.EqualTo("An active Goal Plan with this Trainer already exists."));
    }

    [Test]
    public async Task CreateGoalPlanRequestAsync_Should_Not_Create_GoalPlanRequest_ActiveGoalPlan()
    {
        CustomerDetailsInputModel customerDetailsInputModel = _fixture.Build<CustomerDetailsInputModel>()
            .With(c => c.TrainerId, trainer2.Id)
            .With(c => c.StartingWeight, _random.Next(30, 300))
            .Create();

        var result = await this._goalPlanService.CreateGoalPlanRequestAsync(customerDetailsInputModel, customer1.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Message, Is.Not.Null);
        Assert.That(result.Message, Is.EqualTo("An active Goal Plan already exists."));
    }

    [Test]
    public async Task CreateGoalPlanRequestAsync_Should_Not_Create_GoalPlanRequest_PendingGoalPlan_With_Trainer()
    {
        CustomerDetailsInputModel customerDetailsInputModel = _fixture.Build<CustomerDetailsInputModel>()
            .With(c => c.TrainerId, trainer1.Id)
            .With(c => c.StartingWeight, _random.Next(30, 300))
            .Create();

        var result = await this._goalPlanService.CreateGoalPlanRequestAsync(customerDetailsInputModel, customer3.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Message, Is.Not.Null);
        Assert.That(result.Message, Is.EqualTo("A pending Goal Plan request for this Trainer already exists."));
    }

    [Test]
    public async Task CreateGoalPlanRequestAsync_Should_Not_Create_GoalPlanRequest_PendingGoalPlan()
    {
        CustomerDetailsInputModel customerDetailsInputModel = _fixture.Build<CustomerDetailsInputModel>()
            .With(c => c.TrainerId, trainer2.Id)
            .With(c => c.StartingWeight, _random.Next(30, 300))
            .Create();

        var result = await this._goalPlanService.CreateGoalPlanRequestAsync(customerDetailsInputModel, customer3.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Message, Is.Not.Null);
        Assert.That(result.Message, Is.EqualTo("A pending Goal Plan request already exists."));
    }

    [TestCase(GoalPlanStatus.Completed, 2)]
    [TestCase(GoalPlanStatus.Cancelled, 2)]
    public async Task GetTrainerGoalPlansByStatusAsync_Should_Return_Correct_GoalPlans(GoalPlanStatus goalPlanStatus,
        int resultCount)
    {
        var result = await this._goalPlanService.GetTrainerGoalPlansByStatusAsync(trainer1.Id, goalPlanStatus);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(resultCount));
        Assert.That(result.Select(gp => gp.Status).FirstOrDefault(), Is.EqualTo(goalPlanStatus.ToString()));
    }

    [Test]
    public async Task GetAllCustomerGoalPlansByIdAsync_Should_Return_All_Customer_GoalPlans()
    {
        var result = await this._goalPlanService.GetAllCustomerGoalPlansByIdAsync(customer1.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(6));
    }

    [Test]
    public async Task GetGoalPlanDetailsAsync_Should_Return_Correct_GoalPlan()
    {
        var result = await this._goalPlanService.GetGoalPlanDetailsAsync(goalPlan1.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.GoalPlanId, Is.EqualTo(goalPlan1.Id));
        Assert.That(result.GoalType, Is.EqualTo(goalPlan1.GoalType));
        Assert.That(result.CurrentWeight, Is.EqualTo(goalPlan1.CurrentWeight));
    }

    [Test]
    public async Task ApproveGoalPlanAsync_Should_Approve_Pending_GoalPlan()
    {
        var result = await this._goalPlanService.ApproveGoalPlanAsync(goalPlan7.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Message, Is.Not.Null);
        Assert.That(result.Message, Is.EqualTo("Goal Plan approved successfully!"));
    }

    [Test]
    public async Task ApproveGoalPlanAsync_Should_Return_Not_Found()
    {
        var result = await this._goalPlanService.ApproveGoalPlanAsync(99);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Message, Is.Not.Null);
        Assert.That(result.Message, Is.EqualTo(GoalPlanNotFound));
    }

    [Test]
    public async Task ApproveGoalPlanAsync_Should_Return_Not_In_Correct_Status()
    {
        var result = await this._goalPlanService.ApproveGoalPlanAsync(goalPlan1.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Message, Is.Not.Null);
        Assert.That(result.Message, Is.EqualTo(GoalPlanApprovalIncorrectStatus));
    }

    [Test]
    public async Task RejectGoalPlanAsync_Should_Set_Status_Reject_Success()
    {
        var result = await this._goalPlanService.RejectGoalPlanAsync(goalPlan7.Id, "Reject reason test.");

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Message, Is.Null);
    }

    [Test]
    public async Task RejectGoalPlanAsync_Should_Return_False_Reason_Null()
    {
        var result = await this._goalPlanService.RejectGoalPlanAsync(goalPlan7.Id, null);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Message, Is.EqualTo(RejectReasonEmpty));
    }

    [Test]
    public async Task RejectGoalPlanAsync_Should_Return_False_GoalPlan_Not_Found()
    {
        var result = await this._goalPlanService.RejectGoalPlanAsync(99, "Reject reason test.");

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Message, Is.EqualTo(GoalPlanNotFound));
    }

    [Test]
    public async Task RejectGoalPlanAsync_Should_Return_False_Incorrect_Status()
    {
        var result = await this._goalPlanService.RejectGoalPlanAsync(goalPlan2.Id, "Reject reason test.");

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OperationResult>());
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Message, Is.EqualTo(GoalPlanRejectionIncorrectStatus));
    }


    [TestCase(GoalPlanStatus.Active)]
    [TestCase(GoalPlanStatus.Pending)]
    [TestCase(GoalPlanStatus.Rejected)]
    [TestCase(GoalPlanStatus.Cancelled)]
    public async Task GetStatisticsInfoAsync_Should_Return_Statistics_Success(GoalPlanStatus goalPlanStatus)
    {
        var result = await this._goalPlanService.GetStatisticsInfoAsync(trainer1.Id, goalPlanStatus);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.TotalGoalPlansCount, Is.EqualTo(7));
    }

    [Test]
    public async Task GetGoalWeight_Returns_Min_Weight()
    {
        var result = await this._goalPlanService.GetGoalWeight(customer1.Id);

        Assert.That(result, Is.EqualTo(78m));
    }
}