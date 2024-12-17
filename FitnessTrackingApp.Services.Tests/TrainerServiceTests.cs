using AutoFixture;
using FitnessTrackingApp.Data;
using FitnessTrackingApp.Services.Data;
using FitnessTrackingApp.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using static FitnessTrackingApp.Services.Tests.DatabaseSeeder;

namespace FitnessTrackingApp.Services.Tests;

[TestFixture]
public class TrainerServiceTests
{
    private IFixture _fixture = new Fixture();
    private DbContextOptions<FitnessTrackingAppDbContext> _dbOptions;
    private FitnessTrackingAppDbContext _dbContext;

    private ITrainerService _trainerService;

    [SetUp]
    public async Task SetUp()
    {
        this._dbOptions = new DbContextOptionsBuilder<FitnessTrackingAppDbContext>()
            .UseInMemoryDatabase(databaseName:"FitnessTrackingAppInMemory")
            .Options;

        this._dbContext = new FitnessTrackingAppDbContext(this._dbOptions);

        SeedDatabase(_dbContext);
        await _dbContext.SaveChangesAsync();
        //await this._dbContext.Database.EnsureCreatedAsync();

        this._trainerService = new TrainerService(this._dbContext);
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
        var result = await this._trainerService.GetTrainerPrimaryKeyAsync(trainer1.UserId);

        var expected = trainer1.Id;

        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public async Task TrainerExistsByUserIdAsync_Should_Return_True()
    {
        var trainerUserId = trainer3.UserId;
        
        var result = await this._trainerService.TrainerExistsByUserIdAsync(trainerUserId.ToString());

        Assert.That(result, Is.True);
    }
    
    [Test]
    public async Task TrainerExistsByUserIdAsync_Should_Return_False()
    {
        var result = await this._trainerService.TrainerExistsByUserIdAsync(Guid.NewGuid().ToString());

        Assert.That(result, Is.False);
    }

    [Test]
    public async Task TrainerExistsByIdAsync_Should_Return_True()
    {
        var trainerId = trainer5.Id;

        var result = await this._trainerService.TrainerExistsByIdAsync(trainerId.ToString());

        Assert.That(result, Is.True);
    }

    [Test]
    public async Task TrainerExistsByIdAsync_Should_Return_False()
    {
        var result = await this._trainerService.TrainerExistsByIdAsync(Guid.NewGuid().ToString());

        Assert.That(result, Is.False);
    }

    [Test]
    public async Task GetAvailableTrainersAsync_Should_Return_Only_Available_Trainers()
    {
        var allTrainersCount = await _dbContext.Trainers.CountAsync();

        var result = (await this._trainerService.GetAvailableTrainersAsync(Guid.NewGuid())).ToList();

        var hasGoalPlan = result.All(t => t.HasGoalPlan == false);

        Assert.Multiple(() =>
        {
            Assert.That(allTrainersCount, Is.EqualTo(5));
            Assert.That(result, Has.Count.EqualTo(4));
            Assert.That(!hasGoalPlan, Is.False);
        });
    }
}