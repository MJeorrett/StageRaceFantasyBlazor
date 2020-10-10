using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.Races.Commands.Create;
using StageRaceFantasy.Domain.Entities;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.IntegrationTests.Races.Commands
{
    using static Testing;

    public class CreateRaceCommandTests : TestBase
    {
        [Test]
        public async Task ShouldRequireMinimumFields()
        {
            var command = new CreateRaceCommand();

            var result = await SendAsync(command);

            result.IsBadRequest.Should().BeTrue();
            result.ValidationFailures[nameof(CreateRaceCommand.Name)].Should().Contain(x => x.Contains(ValidationMessageFragments.NotEmpty));
        }

        [Test]
        public async Task ShouldCreateRace()
        {
            var command = new CreateRaceCommand()
            {
                Name = "Tour de France 2020",
            };

            var result = await SendAsync(command);

            var race = await FindAsync<Race>(result.Content);

            race.Should().NotBeNull();
            race.Name.Should().Be("Tour de France 2020");
        }
    }
}
