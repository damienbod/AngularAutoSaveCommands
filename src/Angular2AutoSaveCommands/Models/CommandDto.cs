namespace Angular2AutoSaveCommands.Models
{
    public class CommandDto<T> where T : class
    {
        public string PayloadType { get; set; }

        public T Payload { get; set; }
    }
}
