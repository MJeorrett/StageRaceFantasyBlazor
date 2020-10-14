using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.FantasyTeamRaceEntries.Commands.Create;
using StageRaceFantasy.IntegrationTests.Assertions;
using System.Threading.Tasks;

namespace StageRaceFantasy.IntegrationTests.FantasyTeamRaceEntries.Commands
{
    using static Testing;

    public class UpdateFantasyTeamRaceEntryCommandTests : TestBase
    {
        [Test]
        public async Task ShouldReturnBadrequstWhenRaceEntryAlreadyExists()
        {
            var raceId = await AddRaceAsync("Tour de France");
            var fantasyTeamId = await AddFantasyTeamAsync("Team Outeos");
            await SendAsync(new CreateFantasyTeamRaceEntryCommand(fantasyTeamId, raceId));

            var result = await SendAsync(new CreateFantasyTeamRaceEntryCommand(fantasyTeamId, raceId));

            result.IsBadRequest.Should().BeTrue();
            result.ValidationFailures.Should().ContainPartialErrorForProperty("", "already exists");
        }
    }
}
