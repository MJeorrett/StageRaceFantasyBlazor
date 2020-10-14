using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.Riders.Commands.Create;
using StageRaceFantasy.IntegrationTests.Assertions;
using StageRaceFantasy.Domain.Entities;
using System.Threading.Tasks;

namespace StageRaceFantasy.IntegrationTests.Riders.Commands
{
    using static Testing;

    public class CreateRiderCommandTests : TestBase
    {
        [Test]
        public async Task ShouldRequireMinimumFields()
        {
            var command = new CreateRiderCommand();

            var result = await SendAsync(command);

            result.IsBadRequest.Should().BeTrue();
            result.ValidationFailures.Should().ContainNotEmptyErrorForProperty(nameof(CreateRiderCommand.FirstName));
            result.ValidationFailures.Should().ContainNotEmptyErrorForProperty(nameof(CreateRiderCommand.LastName));
        }

        [Test]
        public async Task ShouldCreateRider()
        {
            var command = new CreateRiderCommand()
            {
                FirstName = "Marc",
                LastName = "Hirschi",
            };
            var result = await SendAsync(command);

            var rider = await FindAsync<Rider>(result.Content);

            rider.Should().NotBeNull();
            rider.Id.Should().Be(result.Content);
            rider.FirstName.Should().Be("Marc");
            rider.LastName.Should().Be("Hirschi");
        }
    }
}
