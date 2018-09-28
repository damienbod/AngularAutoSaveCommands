using AngularAutoSaveCommands.Models;

namespace AngularAutoSaveCommands.Providers
{
    public interface ICommandDataAccessProvider
    {
        void AddCommand(CommandEntity command);

        void Save();

    }
}
