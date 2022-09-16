using MediatorPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.Infrastructures;

public abstract class Mediator : IParticipant
{
    private readonly string _key;
    private readonly IMediator _mediator;

    public Mediator(string key, IMediator mediator)
    {
        _key = key;
        _mediator = mediator;
    }

    public void ReceiveCommand(string sender, string command)
    {
        Console.WriteLine($"Executing command {command} issued by {sender}.");
    }

    public void SendCommand(string receiver, string command)
    {
        _mediator.SendCommand(receiver, _key, command);

    }
}
