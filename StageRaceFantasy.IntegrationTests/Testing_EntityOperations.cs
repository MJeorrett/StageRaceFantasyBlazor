using StageRaceFantasy.Application.FantasyTeams.Commands.Create;
using StageRaceFantasy.Application.Races.Commands.Create;
using System.Threading.Tasks;

namespace StageRaceFantasy.IntegrationTests
{
    public partial class Testing
    {
        public static async Task<int> AddRaceAsync(string name)
        {
            var result = await SendAsync(new CreateRaceCommand()
            {
                Name = name,
            });

            return result.Content;
        }

        public static async Task<int> AddFantasyTeamAsync(string name)
        {
            var result = await SendAsync(new CreateFantasyTeamCommand(name));

            return result.Content.Id;
        }
    }
}
