using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace StageRaceFantasy.Application.IntegrationTests.Common
{
    public class AutoMapperProfilesTests
    {
        [Test]
        public void ConfigurationShouldBeValid()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddApplication();

            var mapper = serviceCollection.BuildServiceProvider().GetRequiredService<IMapper>();

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
