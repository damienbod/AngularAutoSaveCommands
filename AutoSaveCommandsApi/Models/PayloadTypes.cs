using System.Collections.Generic;

namespace AutoSaveCommandsApi.Models
{
    public static class PayloadTypes
    {
        public const string HOME = "HOME";
        public const string ABOUT = "ABOUT";
        public const string NONE = "NONE";

        public static List<string> AllowedTypes = new List<string>() { HOME, ABOUT, NONE };
    }
}
