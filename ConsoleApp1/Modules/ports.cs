using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.Net.NetworkInformation;
using Discord;
using System.Net;
using System.IO;

namespace ConsoleApp1.Modules
{
    public class Ports : ModuleBase<SocketCommandContext>
    {
        [Command("portscan")]
        public async Task Portscan([Remainder]string IP = "Empty")
        {
        if(IP == "Empty")
            {
                await ReplyAsync("Invalid Usage: d!portscan 1.3.3.7");
            }
            else {
                string sURL;
                sURL = "http://127.0.0.1/nmap.php?target=" + IP;
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(sURL);
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                HttpWebResponse response = (HttpWebResponse)wrGETURL.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                await ReplyAsync(responseFromServer);
                await ReplyAsync("- Brought to you by DevilsExploits");
                EmbedBuilder Portscan = new EmbedBuilder();
            }
        }
    }
}
