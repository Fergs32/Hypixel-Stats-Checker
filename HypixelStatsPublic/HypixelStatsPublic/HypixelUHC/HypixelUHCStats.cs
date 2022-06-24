using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Leaf.xNet;
using System.Drawing;
using Leaf.xNet.Services.Cloudflare;
using Spectre.Console;
using HypixelStatsPublic.HandlerHelper;
using Colorful;
using HypixelStatsPublic.SpectreConsole;
using System.Linq;

namespace HypixelStatsPublic.HypixelUHC
{
    public class HypixelUHCStats
    {
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
                    httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.0.0 Safari/537.36";
                    Leaf.xNet.HttpResponse resp = httpRequest.Get("https://api.slothpixel.me/api/players/" + Result);
                    string input1 = resp.StatusCode < HttpStatusCode.BadGateway ? resp.ToString() : throw new Exception("Bad API request");
                    if (input1.Contains("\"UHC\":{\"coins\"") || input1.Contains("\"uuid\""))
                    {
                        ConcatData.UHC_coins= Regex.Match(input1, "\"UHC\":{\"coins\":(.*?),\"").Groups[1].Value;
                        ConcatData.UHC_level = Regex.Match(input1, "\"level\":([0-9]*?),\"heads_eaten\"").Groups[1].Value;
                        ConcatData.UHC_rank = Regex.Match(input1, "\"rank\":(.*?),").Groups[1].Value.Replace("\"", "");
                        ConcatData.UHC_Heads = Regex.Match(input1, "\"heads_eaten\":([0-9]*?)}},\"perks\"").Groups[1].Value;
                        ConcatData.UHC_score = Regex.Match(input1, "\"score\":([0-9]*?),\"level\"").Groups[1].Value;

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
                var root = new Tree("[white]" + Result + "[/]");
                // Add some nodes
                var foo = root.AddNode("[aqua]General[/]");
                var table = foo.AddNode(new Table()
                    .RoundedBorder()
                    .BorderColor(Spectre.Console.Color.HotPink)
                    .AddColumn("[aqua]Coins[/]")
                    .AddColumn("[aqua]Level[/]")
                    .AddColumn("[aqua]Rank[/]")
                    .AddColumn("[aqua]Heads Eaten[/]")
                    .AddColumn("[aqua]Score[/]")
                    .AddRow("[aqua]" + ConcatData.UHC_coins + "[/]", "[aqua]" + ConcatData.UHC_level + "[/]", "[aqua]" + ConcatData.UHC_rank + "[/]", "[aqua]" + ConcatData.UHC_Heads + "[/]", "[aqua]" + ConcatData.UHC_score + "[/]"));
                AnsiConsole.Write(root);
                Program.BacktoMenu();
            }
            catch(Exception ex)
            {
                Colorful.Console.WriteLine("[EXCEPTION ERROR]: " + ex, System.Drawing.Color.PaleVioletRed);
            }
        }
            
    }
}
