using AutoSaveCommandsApi.Models;

namespace AutoSaveCommandsApi.Providers
{
    public interface ICommandDataAccessProvider
    {
        void AddCommand(CommandEntity command);

        void Save();

    }
}
