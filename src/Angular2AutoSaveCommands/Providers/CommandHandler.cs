using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Angular2AutoSaveCommands.Models;
using Angular2AutoSaveCommands.Providers.Commands;
using Microsoft.Extensions.Logging;

namespace Angular2AutoSaveCommands.Providers
{
    public class CommandHandler : ICommandHandler
    {
        private readonly ICommandDataAccessProvider _commandDataAccessProvider;
        private readonly DomainModelMsSqlServerContext _context;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;

        // TODO remove these and used persistent stacks
        private static ConcurrentStack<ICommand> _undocommands = new ConcurrentStack<ICommand>();
        private static ConcurrentStack<ICommand> _redocommands = new ConcurrentStack<ICommand>();

        public CommandHandler(ICommandDataAccessProvider commandDataAccessProvider, DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory)
        {
            _commandDataAccessProvider = commandDataAccessProvider;
            _context = context;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger("CommandHandler");
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

        // TODO add return object for UI
        public CommandDto Undo()
        {  
            var commandDto = new CommandDto();
            commandDto.CommandType = CommandTypes.UNDO;
            commandDto.PayloadType = PayloadTypes.NONE;
            commandDto.ActualClientRoute = "NONE";

            if (_undocommands.Count > 0)
            {
                ICommand command;
                if (_undocommands.TryPop(out command))
                {
                    _redocommands.Push(command);
                    command.UnExecute(_context);
                    commandDto.Payload = command.ActualCommandDtoForNewState(CommandTypes.UNDO).Payload;
                    _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
                    _commandDataAccessProvider.Save();
                    return command.ActualCommandDtoForNewState(CommandTypes.UNDO);
                }   
            }

            return commandDto;
        }

        // TODO add return object for UI
        public CommandDto Redo()
        {
            var commandDto = new CommandDto();
            commandDto.CommandType = CommandTypes.REDO;
            commandDto.PayloadType = PayloadTypes.NONE;
            commandDto.ActualClientRoute = "NONE";

            if (_redocommands.Count > 0)
            {
                ICommand command;
                if(_redocommands.TryPop(out command))
                { 
                    _undocommands.Push(command);
                    command.Execute(_context);
                    commandDto.Payload = command.ActualCommandDtoForNewState(CommandTypes.REDO).Payload;
                    _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
                    _commandDataAccessProvider.Save();
                    return command.ActualCommandDtoForNewState(CommandTypes.REDO);
                }
            }

            return commandDto;
        }

        private void ExecuteHomeDataCommand(CommandDto commandDto)
        {
            if (commandDto.CommandType == CommandTypes.ADD)
            {
                ICommandAdd command = new AddHomeDataCommand(_loggerFactory, commandDto);
                command.Execute(_context);
                _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
                _commandDataAccessProvider.Save();
                command.UpdateIdforNewItems();
                _undocommands.Push(command);
            }

            if (commandDto.CommandType == CommandTypes.UPDATE)
            {
                ICommand command = new UpdateHomeDataCommand(_loggerFactory, commandDto);
                command.Execute(_context);
                _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
                _commandDataAccessProvider.Save();
                _undocommands.Push(command);
            }

            if (commandDto.CommandType == CommandTypes.DELETE)
            {
                ICommand command = new DeleteHomeDataCommand(_loggerFactory, commandDto);
                command.Execute(_context);
                _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
                _commandDataAccessProvider.Save();
                _undocommands.Push(command);
            }
        }


        private void ExecuteAboutDataCommand(CommandDto commandDto)
        {
            if(commandDto.CommandType == CommandTypes.ADD)
            {
                ICommandAdd command = new AddAboutDataCommand(_loggerFactory, commandDto);
                command.Execute(_context);
                _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
                _commandDataAccessProvider.Save();
                command.UpdateIdforNewItems();
                _undocommands.Push(command);
            }

            if (commandDto.CommandType == CommandTypes.UPDATE)
            {
                ICommand command = new UpdateAboutDataCommand(_loggerFactory, commandDto);
                command.Execute(_context);
                _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
                _commandDataAccessProvider.Save();
                _undocommands.Push(command);
            }

            if (commandDto.CommandType == CommandTypes.DELETE)
            {
                ICommand command = new DeleteAboutDataCommand(_loggerFactory, commandDto);
                command.Execute(_context);
                _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
                _commandDataAccessProvider.Save();
                _undocommands.Push(command);
            }
        }

        private void ExecuteNoDataCommand(CommandDto commandDto)
        {
            _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
            _commandDataAccessProvider.Save();
        }

    }
}
