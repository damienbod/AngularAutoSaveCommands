using Angular2AutoSaveCommands.Models;

namespace Angular2AutoSaveCommands.Providers
{
    public interface IHomeDataAccessProvider
    {
        void AddHomeData(HomeData homeData);
        void UpdateHomeData(HomeData homeData);
        void DeleteHomeData(HomeData homeData);
    }
}
