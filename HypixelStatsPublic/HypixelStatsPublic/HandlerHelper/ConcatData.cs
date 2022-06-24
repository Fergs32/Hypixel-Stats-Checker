using System;
using System.Collections.Generic;
using System.Text;

namespace HypixelStatsPublic.HandlerHelper
{
    public class ConcatData
    {
        public static void DataRemove()
        {

        }
        // Basic information on player
        public static string Rank { get; set; }
        public static string Online { get; set; }
        public static string Karma { get; set; }
        public static string EXP { get; set; }
        public static string Level { get; set; }
        public static string AchievementPoints { get; set; }
        public static string QuestsCompleted { get; set; }
        public static string LastGamePlayed { get; set; }

        // Bedwars

        // Overall bedwars information
        public static string BedwarsKills { get; set; }
        public static string BedwarsBedsBroken { get; set; }
        public static string BedwarsWins { get; set; }
        public static string BedwarsFinalKills { get; set; }
        public static string BedwarsLoses { get; set; }
        public static string BedwarsFinalDeaths { get; set; }
        public static string BedwarsDeaths { get; set; }
        public static string BedwarsBedsLost { get; set; }

        // Statistics
        public static string BedwarsWinRate { get; set; }
        public static string BedwarsKD { get; set; }
        public static string BedwarsFKDR { get; set; }
        public static string BedwarsGamesPlayed { get; set; }

        // General bedwars information
        public static string BedwarsCoins { get; set; }
        public static string BedwarsLevel { get; set; }
        public static string BedwarsEXP { get; set; }
        /*
         * Pit Global Variables
         */
        public static string PitGold { get; set; }
        public static string PitPT { get; set; }
        public static string PrestigeXP { get; set; }
        public static string PitLevel { get; set; }
        public static string Reknown { get; set; }
        //
        public static string Perk1 = "N/A";
        public static string Perk2 = "N/A";
        public static string Perk3 = "N/A";
        public static string Perk4 = "N/A";
        //
        public static string Killstreak1 = "N/A";
        public static string Killstreak2 = "N/A";
        public static string Killstreak3 = "N/A";
        public static string Killstreak4 = "N/A";
        //
        public static string Boost1 = "N/A";
        public static string Boost2 = "N/A";
        public static string Boost3 = "N/A";
        public static string Boost4 = "N/A";
        public static string Boost5 = "N/A";
        public static string Boost6 = "N/A";
        public static string Boost7 = "N/A";
        //
        public static string PitKills;
        public static string PitAssists;
        public static string PitSwordHits;
        public static string PitArrowsShot;
        public static string PitArrowsHit;
        public static string PitHighestStreak;
        //
        public static string PitDeaths;
        public static string DamageTk;
        public static string MeleeDmgTk;
        public static string BowDmgTk;
        //
        public static string PitOverallXP = "N/A";
        public static string XPSlashHour = "N/A";
        public static string PitGoldOverall = "N/A";
        public static string GoldSlashHour = "N/A";
        public static string PitKD = "N/A";
        public static string PitKAD = "N/A";
        public static string KASlashHour = "N/A";
        public static string BowAcc = "N/A";
        public static string ContactsStarted = "N/A";
        public static string ContactsCompleted = "N/A";
        //
        public static string GoldenApplesEaten;
        public static string GoldenHeadsEaten;
        public static string LavaBucketsEmptied;
        public static string FishingRodsLaunched;
        public static string Soups_Drank;
        public static string t1_Mystics;
        public static string t2_Mystics;
        public static string t3_Mystics;
        public static string DarkPantsCreated;
        // Misc
        public static string DiamondItemsPurchased;
        public static string ChatMessages;
        public static string DailyTrades;
        public static string GoldTradeLimit;
        public static string GenesisPoints;
        // Farming
        public static string FishCaught;
        public static string FishSold;
        public static string HaybalesSold;
        public static string KingsQuestCom;
        public static string SewerTreasuresFound;
        public static string NightQuestsCom;
        // Prestige
        public static string Prestige;
        public static string CurrentRenown;
        public static string LifetimeRenown;
        public static string RenownCompletion;

        /*
         *  UHC
         * 
         */
        public static string UHC_score;
        public static string UHC_level;
        public static string UHC_Heads;
        public static string UHC_coins;
        public static string UHC_rank;
    }
}
