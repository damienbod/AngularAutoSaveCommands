using Angular2AutoSaveCommands.Models;

namespace AngularAutoSaveCommands.Providers
{
    public interface ICommandDataAccessProvider
    {
        void AddCommand(CommandEntity command);

        void Save();

    }
}
