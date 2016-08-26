using Newtonsoft.Json.Linq;

namespace Angular2AutoSaveCommands.Models
{
    public class CommandDto
    {
        public long Id { get; set; }

        public string CommandType { get; set; }

        public string PayloadType { get; set; }

        public JObject Payload { get; set; }

        public string ActualClientRoute { get; set;}

    }
}
