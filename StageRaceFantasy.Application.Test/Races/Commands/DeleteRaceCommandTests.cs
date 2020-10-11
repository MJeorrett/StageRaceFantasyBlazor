using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.Races.Commands.Create;
using StageRaceFantasy.Application.Races.Commands.Delete;
using StageRaceFantasy.Domain.Entities;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.IntegrationTests.Races.Commands
{
    using static Testing;

    public class DeleteRaceCommandTests : TestBase
    {
        [Test]
        public async Task ShouldReturnNotFound()
        {
            var result = await SendAsync(new DeleteRaceCommand(123));

            result.IsNotFound.Should().BeTrue();
        }

        [Test]
        public async Task ShouldDeleteRace()
        {
            var createResult = await SendAsync(new CreateRaceCommand() { Name = "Tour 2020" });

            await SendAsync(new DeleteRaceCommand(createResult.Content));

            var race = await FindAsync<Race>(createResult.Content);

            race.Should().BeNull();
        }
    }
}
