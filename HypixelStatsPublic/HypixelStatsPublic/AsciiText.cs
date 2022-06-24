using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Drawing;
using Colorful;


namespace HypixelStatsPublic
{
    class AsciiText
    {
        public static void DrawLogo()
        {
            string[] Logo = new string[]
            {
              @"",
              @"",
              @"",
              @"                  __  __            _           __",
              @"                 / / / /_  ______  (_)  _____  / /",
              @"                / /_/ / / / / __ \/ / |/_/ _ \/ /",
              @"               / __  / /_/ / /_/ / />  </  __/ /",
              @"              /_/ /_/\__, / .___/_/_/|_|\___/_/",
              @"                    /____/_/",
            };

            foreach(string line in Logo)
            {
                Colorful.Console.WriteLine(line, Color.Aquamarine);
            }

            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("\t\t\tCoded by Fergs32", Color.White);
            Colorful.Console.WriteLine("");

        }
    }
}
