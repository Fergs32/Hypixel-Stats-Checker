using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using Leaf.xNet;
using System.Threading;
using System.Drawing;
using Colorful;
using HypixelStatsPublic.HandlerHelper;

namespace HypixelStatsPublic.HypixelMain
{
    public class HypixelStatsMain
    {
        public static string Result = "";
        public static int KarmaInt;
        public static int EXPInt;

        public static void GetPlayerStats()
        {
            System.Console.Clear();
            AsciiText.DrawLogo();
            System.Console.WriteLine();
            try
            {
                Colorful.Console.Write("[+] IGN: ", Color.White);
                Result = System.Console.ReadLine();
            } catch(Exception ex) { Colorful.Console.WriteLine(ex); }

            try
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.0.0 Safari/537.36";
                    httpRequest.AddHeader(HttpHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                    httpRequest.AddHeader(HttpHeader.ContentType, "application/json");

                    Leaf.xNet.HttpResponse Resp = httpRequest.Get(new Uri("https://api.slothpixel.me/api/players/" + Result), null);
                    string input = Resp.StatusCode < Leaf.xNet.HttpStatusCode.BadGateway ? Resp.ToString() : throw new Exception("Banned IP");
                    if (input.Contains("\"uuid\"") || input.Contains("\"karma\""))
                    {
                        string Rank = Regex.Match(input, "\"rank\":\"(.*?)\",").Groups[1].Value;
                        PrefixFormatter.PrefixFormat(Rank);
                        ConcatData.Online = Regex.Match(input, "\"online\":(.*?),").Groups[1].Value;
                        string Karma = Regex.Match(input, "\"karma\":\"([0-9]*?)\",").Groups[1].Value;
                        Int32.TryParse(Karma, out KarmaInt);
                        ConcatData.Karma = string.Format("{0:n0}", KarmaInt);
                        string EXP = Regex.Match(input, "\"exp\":([0-9]*?),").Groups[1].Value;
                        Int32.TryParse(EXP, out EXPInt);
                        ConcatData.EXP = string.Format("{0:n0}", EXPInt);
                        ConcatData.Level = Regex.Match(input, "\"level\":(.*?)\"").Groups[1].Value.Replace(",", "");
                        ConcatData.AchievementPoints = Regex.Match(input, "\"achievement_points\":([0-9]*?),").Groups[1].Value;
                        ConcatData.QuestsCompleted = Regex.Match(input, "\"quests_completed\":([0-9]*?),").Groups[1].Value;
                        ConcatData.LastGamePlayed = Regex.Match(input, "\"last_game\":\"(.*?)\",").Groups[1].Value;
                    }
                    httpRequest.Dispose();
                }
                try
                {
                    BedwarsAPI.GetUUID(Result);
                }
                catch (Exception ex) { Colorful.Console.WriteLine(ex); }
                var DisplayData = new string[]
                {
                    "\n\t\t[IGN: " + Result + "]\t[Online: " + ConcatData.Online + "]\n\n",
                    "[ General Information ]\n",
                    "[+] Rank: " + ConcatData.Rank,
                    "[+] Karma: " + ConcatData.Karma,
                    "[+] EXP: " + ConcatData.EXP,
                    "[+] Level: " + ConcatData.Level,
                    "[+] Achievement Points: " + ConcatData.AchievementPoints,
                    "[+] Quests Completed: " + ConcatData.QuestsCompleted,
                    "[+] Last Game: " + ConcatData.LastGamePlayed,
                    "\n[ BedWars Information ]\n",
                    "[+] Coins: " + ConcatData.BedwarsCoins,
                    "[+] EXP: " + ConcatData.BedwarsEXP,
                    "[+] Level: " + ConcatData.BedwarsLevel,
                    "-----------------------",
                    "[+] Wins: " + ConcatData.BedwarsWins,
                    "[+] Kills: " + ConcatData.BedwarsKills,
                    "[+] Beds Broken: " + ConcatData.BedwarsBedsBroken,
                    "[+] Final Kills: " + ConcatData.BedwarsFinalKills,
                    "[+] Losses: " + ConcatData.BedwarsLoses,
                    "[+] Deaths: " + ConcatData.BedwarsDeaths,
                    "[+] Beds Lost: " + ConcatData.BedwarsBedsLost,
                    "[+] Final Deaths: " + ConcatData.BedwarsFinalDeaths,
                    "-----------------------",
                    "[+] Win Rate: " + ConcatData.BedwarsWinRate + "%",
                    "[+] KD: " + ConcatData.BedwarsKD,
                    "[+] FKDR: " + ConcatData.BedwarsFKDR,
                    "[+] Games Played: " + ConcatData.BedwarsGamesPlayed,
                };

                System.Console.Clear();
                AsciiText.DrawLogo();
                foreach(string line in DisplayData)
                {
                    Colorful.Console.WriteLine(line, Color.Aqua);
                    Thread.Sleep(100);
                }
                Program.BacktoMenu();
            }
            catch(HttpException ex)
            {
                Colorful.Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Colorful.Console.WriteLine(ex);
            }

        }
    }
}
