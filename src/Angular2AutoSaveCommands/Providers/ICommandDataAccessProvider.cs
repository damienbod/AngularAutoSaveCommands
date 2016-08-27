using Angular2AutoSaveCommands.Models;

namespace Angular2AutoSaveCommands.Providers
{
    public interface ICommandDataAccessProvider
    {
        void AddCommand(CommandEntity command);

        void Save();

    }
}
