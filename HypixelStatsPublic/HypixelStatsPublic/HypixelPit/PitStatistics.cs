using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Leaf.xNet;
using System.Drawing;
using Spectre.Console;
using HypixelStatsPublic.HandlerHelper;
using Colorful;
using System.Linq;
using HypixelStatsPublic.HypixelPit;

namespace HypixelStatsPublic.HypixelPit
{
    public class PitStatistics
    {
        public static int ArrowsHit;
        public static int ArrowsShot;
        public static void GetStatistics(string httpresp)
        {
            try
            {
                // Offensive
                ConcatData.PitKills = Regex.Match(httpresp, "\"§7Kills: §a(.*?)\"").Groups[1].Value;
                ConcatData.PitAssists = Regex.Match(httpresp, "\"§7Assists: §a(.*?)\",").Groups[1].Value;
                ConcatData.PitSwordHits = Regex.Match(httpresp, "\"§7Sword Hits: §a(.*?)\",").Groups[1].Value;
                ConcatData.PitArrowsShot = Regex.Match(httpresp, "\"§7Arrows Shot: §a(.*?)\",").Groups[1].Value;
                ConcatData.PitHighestStreak = Regex.Match(httpresp, ",\"§7Highest Streak: §a(.*?)\"").Groups[1].Value;
                ConcatData.PitArrowsHit = Regex.Match(httpresp, "\"§7Arrows Hit: §a(.*?)\",").Groups[1].Value;
                // Defensive
                ConcatData.PitDeaths = Regex.Match(httpresp, "\"§7Deaths: §a(.*?)\"").Groups[1].Value;
                ConcatData.DamageTk = Regex.Match(httpresp, "\"§7Damage Taken: §a(.*?)\",").Groups[1].Value;
                ConcatData.MeleeDmgTk = Regex.Match(httpresp, "\"§7Melee Damage Taken: §a(.*?)\",").Groups[1].Value;
                ConcatData.BowDmgTk = Regex.Match(httpresp, "\"§7Bow Damage Taken: §a(.*?)\"").Groups[1].Value;
                // Performance
                ConcatData.PitOverallXP = Regex.Match(httpresp, "\"§7XP: §b(.*?)\",").Groups[1].Value;
                ConcatData.XPSlashHour = Regex.Match(httpresp, "\"§7XP/hour: §b(.*?)\",").Groups[1].Value;
                ConcatData.PitGoldOverall = Regex.Match(httpresp, "\"§7Gold Earned: §6(.*?)\",").Groups[1].Value;
                ConcatData.GoldSlashHour = Regex.Match(httpresp, "\"§7Gold/hour: §6(.*?)g\",").Groups[1].Value;
                ConcatData.PitKD = Regex.Match(httpresp, "\"§7K/D: §a(.*?)\",").Groups[1].Value;
                ConcatData.PitKAD = Regex.Match(httpresp, "A/D: §a(.*?)\",").Groups[1].Value;
                ConcatData.KASlashHour = Regex.Match(httpresp, "A/hour: §a(.*?)\",").Groups[1].Value;
                ConcatData.BowAcc = Regex.Match(httpresp, "\"§7Bow Accuracy: §a(.*?)\",").Groups[1].Value;
                ConcatData.ContactsStarted = Regex.Match(httpresp, "\"§7Contracts Started: §a(.*?)\",").Groups[1].Value;
                ConcatData.ContactsCompleted = Regex.Match(httpresp, "\"§7Contracts Completed: §a(.*?)\"").Groups[1].Value;
                // Mystic Stats
                ConcatData.GoldenApplesEaten = Regex.Match(httpresp, "\"§7Golden Apples Eaten: §a(.*?)\"").Groups[1].Value;
                ConcatData.GoldenHeadsEaten = Regex.Match(httpresp, "\"§7Golden Heads Eaten: §a(.*?)\"").Groups[1].Value;
                ConcatData.LavaBucketsEmptied = Regex.Match(httpresp, "\"§7Lava Buckets Emptied: §a(.*?)\"").Groups[1].Value;
                ConcatData.FishingRodsLaunched = Regex.Match(httpresp, "\"§7Fishing Rods Launched: §a(.*?)\"").Groups[1].Value;
                ConcatData.Soups_Drank = Regex.Match(httpresp, "\"§7Soups Drank: §a(.*?)\"").Groups[1].Value;
                ConcatData.t1_Mystics = Regex.Match(httpresp, "\"§7T1 Mystics Enchanted: §a(.*?)\"").Groups[1].Value;
                ConcatData.t2_Mystics = Regex.Match(httpresp, "\"§7T2 Mystics Enchanted: §a(.*?)\"").Groups[1].Value;
                ConcatData.t3_Mystics = Regex.Match(httpresp, "\"§7T3 Mystics Enchanted: §a(.*?)\"").Groups[1].Value;
                ConcatData.DarkPantsCreated = Regex.Match(httpresp, "\"§7Dark Pants Created: §a(.*?)\"").Groups[1].Value;
                // Misc stats
                ConcatData.DiamondItemsPurchased = Regex.Match(httpresp, "\"§7Diamond Items Purchased: §a(.*?)\",").Groups[1].Value;
                ConcatData.ChatMessages = Regex.Match(httpresp, "\"§7Chat messages: §a(.*?)\",").Groups[1].Value;
                ConcatData.DailyTrades = Regex.Match(httpresp, "\"§7Daily Trades: §a(.*?)\",").Groups[1].Value;
                ConcatData.GoldTradeLimit = Regex.Match(httpresp, "\"§7Gold Trade Limit: §6(.*?)\",").Groups[1].Value;
                ConcatData.GenesisPoints = Regex.Match(httpresp, "\"§7Genesis Points: §4(.*?)\"],").Groups[1].Value;
                // Farming Stats
                ConcatData.FishCaught = Regex.Match(httpresp, "\"§7Fished Fish: §a(.*?)\",").Groups[1].Value;
                ConcatData.FishSold = Regex.Match(httpresp, "\"§7Fish Sold: §a(.*?)\",").Groups[1].Value;
                ConcatData.HaybalesSold = Regex.Match(httpresp, "\"§7Hay Bales Sold: §a(.*?)\",").Groups[1].Value;
                ConcatData.KingsQuestCom = Regex.Match(httpresp, "\"§7King's Quest Completions: §a(.*?)\",").Groups[1].Value;
                ConcatData.SewerTreasuresFound = Regex.Match(httpresp, "\"§7Sewer Treasures Found: §a(.*?)\",").Groups[1].Value;
                ConcatData.NightQuestsCom = Regex.Match(httpresp, "\"§7Night Quests Completed: §a(.*?)\"").Groups[1].Value;
                // Prestige
                ConcatData.Prestige = Regex.Match(httpresp, "\"§7Prestige: §a(.*?)\",").Groups[1].Value;
                ConcatData.CurrentRenown = Regex.Match(httpresp, "\"§7Current Renown: §a(.*?)\",").Groups[1].Value;
                ConcatData.LifetimeRenown = Regex.Match(httpresp, "\"§7Lifetime Renown: §a(.*?)\",").Groups[1].Value;
                ConcatData.RenownCompletion = Regex.Match(httpresp, "\"§7Renown Shop Completion: §a(.*?)\"").Groups[1].Value;
            }
            catch(Exception ex)
            {
                Colorful.Console.WriteLine("ERROR: " + ex);
            }
        }
    }
}
