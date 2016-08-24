using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular2AutoSaveCommands.Models;

namespace Angular2AutoSaveCommands.Providers
{
    public interface ICommandHandler 
    {
        void Add(CommandDto<object> commandDto, Type type);

        void Update(CommandDto<object> commandDto, Type type);

        void Delete(CommandDto<object> commandDto, Type type);
    }
}
