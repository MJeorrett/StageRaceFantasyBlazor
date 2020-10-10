﻿using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.RaceStages.Commands.Create;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.IntegrationTests.RaceStages.Commands
{
    using static Testing;

    public class CreateRaceStageCommandTests : TestBase
    {
        [Test]
        public async Task ShouldRequireFields()
        {
            var command = new CreateRaceStageCommand();

            var result = await SendAsync(command);

            result.IsBadRequest.Should().BeTrue();
            result.ValidationFailures[nameof(CreateRaceStageCommand.RaceId)].Should().Contain(x => x.Contains("must not be empty"));
            result.ValidationFailures[nameof(CreateRaceStageCommand.StartLocation)].Should().Contain(x => x.Contains("must not be empty"));
            result.ValidationFailures[nameof(CreateRaceStageCommand.FinishLocation)].Should().Contain(x => x.Contains("must not be empty"));
        }
    }
}
