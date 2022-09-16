using MediatorPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.Infrastructures.Concretes.Mediator;

public class NetworkMediator : IMediator
{
    private Dictionary<string,IParticipant> _participants;
    public NetworkMediator()
    {
        _participants = new Dictionary<string,IParticipant>();
    }
    public void Register(string key, IParticipant participant)
    {
        _participants[key] = participant;
    }

    public void SendCommand(string receiver, string sender, string command)
    {
        if (_participants.ContainsKey(receiver))
        {
            _participants[receiver].ReceiveCommand(sender, command);
        }
    }
}
