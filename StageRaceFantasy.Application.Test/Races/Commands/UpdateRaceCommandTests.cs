using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.Races.Commands.Create;
using StageRaceFantasy.Application.Races.Commands.Update;
using StageRaceFantasy.Application.IntegrationTests.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.IntegrationTests.Races.Commands
{
    using static Testing;

    public class UpdateRaceCommandTests : TestBase
    {
        [Test]
        public async Task ShouldReturnNotFoundWhenRaceDoesNotExist()
        {
            var result = await SendAsync(new UpdateRaceCommand()
            {
                Id = 123,
                Name = "Vuelta '04",
            });

            result.IsNotFound.Should().BeTrue();
        }

        [Test]
        public async Task ShouldRequireMinimumFields()
        {
            var createResult = await SendAsync(new CreateRaceCommand()
            {
                Name = "Giro 2020",
            });

            var result = await SendAsync(new UpdateRaceCommand()
            {
                Id = createResult.Content,
                Name = "",
            });

            result.IsBadRequest.Should().BeTrue();
            result.ValidationFailures.Should().ContainNotEmptyErrorForProperty(nameof(UpdateRaceCommand.Name));
        }

        [Test]
        public async Task ShouldUpdateRace()
        {
            var raceId = await AddAsync(new Race()
            {
                Name = "Original Name",
                FantasyTeamSize = 8,
            });

            var result = await SendAsync(new UpdateRaceCommand()
            {
                Id = raceId,
                Name = "Updated Name",
                FantasyTeamSize = 9,
            });

            var race = await FindAsync<Race>(raceId);

            race.Name.Should().Be("Updated Name");
            race.FantasyTeamSize.Should().Be(9);
        }
    }
}
