using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.RaceStages.Commands.Create;
using System.Threading.Tasks;
using StageRaceFantasy.Application.IntegrationTests.Assertions;

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
            result.ValidationFailures.Should().ContainNotEmptyErrorForProperty(nameof(CreateRaceStageCommand.RaceId));
            result.ValidationFailures.Should().ContainNotEmptyErrorForProperty(nameof(CreateRaceStageCommand.StartLocation));
            result.ValidationFailures.Should().ContainNotEmptyErrorForProperty(nameof(CreateRaceStageCommand.FinishLocation));
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
