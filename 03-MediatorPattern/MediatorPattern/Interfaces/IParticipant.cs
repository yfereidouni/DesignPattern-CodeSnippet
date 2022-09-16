namespace MediatorPattern.Interfaces;

public interface IParticipant
{
    void SendCommand(string receiver, string command);
    void ReceiveCommand(string sender, string command);
}
