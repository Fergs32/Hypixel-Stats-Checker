using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Leaf.xNet;
using System.Drawing;
using Spectre.Console;
using HypixelStatsPublic.HandlerHelper;
using Colorful;
using HypixelStatsPublic.SpectreConsole;
using System.Linq;

namespace HypixelStatsPublic.HypixelPit
{
    public class HypixelPitStats
    {
        public static List<string> ActivePerks = new List<string>().ToList<string>();
        public static string Result = "";
        public static void GetPlayerStats()
        {
            System.Console.Clear();
            AsciiText.DrawLogo();
            System.Console.WriteLine();
            try
            {
                Colorful.Console.Write("[+] IGN: ", System.Drawing.Color.White);
                Result = System.Console.ReadLine();
            }
            catch (Exception ex) { Colorful.Console.WriteLine(ex); }

            LoadingStatus.GG2(Result);
            try
            {              
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.0.0 Safari/537.36";
                    Leaf.xNet.HttpResponse resp = httpRequest.Get("https://pitpanda.rocks/api/players/" + Result);
                    string input1 = resp.StatusCode < HttpStatusCode.BadGateway ? resp.ToString() : throw new Exception("Bad API request");

                    if (input1.Contains("\"success\":true,"))
                    {
                        ConcatData.PrestigeXP = Regex.Match(input1, "\"description\":\"(.*?)\"},\"goldProgress").Groups[1].Value.Replace("null", "");
                        ConcatData.Reknown = Regex.Match(input1, "\"description\":\"([0-9/]*?)\"},\"doc").Groups[1].Value.Replace("null", "");
                        ConcatData.PitLevel = Regex.Match(input1, "formattedLevel\":\"§[A-Za-z0-9]{1}\\[§[A-Za-z0-9]{1}(.*?)§[A-Za-z0-9]{1}§[A-Za-z0-9]{1}]").Groups[1].Value.Replace("null", "").Replace("§", "");
                        ConcatData.PitGold = Regex.Match(input1, "\"currentGold\":(.*?),").Groups[1].Value.Replace("null", "");
                        ConcatData.PitPT = Regex.Match(input1, "\"§7Playtime: §a(.*?)\",").Groups[1].Value;
                        SetPitStats.GetPerks(input1); SetPitStats.GetKillstreaks(input1); SetPitStats.GetBoosts(input1); PitStatistics.GetStatistics(input1); SetPitStats.RemoveUselessText();
                        DrawRoot();
                    }
                    else
                    {
                        System.Console.WriteLine("[API Error] Bad API request or incorrect username.");
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
        public static void DrawRoot()
        {
            try
            {
                System.Console.Clear();
                AsciiText.DrawLogo();
                System.Console.Write("\n\n");
                // Root name
                var root = new Tree("[red]" + Result + "[/]");

                // Add some nodes
                var foo = root.AddNode("[white]General[/]");
                var table = foo.AddNode(new Table()
                    .RoundedBorder()
                    .BorderColor(Spectre.Console.Color.HotPink)
                    .AddColumn("[gold3_1]Gold[/]")
                    .AddColumn("[aqua]Level[/]")
                    .AddColumn("[mediumpurple2]Reknown[/]")
                    .AddColumn("[aqua]Prestige XP[/]")
                    .AddColumn("[white]Playtime[/]")
                    .AddRow("[gold3_1]" + ConcatData.PitGold + "[/]", "[aqua]" + ConcatData.PitLevel + "[/]", "[mediumpurple2]" + ConcatData.Reknown + "[/]", "[aqua]" + ConcatData.PrestigeXP + "[/]", "[white]" + ConcatData.PitPT + "[/]"));

                var perks = table.AddNode(new Table()
                     .RoundedBorder()
                     .BorderColor(Spectre.Console.Color.HotPink)
                    .AddColumn("[dodgerblue2]Perk 1[/]")
                    .AddColumn("[dodgerblue2]Perk 2[/]")
                    .AddColumn("[dodgerblue2]Perk 3[/]")
                    .AddColumn("[dodgerblue2]Perk 4[/]")
                    .AddRow("[dodgerblue2]" + ConcatData.Perk1 + "[/]", "[dodgerblue2]" + ConcatData.Perk2 + "[/]", "[dodgerblue2]" + ConcatData.Perk3 + "[/]", "[dodgerblue2]" + ConcatData.Perk4 + "[/]"));

                var Killstreaks = perks.AddNode(new Table()
                    .RoundedBorder()
                    .BorderColor(Spectre.Console.Color.HotPink)
                    .AddColumn("[dodgerblue2]Killstreak 1[/]")
                    .AddColumn("[dodgerblue2]Killstreak 2[/]")
                    .AddColumn("[dodgerblue2]Killstreak 3[/]")
                    .AddColumn("[dodgerblue2]Killstreak 4[/]")
                    .AddRow("[dodgerblue2]" + ConcatData.Killstreak1 + "[/]", "[dodgerblue2]" + ConcatData.Killstreak2 + "[/]", "[dodgerblue2]" + ConcatData.Killstreak3 + "[/]", "[dodgerblue2]" + ConcatData.Killstreak4 + "[/]"));

                var Boosts = Killstreaks.AddNode(new Table()
                    .RoundedBorder()
                    .BorderColor(Spectre.Console.Color.HotPink)
                    .AddColumn("[dodgerblue2]Boost 1[/]")
                    .AddColumn("[dodgerblue2]Boost 2[/]")
                    .AddColumn("[dodgerblue2]Boost 3[/]")
                    .AddColumn("[dodgerblue2]Boost 4[/]")
                    .AddColumn("[dodgerblue2]Boost 5[/]")
                    .AddColumn("[dodgerblue2]Boost 6[/]")
                    .AddColumn("[dodgerblue2]Boost 7[/]")
                    .AddRow("[dodgerblue2]" + ConcatData.Boost1 + "[/]", "[dodgerblue2]" + ConcatData.Boost2 + "[/]", "[dodgerblue2]" + ConcatData.Boost3 + "[/]", "[dodgerblue2]" + ConcatData.Boost4 + "[/]", "[dodgerblue2]" + ConcatData.Boost5 + "[/]", "[dodgerblue2]" + ConcatData.Boost6 + "[/]", "[dodgerblue2]" + ConcatData.Boost7 + "[/]"));

                var stats = root.AddNode("[white]Statistics[/]");

                var offensiveStats = stats.AddNode("[indianred1]Offensive[/]");
                var offensiveTable = offensiveStats.AddNode(new Table()
                    .RoundedBorder()
                    .BorderColor(Spectre.Console.Color.HotPink)
                    .AddColumn("Kills")
                    .AddColumn("Assists")
                    .AddColumn("Sword Hits")
                    .AddColumn("Arrows Hit")
                    .AddColumn("Highest Streak")
                    .AddRow("[green1]" + ConcatData.PitKills + "[/]", "[green1]" + ConcatData.PitAssists + "[/]", "[green1]" + ConcatData.PitSwordHits + "[/]", "[green1]" + ConcatData.PitArrowsHit + "[/]", "[green1]" + ConcatData.PitHighestStreak + "[/]"));

                var defensiveStats = stats.AddNode("[blue1]Defensive[/]");
                var defensiveTable = defensiveStats.AddNode(new Table()
                    .RoundedBorder()
                    .BorderColor(Spectre.Console.Color.HotPink)
                    .AddColumn("Deaths")
                    .AddColumn("Damage Taken")
                    .AddColumn("Melee Dmg Taken")
                    .AddColumn("Bow Dmg Taken")
                    .AddRow("[green1]" + ConcatData.PitDeaths + "[/]", "[green1]" + ConcatData.DamageTk + "[/]", "[green1]" + ConcatData.MeleeDmgTk + "[/]", "[green1]" + ConcatData.BowDmgTk + "[/]"));

                var performanceStats = stats.AddNode("[yellow1]Performance[/]");
                var performanceTable = performanceStats.AddNode(new Table()
                    .RoundedBorder()
                    .BorderColor(Spectre.Console.Color.HotPink)
                    .AddColumn("XP")
                    .AddColumn("XP/hour")
                    .AddColumn("Gold Earned")
                    .AddColumn("Gold/hour")
                    .AddColumn("KD")
                    .AddColumn("K+A/D")
                    .AddColumn("K+A/hour")
                    .AddColumn("Bow Accuracy")
                    .AddColumn("Contracts Started")
                    .AddColumn("Contracts Completed")
                    .AddRow("[aqua]" + ConcatData.PitOverallXP + "[/]", "[aqua]" + ConcatData.XPSlashHour + "[/]", "[gold3_1]" + ConcatData.PitGoldOverall + "[/]", "[gold3_1]" + ConcatData.GoldSlashHour + "[/]", "[green1]" + ConcatData.PitKD + "[/]", "[green1]" + ConcatData.PitKAD + "[/]", "[green1]" + ConcatData.KASlashHour + "[/]", "[green1]" + ConcatData.BowAcc + "[/]", "[green1]" + ConcatData.ContactsStarted + "[/]", "[green1]" + ConcatData.ContactsCompleted + "[/]"));

                var mythicStats = stats.AddNode("[green1]Perk/Mythic Stats[/]");
                var mythicTable = mythicStats.AddNode(new Table()
                    .RoundedBorder()
                    .BorderColor(Spectre.Console.Color.HotPink)
                    .AddColumn("Apples Eaten")
                    .AddColumn("Heads Eaten")
                    .AddColumn("Lava Buckets Emptied")
                    .AddColumn("Fishing Rods Launched")
                    .AddColumn("Soups Drank")
                    .AddColumn("T1 Mystics Enchanted")
                    .AddColumn("T2 Mystics Enchanted")
                    .AddColumn("T3 Mystics Enchanted")
                    .AddColumn("Dark Pants Created")
                    .AddRow("[green1]" + ConcatData.GoldenApplesEaten + "[/]", "[green1]" + ConcatData.GoldenHeadsEaten + "[/]", "[green1]" + ConcatData.LavaBucketsEmptied + "[/]", "[green1]" + ConcatData.FishingRodsLaunched + "[/]", "[green1]" + ConcatData.Soups_Drank + "[/]", "[green1]" + ConcatData.t1_Mystics + "[/]", "[green1]" + ConcatData.t2_Mystics + "[/]", "[green1]" + ConcatData.t3_Mystics + "[/]", "[green1]" + ConcatData.DarkPantsCreated + "[/]"));

                var miscStats = stats.AddNode("[hotpink_1]Miscellaneous[/]");
                var miscTable = miscStats.AddNode(new Table()
                    .RoundedBorder()
                    .BorderColor(Spectre.Console.Color.HotPink)
                    .AddColumn("Diamond Items Purchased")
                    .AddColumn("Chat Messages")
                    .AddColumn("Daily Trades")
                    .AddColumn("Gold Trade Limit")
                    .AddColumn("Genesis Points")
                    .AddColumn("Playtime")
                    .AddRow("[green1]" + ConcatData.DiamondItemsPurchased + "[/]", "[green1]" + ConcatData.ChatMessages + "[/]", "[green1]" + ConcatData.DailyTrades + "[/]", "[gold3_1]" + ConcatData.GoldTradeLimit + "[/]", "[darkred_1]" + ConcatData.GenesisPoints + "[/]", "[green1]" + ConcatData.PitPT + "[/]"));

                var farmingStats = stats.AddNode("[green1]Farming[/]");
                var farmingTable = farmingStats.AddNode(new Table()
                    .RoundedBorder()
                    .BorderColor(Spectre.Console.Color.HotPink)
                    .AddColumn("Fish Caught")
                    .AddColumn("Fish Sold")
                    .AddColumn("HayBales Sold")
                    .AddColumn("King's Quest Completions")
                    .AddColumn("Sewer Treasure's Found")
                    .AddColumn("Night Quests Completion")
                    .AddRow("[green1]" + ConcatData.FishCaught + "[/]", "[green1]" + ConcatData.FishSold + "[/]", "[green1]" + ConcatData.HaybalesSold + "[/]", "[green1]" + ConcatData.KingsQuestCom + "[/]", "[green1]" + ConcatData.SewerTreasuresFound + "[/]", "[green1]" + ConcatData.NightQuestsCom + "[/]"));

                var prestigeStats = stats.AddNode("[aqua]Prestige[/]");
                var prestigeTable = prestigeStats.AddNode(new Table()
                    .RoundedBorder()
                    .BorderColor(Spectre.Console.Color.HotPink)
                    .AddColumn("Prestige")
                    .AddColumn("Current Renown")
                    .AddColumn("Lifetime Renown")
                    .AddColumn("Renown Completion")
                    .AddRow("[green1]" + ConcatData.Prestige + "[/]", "[green1]" + ConcatData.CurrentRenown + "[/]", "[green1]" + ConcatData.LifetimeRenown + "[/]", "[green1]" + ConcatData.RenownCompletion + "[/]"));
                // Render the tree
                AnsiConsole.Write(root);
                Program.BacktoMenu();
            }
            catch (Exception ex)
            {
                Colorful.Console.WriteLine(ex);
            }

        } 
    }
}

