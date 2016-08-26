using Angular2AutoSaveCommands.Models;

namespace Angular2AutoSaveCommands.Providers
{
    public interface IHomeDataAccessProvider
    {
        void AddHomeData(AboutData aboutData);
        void UpdateHometData(AboutData aboutData);
        void DeleteHomeData(AboutData aboutData);
    }
}
