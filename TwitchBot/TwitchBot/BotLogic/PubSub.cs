using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;
using AutoIt;
using TwitchBot.Models;
using TwitchBot;

namespace TwitchBot.BotLogic
{
    class PubSub
    {
        private static TwitchPubSub client;
        private static List<SpawnMonsterModel> spawnMonsterModelList;
        private static CredentialsModel authDetails;

        public PubSub(CredentialsModel _authDetails)
        {
            authDetails = _authDetails;
            spawnMonsterModelList = Startup.GetMonstersSpawnInputList();
            client = new TwitchPubSub();
            
            client.OnPubSubServiceConnected += Client_OnPubSubServiceConnected;
            client.OnListenResponse += Client_OnListenResponse;
            client.OnStreamUp += Client_OnStreamUp;
            client.OnStreamDown += Client_OnStreamDown;
            client.OnLog += Client_OnLog;
            client.OnChannelPointsRewardRedeemed += Client_OnChannelPointsRewardRedeemed;
            client.ListenToChannelPoints(authDetails.UserId);
            client.ListenToVideoPlayback(authDetails.UserId);

            client.Connect();

            Console.Read();
        }

        private void Client_OnChannelPointsRewardRedeemed(object sender, OnChannelPointsRewardRedeemedArgs e)
        {
            AutoItX.Send(spawnMonsterModelList.Find(x => x.TwitchRewardTitle == e.RewardRedeemed.Redemption.Reward.Title).KeyboardInputToSimulate);
        }

        private static void Client_OnLog(object sender, TwitchLib.PubSub.Events.OnLogArgs e)
        {
            Console.WriteLine(e.Data);
        }

        private static void Client_OnPubSubServiceConnected(object sender, EventArgs e)
        {
            Console.WriteLine(e);
            // SendTopics accepts an oauth optionally, which is necessary for some topics
            client.SendTopics(authDetails.Oauth);
        }

        private static void Client_OnListenResponse(object sender, OnListenResponseArgs e)
        {
            Console.WriteLine(e);
            if (!e.Successful)
                Console.WriteLine(e);
        }

        private static void Client_OnStreamUp(object sender, OnStreamUpArgs e)
        {
            Console.WriteLine($"Stream just went up! Play delay: {e.PlayDelay}, server time: {e.ServerTime}");
        }

        private static void Client_OnStreamDown(object sender, OnStreamDownArgs e)
        {
            Console.WriteLine($"Stream just went down! Server time: {e.ServerTime} and id:  {e.ChannelId}");
        }
    }
}
