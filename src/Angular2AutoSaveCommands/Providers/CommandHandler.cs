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

        public void Undo()
        {
            if(_undocommands.Count > 0)
            {
                ICommand command;
                if (_undocommands.TryPop(out command))
                {
                    _redocommands.Push(command);
                    command.UnExecute();
                }   
            }
        }

        public void Redo()
        {
            if (_redocommands.Count > 0)
            {
                ICommand command;
                if(_redocommands.TryPop(out command))
                {
                    _undocommands.Push(command);
                    command.Execute();
                }
            }
        }

        private void ExecuteHomeDataCommand(CommandDto commandDto)
        {
            if (commandDto.CommandType == CommandTypes.ADD)
            {
                ICommand command = new AddHomeDataCommand(_context, _loggerFactory, commandDto);
                command.Execute();
                _undocommands.Push(command);
            }

            if (commandDto.CommandType == CommandTypes.UPDATE)
            {
                ICommand command = new UpdateHomeDataCommand(_context, _loggerFactory, commandDto);
                command.Execute();
                _undocommands.Push(command);
            }

            if (commandDto.CommandType == CommandTypes.DELETE)
            {
                ICommand command = new DeleteHomeDataCommand(_context, _loggerFactory, commandDto);
                command.Execute();
                _undocommands.Push(command);
            }

            _commandDataAccessProvider.AddCommand(CommandEntity.CreateCommandEntity(commandDto));
            _commandDataAccessProvider.Save();
        }

        private void ExecuteAboutDataCommand(CommandDto commandDto)
        {
            if(commandDto.CommandType == CommandTypes.ADD)
            {
                ICommand command = new AddAboutDataCommand(_context, _loggerFactory, commandDto);
                command.Execute();
                _undocommands.Push(command);
            }

            if (commandDto.CommandType == CommandTypes.UPDATE)
            {
                ICommand command = new UpdateAboutDataCommand(_context, _loggerFactory, commandDto);
                command.Execute();
                _undocommands.Push(command);
            }

            if (commandDto.CommandType == CommandTypes.DELETE)
            {
                ICommand command = new DeleteAboutDataCommand(_context, _loggerFactory, commandDto);
                command.Execute();
                _undocommands.Push(command);
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
