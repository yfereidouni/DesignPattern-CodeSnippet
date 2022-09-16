using MediatorPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.Infrastructures.Concretes;

public class DesktopComputer : Participant
{
    public DesktopComputer(string key, IMediator mediator) : base(key, mediator) { }

    public override void SendCommand(string receiver, string command)
    {
        Console.WriteLine($"Sending {command} command to {receiver}.");
        base.SendCommand(receiver, command);
    }

    public override void ReceiveCommand(string sender, string command)
    {
        Console.WriteLine($"Desktop computer {_key} received a command.");
        base.ReceiveCommand(sender, command);
    }
}
