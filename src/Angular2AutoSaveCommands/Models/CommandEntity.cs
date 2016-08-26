using Newtonsoft.Json.Linq;

namespace Angular2AutoSaveCommands.Models
{
    public class CommandEntity
    {
        public long Id { get; set; }

        public string CommandType { get; set; }

        public string PayloadType { get; set; }

        public string Payload { get; set; }

        public string ActualClientRoute { get; set;}

    }
}
