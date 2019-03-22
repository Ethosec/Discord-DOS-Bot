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
    public class PSNResolver : ModuleBase<SocketCommandContext>
    {
        [Command("psn")]
        public async Task PSN([Remainder]string psn = "Empty")
        {
            if (psn == "Empty")
            {
                await ReplyAsync("Invalid Usage: d!psn PSN");
            }
            else
            {
                string sURL;
                sURL = "http://127.0.0.1/psn.php?psn=" + psn;
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(sURL);
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                HttpWebResponse response = (HttpWebResponse)wrGETURL.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                await ReplyAsync("IP for "+psn+" : "+responseFromServer);
            }
        }
    }
}
