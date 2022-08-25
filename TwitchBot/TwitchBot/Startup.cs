using TwitchBot.Models;
using Newtonsoft.Json;

namespace TwitchBot
{
    internal class Startup
    {
        public static List<SpawnMonsterModel> GetMonstersSpawnInputList()
        {
            return JsonConvert.DeserializeObject<List<SpawnMonsterModel>>(File.ReadAllText("Configs/monsterSpawnInputs.json"));
        }

        public static CredentialsModel GetCredentials()
        {
            return JsonConvert.DeserializeObject<CredentialsModel>(File.ReadAllText("Configs/credentials.json"));
        }
    }
}
