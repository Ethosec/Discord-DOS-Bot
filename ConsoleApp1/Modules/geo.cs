using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Modules
{
    public class GEOLoc : ModuleBase<SocketCommandContext>
    {
        [Command("geo")]
        public async Task GeoLoc([Remainder]string IP = "Empty")
        {
            if (IP == "Empty")
            {
                await ReplyAsync("Invalid Usage: d!portscan 1.3.3.7");
            }
            else
            {
                string sURL;
                sURL = "http://127.0.0.1/geo.php?target=" + IP;
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
                await ReplyAsync("\t - Brought to you by DevilsExploits");
            }
        }
    }
}
