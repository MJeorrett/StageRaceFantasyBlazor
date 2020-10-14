using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.Riders.Queries.GetById;
using System.Threading.Tasks;

namespace StageRaceFantasy.IntegrationTests.Riders.Queries
{
    using static Testing;

    public class GetRiderByIdQueryTests : TestBase
    {
        [Test]
        public async Task ShouldReturnNotFound()
        {
            var result = await SendAsync(new GetRiderByIdQuery(123));

            result.IsNotFound.Should().BeTrue();
        }
    }
}
