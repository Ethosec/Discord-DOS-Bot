using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.Net.NetworkInformation;

namespace ConsoleApp1.Modules
{
    public class Ping2 : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task PingAsync([Remainder]string Input = "Empty")
        {
            if (Input == "Empty")
            {
                await ReplyAsync("Invalid Usage: d!ping 1.3.3.7");
            }
            else
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(Input, 1000);
            

                if (reply.Status.ToString().Equals("Success"))
                {
                    await ReplyAsync(Input+" Returned 5 Packets [HOST ONLINE]");
                }
                else {
                    await ReplyAsync(Input+ " Returned 0 Packets [HOST OFFLINE]");
                }
            }
        }
    }
}
