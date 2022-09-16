using MediatorPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.Infrastructures;

public abstract class Participant : IParticipant
{
    private IMediator _mediator;
    protected string _key;

    public Participant(string key, IMediator mediator)
    {
        _key = key;
        _mediator = mediator;
    }

    public virtual void ReceiveCommand(string sender, string command)
    {
        Console.WriteLine($"Executing command {command} issued by {sender}.");
    }

    public virtual void SendCommand(string receiver, string command)
    {
        _mediator.SendCommand(receiver, _key, command);

    }
}
