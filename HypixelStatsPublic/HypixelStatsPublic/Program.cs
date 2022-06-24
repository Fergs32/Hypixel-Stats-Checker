using System;
using Colorful;
using System.Drawing;
using System.Threading;
using HypixelStatsPublic.HandlerHelper;

namespace HypixelStatsPublic
{
    public class Program
    {

        public static int Result;

        public static void Main()
        {
            AsciiText.DrawLogo();
            ConsoleTitle.SetTitle();
            System.Console.WriteLine();
            Colorful.Console.WriteLine("[1] Hypixel Main Stats", Color.Aquamarine); 
            Colorful.Console.WriteLine("[2] Hypixel Pit Stats", Color.Aquamarine);
            Colorful.Console.WriteLine("[3] Hypixel UHC Stats", Color.Aquamarine);
            System.Console.WriteLine();
            do
            {
                Colorful.Console.Write("[+] Option: ", Color.White);
            } while (!int.TryParse(System.Console.ReadLine(), out Result));
            switch (Result)
            {
                case 1:
                    HypixelMain.HypixelStatsMain.GetPlayerStats();
                    break;
                case 2:
                    HypixelPit.HypixelPitStats.GetPlayerStats();
                    break;
                case 3:
                    HypixelUHC.HypixelUHCStats.GetPlayerStats();
                    break;
                default:
                    throw new Exception("invalid option");
            }
        }

        public static void BacktoMenu()
        {
            int option;
            do
            {
                Colorful.Console.Write("\n[+] Back to menu? (1 [Yes] | 2 [No]): ", Color.White);
            }
            while (!int.TryParse(System.Console.ReadLine(), out option));
            switch(option)
            {
                case 1:
                    System.Console.Clear();
                    Main();
                    break;
                case 2:
                    Thread.Sleep(-1);
                    break;
                default:
                    Colorful.Console.WriteLine("Incorrect option, quitting program...");
                    break;
            }
        }
    }
}
