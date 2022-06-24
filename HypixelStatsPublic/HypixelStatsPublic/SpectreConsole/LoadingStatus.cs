using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Leaf.xNet;
using System.Drawing;
using System.Threading;
using Spectre.Console;
using HypixelStatsPublic.HandlerHelper;
using Colorful;
using System.Linq;

namespace HypixelStatsPublic.SpectreConsole
{
    public class LoadingStatus
    {
        public static bool ProfileResult = false;
        public static bool APIAccess = false;


        public static async void GG2(string ign)
        {
            await AnsiConsole.Progress()
           .Columns(new ProgressColumn[]
           {
           new TaskDescriptionColumn(),    // Task description
           new ProgressBarColumn(),        // Progress bar
           new PercentageColumn(),         // Percentage
           new RemainingTimeColumn(),      // Remaining time
           new SpinnerColumn(),            // Spinner
           })
           .StartAsync(async ctx =>
           {
           var task1 = ctx.AddTask("[aqua]      Loading " + ign + "'s profile" + "[/]");
           var task2 = ctx.AddTask("[aqua]      Contacting 3rd party APIs[/]");
           var task3 = ctx.AddTask("[aqua]      Wrapping up final calls[/]");
               try
           {
                   while (!ctx.IsFinished)
                   {
                       do
                       {
                           GetAPIAccess(ign);
                           GetProfileRequest(ign);
                       }
                       while (ProfileResult && APIAccess == false);

                       if (ProfileResult == true)
                       {
                           task1.Increment(30);
                           Thread.Sleep(100);
                           task1.Increment(70);
                       }
                       if (APIAccess == true)
                       {
                           task2.Increment(40);
                           Thread.Sleep(100);
                           task2.Increment(60);
                           Thread.Sleep(150);
                           task3.Increment(100);
                       }
                   }
           }
           catch (Exception ex) { System.Console.WriteLine(ex); }
        });
        }

        public static void GetProfileRequest(string ign)
        {
            try
            {
                using (HttpRequest Req = new HttpRequest())
                {
                    Req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.0.0 Safari/537.36";

                    Leaf.xNet.HttpResponse httpResponse = Req.Get(new Uri("https://playerdb.co/api/player/minecraft/" + ign));
                    string input = httpResponse.StatusCode < Leaf.xNet.HttpStatusCode.BadGateway ? httpResponse.ToString() : throw new Exception("Banned IP / Incorrect IGN");

                    if (input.Contains("player.found") || input.Contains("Successfully"))
                    {
                        ProfileResult = true;
                    }
                    else
                    {
                        throw new Exception("Invalid server response");
                    }
                }
            }
            catch (HttpException ex)
            {
                Colorful.Console.WriteLine("[HTTP EXCEPTION LOG]: " + ex, System.Drawing.Color.PaleVioletRed);
                Thread.Sleep(-1);
            }
            catch (Exception ex) 
            {
                Colorful.Console.WriteLine("[EXCEPTION LOG]: " + ex, System.Drawing.Color.PaleVioletRed);
                Thread.Sleep(-1);
            }
        }

        public static void GetAPIAccess(string ign)
        {
            try
            {
                using (HttpRequest Req = new HttpRequest())
                {
                    Req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.0.0 Safari/537.36";

                    Leaf.xNet.HttpResponse Resp = Req.Get(new Uri("https://api.slothpixel.me/api/players/" + ign), null);
                    string input = Resp.StatusCode < Leaf.xNet.HttpStatusCode.BadGateway ? Resp.ToString() : throw new Exception("Banned IP");

                    if (input.Contains("\"uuid\"") || input.Contains("\"karma\""))
                    {
                        APIAccess = true;
                    }
                    else
                    {
                        throw new Exception("Invalid server response");
                    }
                }
            }
            catch (HttpException)
            {
                Colorful.Console.WriteLine("[HTTP EXCEPTION LOG]: Invalid IGN or client's server is down", System.Drawing.Color.PaleVioletRed);
                Thread.Sleep(-1);
            }
            catch (Exception)
            {
                Colorful.Console.WriteLine("[EXCEPTION LOG]: Potential API call failure, invalid ign, 404", System.Drawing.Color.PaleVioletRed);
                Thread.Sleep(-1);
            }
        }
    }
}
