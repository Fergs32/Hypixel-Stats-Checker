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

namespace HypixelStatsPublic.HandlerHelper
{
    public class SetPitStats
    {
        public static List<string> ActivePerks = new List<string>().ToList<string>();
        public static List<string> ActiveKillstreaks = new List<string>().ToList<string>();
        public static List<string> ActiveBoosts = new List<string>().ToList<string>();

        public static void GetPerks(string httpresp)
        {
            List<string> PerkList = new List<string>().ToList<string>();
            Regex regex = new Regex("\"name\":\"(.*?)\",\"id\"", RegexOptions.IgnoreCase);
            Match m = regex.Match(httpresp);
            MatchCollection Matches = Regex.Matches(httpresp, "\"name\":\"(.*?)\",\"id\"");
            while (m.Success)
            {
                for (int i = 0; i < Matches.Count; i++)
                {
                    Group g = m.Groups[1];
                    PerkList.Add(g.Value);
                }
                m = m.NextMatch();
            }
            var noDupes = PerkList.Distinct().ToList();
            for (int i = 0; i < noDupes.Count; i++)
            {
                if (PitItems.Perks.Contains(noDupes[i]))
                {
                    ActivePerks.Add(noDupes[i]);
                }
                else { }
            }
            SetPerks();
        }
        public static void SetPerks()
        {
            try
            {

                for (int i = 0; i < ActivePerks.Count + 3;)
                {
                    if (ConcatData.Perk1.Contains("N/A"))
                    {
                        ConcatData.Perk1 = ActivePerks.First();
                        ActivePerks.Remove(ActivePerks.First());
                        i++;
                    }
                    else if (ConcatData.Perk2.Contains("N/A"))
                    {
                        ConcatData.Perk2 = ActivePerks.First();
                        ActivePerks.Remove(ActivePerks.First());
                        i++;
                    }
                    else if (ConcatData.Perk3.Contains("N/A"))
                    {
                        ConcatData.Perk3 = ActivePerks.First();
                        ActivePerks.Remove(ActivePerks.First());
                        i++;
                    }
                    else if (ConcatData.Perk4.Contains("N/A"))
                    {
                        ConcatData.Perk4 = ActivePerks.First();
                        ActivePerks.Remove(ActivePerks.First());
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }
        public static void GetKillstreaks(string httpresp)
        {
            try
            {
                List<string> KillstreakList = new List<string>().ToList<string>();
                Regex regex = new Regex("\"name\":\"(.*?)\",", RegexOptions.IgnoreCase);
                Match m = regex.Match(httpresp);
                MatchCollection Matches = Regex.Matches(httpresp, "\"name\":\"(.*?)\",");
                while (m.Success)
                {
                    for (int i = 0; i < Matches.Count; i++)
                    {
                        Group g = m.Groups[1];
                        KillstreakList.Add(g.Value);
                    }
                    m = m.NextMatch();
                }
                var noDupes = KillstreakList.Distinct().ToList();
                for (int i = 0; i < noDupes.Count; i++)
                {
                    if (PitItems.Killstreaks.Contains(noDupes[i]))
                    {
                        ActiveKillstreaks.Add(noDupes[i]);
                    }
                    else { }
                }
                SetKillstreaks();
            }
            catch
            {

            }
        }
        public static void SetKillstreaks()
        {
            try
            {
                for (int i = 0; i < ActiveKillstreaks.Count + 3;)
                {
                    if (ConcatData.Killstreak1.Contains("N/A"))
                    {
                        ConcatData.Killstreak1 = ActiveKillstreaks.First();
                        ActiveKillstreaks.Remove(ActiveKillstreaks.First());
                        i++;
                    }
                    else if (ConcatData.Killstreak2.Contains("N/A"))
                    {
                        ConcatData.Killstreak2 = ActiveKillstreaks.First();
                        ActiveKillstreaks.Remove(ActiveKillstreaks.First());
                        i++;
                    }
                    else if (ConcatData.Killstreak3.Contains("N/A"))
                    {
                        ConcatData.Killstreak3 = ActiveKillstreaks.First();
                        ActiveKillstreaks.Remove(ActiveKillstreaks.First());
                        i++;
                    }
                    else if (ConcatData.Killstreak4.Contains("N/A"))
                    {
                        ConcatData.Killstreak4 = ActiveKillstreaks.First();
                        ActiveKillstreaks.Remove(ActiveKillstreaks.First());
                        i++;
                    }
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }
        /*
         * 
         * Get boosts, extracts from http response and then puts into a string list
         * 
         * 
         */
        public static void GetBoosts(string httpresp)
        {
            try
            {
                List<string> BoostList = new List<string>().ToList<string>();
                Regex regex = new Regex("\"name\":\"(.*?)\",\"id\"", RegexOptions.IgnoreCase);
                Match m = regex.Match(httpresp);
                MatchCollection Matches = Regex.Matches(httpresp, "\"name\":\"(.*?)\",\"id\"");
                while (m.Success)
                {
                    for (int i = 0; i < Matches.Count; i++)
                    {
                        Group g = m.Groups[1];
                        BoostList.Add(g.Value);
                    }
                    m = m.NextMatch();
                }
                var noDupes = BoostList.Distinct().ToList();
                for (int i = 0; i < noDupes.Count; i++)
                {
                    if (PitItems.boostUpgrades.Contains(noDupes[i]))
                    {
                        ActiveBoosts.Add(noDupes[i]);
                    }
                    else { }
                }
                SetBoosts();
            }
            catch
            {

            }
        }
        /*
         * 
         * Sets the boost into global variables, by setting the first element, then deleting the first elment. This is just simple logic, idk the complex math shit lmao
         * 
         * 
         */
        public static void SetBoosts()
        {
            try
            {
                for (int i = 0; i < ActiveBoosts.Count + 6;)
                {
                    if (ConcatData.Boost1.Contains("N/A"))
                    {
                        ConcatData.Boost1 = ActiveBoosts.First();
                        ActiveBoosts.Remove(ActiveBoosts.First());
                        i++;
                    }
                    else if (ConcatData.Boost2.Contains("N/A"))
                    {
                        ConcatData.Boost2 = ActiveBoosts.First();
                        ActiveBoosts.Remove(ActiveBoosts.First());
                        i++;
                    }
                    else if (ConcatData.Boost3.Contains("N/A"))
                    {
                        ConcatData.Boost3 = ActiveBoosts.First();
                        ActiveBoosts.Remove(ActiveBoosts.First());
                        i++;
                    }
                    else if (ConcatData.Boost4.Contains("N/A"))
                    {
                        ConcatData.Boost4 = ActiveBoosts.First();
                        ActiveBoosts.Remove(ActiveBoosts.First());
                        i++;
                    }
                    else if (ConcatData.Boost5.Contains("N/A"))
                    {
                        ConcatData.Boost5 = ActiveBoosts.First();
                        ActiveBoosts.Remove(ActiveBoosts.First());
                        i++;
                    }
                    else if (ConcatData.Boost6.Contains("N/A"))
                    {
                        ConcatData.Boost6 = ActiveBoosts.First();
                        ActiveBoosts.Remove(ActiveBoosts.First());
                        i++;
                    }
                    else if (ConcatData.Boost7.Contains("N/A"))
                    {
                        ConcatData.Boost7 = ActiveBoosts.First();
                        ActiveBoosts.Remove(ActiveBoosts.First());
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }
        /*
         * 
         * Probably really inefficient, but its aight ig. Just replaces them dumb color codes with nothing
         * 
         */
        public static void RemoveUselessText()
        {
            ConcatData.Perk1 = ConcatData.Perk1.Replace("§9", "");
            ConcatData.Perk2 = ConcatData.Perk2.Replace("§9", "");
            ConcatData.Perk3 = ConcatData.Perk3.Replace("§9", "");
            ConcatData.Perk4 = ConcatData.Perk4.Replace("§9", "");
            //
            ConcatData.Killstreak1 = ConcatData.Killstreak1.Replace("§9", "");
            ConcatData.Killstreak2 = ConcatData.Killstreak2.Replace("§9", "");
            ConcatData.Killstreak3 = ConcatData.Killstreak3.Replace("§9", "");
            ConcatData.Killstreak4 = ConcatData.Killstreak4.Replace("§9", "");
            //
            ConcatData.Boost1 = ConcatData.Boost1.Replace("§9", "");
            ConcatData.Boost2 = ConcatData.Boost2.Replace("§9", "");
            ConcatData.Boost3 = ConcatData.Boost3.Replace("§9", "");
            ConcatData.Boost4 = ConcatData.Boost4.Replace("§9", "");
            ConcatData.Boost5 = ConcatData.Boost5.Replace("§9", "");
            ConcatData.Boost6 = ConcatData.Boost6.Replace("§9", "");
            ConcatData.Boost7 = ConcatData.Boost7.Replace("§9", "");
        }
    }
}
