using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot.Models
{
    public class CredentialsModel
    {
        public string Oauth { get; set; }
        public string ChannelName { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
    }
}
