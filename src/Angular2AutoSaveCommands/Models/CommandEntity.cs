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

        public static CommandEntity CreateCommandEntity(CommandDto commandDto)
        {
            CommandEntity commandEntity = new CommandEntity();
            commandEntity.ActualClientRoute = commandDto.ActualClientRoute;
            commandEntity.CommandType = commandDto.CommandType;
            commandEntity.PayloadType = commandDto.PayloadType;
            commandEntity.Payload = commandDto.Payload.ToString();

            return commandEntity;
        }

        public CommandDto ToCommandDto()
        {
            CommandDto commandDto = new CommandDto();

            commandDto.ActualClientRoute = ActualClientRoute;
            commandDto.CommandType = CommandType;
            commandDto.PayloadType = PayloadType;
            commandDto.Payload = JObject.Parse(Payload);

            return commandDto;
        }

    }
}
