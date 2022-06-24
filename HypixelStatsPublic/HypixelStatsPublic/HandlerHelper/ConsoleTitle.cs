using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HypixelStatsPublic.HandlerHelper
{
    public class ConsoleTitle
    {
        public static bool Cancel = true;
        public static void SetTitle()
        {
            SetConsoleX_Y();
            Task.Factory.StartNew(delegate ()
            {
                while (Cancel == true)
                {
                    System.Console.Title = string.Format("Hypixel stats checker | Coded by f.#6149 |");
                    Thread.Sleep(50);
                }
            });
        }

        public static void SetConsoleX_Y()
        {
            System.Console.SetWindowSize(200, 50);

        }
        public static void WindowReset()
        {
            System.Console.Clear();
            Program.Main();
        }
    }

}
