using Angular2AutoSaveCommands.Models;

namespace Angular2AutoSaveCommands.Providers
{
    public interface IAboutDataAccessProvider
    {
        void AddAboutData(AboutData aboutData);
        void UpdateAboutData(AboutData aboutData);
        void DeleteAboutData(AboutData aboutData);
    }
}
