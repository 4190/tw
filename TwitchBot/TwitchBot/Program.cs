using TwitchBot;
using TwitchBot.BotLogic;
using TwitchBot.Models;
using Newtonsoft.Json;
using System.IO;

namespace TwitchLibPubSubExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var authDetails = Startup.GetCredentials();
            ChatBot bot = new ChatBot(authDetails);
            PubSub pub = new PubSub(authDetails);
        }
    }
}