using System;
using System.Collections.Generic;
using System.Text;
using HypixelStatsPublic.HandlerHelper;

namespace HypixelStatsPublic.HandlerHelper
{
    public class PrefixFormatter
    {
        public static void PrefixFormat(string prefix)
        {
            switch(prefix)
            {
                case "MVP_PLUS":
                    MVP_Plus_Prefix(prefix);
                    break;
                case "MVP_PLUS_PLUS":
                    MVP_PlusPlus_Prefix(prefix);
                    break;
                case "VIP_PLUS":
                    VIP_PLUS_Prefix(prefix);
                    break;
                case "VIP":
                    NonPrefix(prefix);
                    break;
                case "MVP":
                    NonPrefix(prefix);
                    break;
                case "":
                    NonPrefix(prefix);
                    break;
                case "YOUTUBER":
                    NonPrefix(prefix);
                    break;
                default:
                    throw new Exception("Incorrect rank type");
                    
            }
        }
        private static void MVP_PlusPlus_Prefix(string prefix)
        {
            ConcatData.Rank = "MVP++";
        }

        private static void MVP_Plus_Prefix(string prefix)
        {
            ConcatData.Rank = "MVP+";
        }

        private static void VIP_PLUS_Prefix(string prefix)
        {
            ConcatData.Rank = "VIP+";
        }

        private static void NonPrefix(string prefix)
        {
            ConcatData.Rank = prefix;
        }
    }
}
