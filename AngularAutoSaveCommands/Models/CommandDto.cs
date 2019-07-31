using Newtonsoft.Json.Linq;
using System;
using System.Text.Json;

namespace AngularAutoSaveCommands.Models
{
    public class CommandDto
    {
        public string CommandType { get; set; }

        public string PayloadType { get; set; }

        public JObject Payload { get; set; }

        public string ActualClientRoute { get; set;}

    }

    public class CommandDtoObject
    {
        public string CommandType { get; set; }

        public string PayloadType { get; set; }

        public Object Payload { get; set; }

        public string ActualClientRoute { get; set; }

    }
}


