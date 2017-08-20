using Newtonsoft.Json.Linq;

namespace AngularAutoSaveCommands.Models
{
    public class CommandDto
    {
        public string CommandType { get; set; }

        public string PayloadType { get; set; }

        public JObject Payload { get; set; }

        public string ActualClientRoute { get; set;}

    }
}
