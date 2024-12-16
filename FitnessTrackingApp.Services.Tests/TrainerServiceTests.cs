using AutoFixture;
using FitnessTrackingApp.Data;
using FitnessTrackingApp.Services.Data;
using FitnessTrackingApp.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        await this._dbContext.Database.EnsureCreatedAsync();

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
        var result = await this._trainerService.GetTrainerPrimaryKeyAsync(Guid.Parse("417ae2a4-ffbb-4e27-855e-d353004e0e91"));

        var expected = Guid.Parse("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46");

        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public async Task TrainerExistsByUserIdAsync_Should_Return_True()
    {
        var trainerUserId = "417ae2a4-ffbb-4e27-855e-d353004e0e91";
        
        var result = await this._trainerService.TrainerExistsByUserIdAsync(trainerUserId);

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
        var trainerId = "d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46";

        var result = await this._trainerService.TrainerExistsByIdAsync(trainerId);

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
        var result = (await this._trainerService.GetAvailableTrainersAsync(Guid.NewGuid())).ToList();

        var hasGoalPlan = result.All(t => t.HasGoalPlan == false);
        Assert.Multiple(() =>
        {
            Assert.That(result, Has.Count.EqualTo(4));
            Assert.That(!hasGoalPlan, Is.False);
        });
    }
}