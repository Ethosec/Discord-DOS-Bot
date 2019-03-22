using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.Net.NetworkInformation;
using Discord;

namespace ConsoleApp1.Modules
{
    public class HELP : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task help([Remainder]string Input = "Empty")
        {
                EmbedBuilder Portscan = new EmbedBuilder();
                Portscan.WithAuthor("");
                Portscan.WithColor(40, 200, 150);
                Portscan.WithFooter(" - Brought to You by DevilsExploits ");
                Portscan.WithDescription("**PING** : d!ping 1.3.3.7 | Ping\n\n**DDOS** d!ddos 1.3.3.7 80 60 [HOME/VPN] | SLAMMER\n\n**STOP** : d!ddosstop 1.3.3.7 | STOP\n\n**PORTSCAN**: d!portscan 1.3.3.7 | Port Scanner\n\n\n");

                await Context.Channel.SendMessageAsync("", false, Portscan.Build());
        }
    }
}
