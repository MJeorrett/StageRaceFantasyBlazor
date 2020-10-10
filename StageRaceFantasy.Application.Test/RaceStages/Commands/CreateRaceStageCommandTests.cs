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
        public async Task ShouldRequireTitle()
        {
            var command = new CreateRaceStageCommand();

            var result = await SendAsync(command);

            result.IsBadRequest.Should().BeTrue();
        }
    }
}
