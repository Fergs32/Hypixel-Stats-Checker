using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Leaf.xNet;
using HypixelStatsPublic.HandlerHelper;

namespace HypixelStatsPublic.HypixelMain
{
    public class BedwarsAPI
    {
        public static string UUID { get; set; }

        public static int Coins;
        public static int EXP;

        // Bedwars statistics

        public static int Kills;
        public static int Wins;
        public static int BedsBroken;
        public static int FinalKills;
        public static int Losses;
        public static int Deaths;
        public static int BedsLost;
        public static int FinalDeaths;

        //

        public static int GamesPlayed;
        public static double Winrate;
        public static double KD;
        public static double FKDR;

        public static void GetUUID(string IGN)
        {
            try
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.0.0 Safari/537.36";
                    Leaf.xNet.HttpResponse httpResponse = httpRequest.Get(new Uri("https://playerdb.co/api/player/minecraft/" + IGN));
                    string input = httpResponse.StatusCode < Leaf.xNet.HttpStatusCode.BadGateway ? httpResponse.ToString() : throw new Exception("Banned IP / Incorrect IGN");

                    if (input.Contains("player.found") || input.Contains("Successfully"))
                    {
                        UUID = Regex.Match(input, "\"raw_id\":\"(.*?)\",").Groups[1].Value;
                    } else
                    {
                        throw new Exception("Invalid server response");
                    }
                    httpRequest.Dispose();
                }
                using (HttpRequest httpRequest1 = new HttpRequest())
                {
                    httpRequest1.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.0.0 Safari/537.36";
                    Leaf.xNet.HttpResponse resp = httpRequest1.Get(new Uri("https://bedwarstats.com/.netlify/functions/fetch-hypixel?uuid=" + UUID));
                    string input1 = resp.StatusCode < HttpStatusCode.BadGateway ? resp.ToString() : throw new Exception("Banned IP / Incorrect UUID");
                    
                    if (input1.Contains("\"success\"") || input1.Contains("achievementsOneTime"))
                    {
                        /*
                         *  Main Information
                         */
                        string BedwarsCoins = Regex.Match(input1, "\"coins\":(.*?),").Groups[1].Value;
                        Int32.TryParse(BedwarsCoins, out Coins);
                        ConcatData.BedwarsCoins = string.Format("{0:n0}", Coins);
                        ConcatData.BedwarsLevel = Regex.Match(input1, "\"bedwars_level\":(.*?),").Groups[1].Value;
                        string BedwarsEXP = Regex.Match(input1, "\"Experience\":(.*?),").Groups[1].Value;
                        Int32.TryParse(BedwarsEXP, out EXP);
                        ConcatData.BedwarsEXP = string.Format("{0:n0}", EXP);
                        /*
                         *  Overall Statistics
                         */
                        string BedwarsKills = Regex.Match(input1, "\"kills_bedwars\":(.*?),").Groups[1].Value;
                        Int32.TryParse(BedwarsKills, out Kills);
                        ConcatData.BedwarsKills = string.Format("{0:n0}", Kills);

                        string BedwarsWins = Regex.Match(input1, "\"wins_bedwars\":(.*?),").Groups[1].Value;
                        Int32.TryParse(BedwarsWins, out Wins);
                        ConcatData.BedwarsWins = string.Format("{0:n0}", Wins);

                        string BedwarsBedsBroken = Regex.Match(input1, "\"beds_broken_bedwars\":(.*?),").Groups[1].Value;
                        Int32.TryParse(BedwarsBedsBroken, out BedsBroken);
                        ConcatData.BedwarsBedsBroken = string.Format("{0:n0}", BedsBroken);

                        string BedwarsFinalKills = Regex.Match(input1, "\"final_kills_bedwars\":(.*?),").Groups[1].Value;
                        Int32.TryParse(BedwarsFinalKills, out FinalKills);
                        ConcatData.BedwarsFinalKills = string.Format("{0:n0}", FinalKills);

                        string BedwarsLosses = Regex.Match(input1, "\"losses_bedwars\":(.*?),").Groups[1].Value;
                        Int32.TryParse(BedwarsLosses, out Losses);
                        ConcatData.BedwarsLoses = string.Format("{0:n0}", Losses);

                        string BedwarsDeaths = Regex.Match(input1, "\"deaths_bedwars\":(.*?),").Groups[1].Value;
                        Int32.TryParse(BedwarsDeaths, out Deaths);
                        ConcatData.BedwarsDeaths = string.Format("{0:n0}", Deaths);

                        string BedwarsBedsLost = Regex.Match(input1, "\"beds_lost_bedwars\":(.*?),").Groups[1].Value;
                        Int32.TryParse(BedwarsBedsLost, out BedsLost);
                        ConcatData.BedwarsBedsLost = string.Format("{0:n0}", BedsLost);

                        string BedwarsFinalDeaths = Regex.Match(input1, "\"final_deaths_bedwars\":(.*?),").Groups[1].Value;
                        Int32.TryParse(BedwarsFinalDeaths, out FinalDeaths);
                        ConcatData.BedwarsFinalDeaths = string.Format("{0:n0}", FinalDeaths);

                        string BedwarsGamesPlayed = Regex.Match(input1, "\"games_played_bedwars\":(.*?),").Groups[1].Value;
                        Int32.TryParse(BedwarsGamesPlayed, out GamesPlayed);
                        ConcatData.BedwarsGamesPlayed = string.Format("{0:n0}", GamesPlayed);

                        //

                        Winrate = (double)Wins / (double)GamesPlayed * 100;
                        ConcatData.BedwarsWinRate = string.Format("{0:0.##}", Winrate);

                        KD = (double)Kills / (double)Deaths;
                        ConcatData.BedwarsKD = string.Format("{0:0.##}", KD);

                        FKDR = (double)FinalKills / (double)FinalDeaths;
                        ConcatData.BedwarsFKDR = string.Format("{0:0.##}", FKDR);
                    }
                }
            }
            catch (HttpException ex)
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
