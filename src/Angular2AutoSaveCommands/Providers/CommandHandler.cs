using System;
using Angular2AutoSaveCommands.Models;

namespace Angular2AutoSaveCommands.Providers
{
    public class CommandHandler : ICommandHandler
    {
        private readonly ICommandDataAccessProvider _commandDataAccessProvider;
        private readonly IAboutDataAccessProvider _aboutDataAccessProvider;
        private readonly IHomeDataAccessProvider _homeDataAccessProvider;

        public CommandHandler(ICommandDataAccessProvider commandDataAccessProvider,
            IAboutDataAccessProvider aboutDataAccessProvider,
            IHomeDataAccessProvider homeDataAccessProvider)
        {
            _commandDataAccessProvider = commandDataAccessProvider;
            _homeDataAccessProvider = homeDataAccessProvider;
            _aboutDataAccessProvider = aboutDataAccessProvider;
        }

        public void Execute(CommandDto commandDto)
        {
            if (commandDto.PayloadType == PayloadTypes.ABOUT)
            {
                ExecuteAboutDataCommand(commandDto);
                return;
            }

            if (commandDto.PayloadType == PayloadTypes.Home)
            {
                ExecuteHomeDataCommand(commandDto);
                return;
            }

            if (commandDto.PayloadType == PayloadTypes.NONE)
            {
                ExecuteNoDataCommand(commandDto);
                return;
            }
        }

        private void ExecuteHomeDataCommand(CommandDto commandDto)
        {
            if (commandDto.CommandType == CommandTypes.ADD)
            {
                _homeDataAccessProvider.AddHomeData(commandDto.Payload.ToObject<HomeData>());
            }

            if (commandDto.CommandType == CommandTypes.UPDATE)
            {
                _homeDataAccessProvider.UpdateHomeData(commandDto.Payload.ToObject<HomeData>());
            }

            if (commandDto.CommandType == CommandTypes.DELETE)
            {
                _homeDataAccessProvider.DeleteHomeData(commandDto.Payload.ToObject<HomeData>());
            }

            _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
            _commandDataAccessProvider.Save();
        }

        private void ExecuteAboutDataCommand(CommandDto commandDto)
        {
            if(commandDto.CommandType == CommandTypes.ADD)
            {
                _aboutDataAccessProvider.AddAboutData(commandDto.Payload.ToObject<AboutData>());
            }

            if (commandDto.CommandType == CommandTypes.UPDATE)
            {
                _aboutDataAccessProvider.UpdateAboutData(commandDto.Payload.ToObject<AboutData>());
            }

            if (commandDto.CommandType == CommandTypes.DELETE)
            {
                _aboutDataAccessProvider.DeleteAboutData(commandDto.Payload.ToObject<AboutData>());
            }


            _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
            _commandDataAccessProvider.Save();
        }

        private void ExecuteNoDataCommand(CommandDto commandDto)
        {
            _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
            _commandDataAccessProvider.Save();
        }
    }
}
