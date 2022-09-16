using eShop_DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_DataAccess.Infrastructures;

public class CommandManager
{
    private Stack<ICommand> Commands = new Stack<ICommand>();
    public void Invoke(ICommand command)
    {
        if (command.CanExecute())
        {
            Commands.Push(command);
            command.Execute();
        }
    }

    public void Undo()
    {
        while(Commands.Count > 0)
        {
            var command = Commands.Pop();
            command.Undo();
        }
    }
}
