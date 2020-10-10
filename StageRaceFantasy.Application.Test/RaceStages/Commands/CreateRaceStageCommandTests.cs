using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.RaceStages.Commands.Create;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.IntegrationTests.RaceStages.Commands
{
    using static Testing;

    public class CreateRaceStageCommandTests : TestBase
    {
        [Test]
        public async Task ShouldRequireMinimumFields()
        {
            var command = new CreateRaceStageCommand();

            var result = await SendAsync(command);

            result.IsBadRequest.Should().BeTrue();
            result.ValidationFailures[nameof(CreateRaceStageCommand.RaceId)].Should().Contain(x => x.Contains(ValidationMessageFragments.NotEmpty));
            result.ValidationFailures[nameof(CreateRaceStageCommand.StartLocation)].Should().Contain(x => x.Contains(ValidationMessageFragments.NotEmpty));
            result.ValidationFailures[nameof(CreateRaceStageCommand.FinishLocation)].Should().Contain(x => x.Contains(ValidationMessageFragments.NotEmpty));
        }
        
        [Test]
        public async Task ShouldReturnBadRequestWhenRaceDoesNotExist()
        {
            var command = new CreateRaceStageCommand()
            {
                RaceId = 123,
                StartLocation = "Paris",
                FinishLocation = "Edinburgh",
            };

            var result = await SendAsync(command);

            result.IsNotFound.Should().BeTrue();
        }
    }
}
