using CommandPattern.Data;
using CommandPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Infrastructures;

public abstract class Command : ICommand
{
    protected DataReceiver _dataReceiver;

    public Command(DataReceiver dataReceiver)
    {
        _dataReceiver = dataReceiver;
    }
    public abstract void Execute();
}
