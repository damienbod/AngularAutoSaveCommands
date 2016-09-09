using System.Collections.Generic;

namespace Angular2AutoSaveCommands.Models
{
    public static  class CommandTypes
    {
        public const string ADD = "ADD";
        public const string UPDATE = "UPDATE";
        public const string DELETE = "DELETE";
        public const string UNDO = "UNDO";
        public const string REDO = "REDO";

        public static List<string> AllowedTypes = new List<string>() { ADD, UPDATE, DELETE, UNDO, REDO };
    }
}
