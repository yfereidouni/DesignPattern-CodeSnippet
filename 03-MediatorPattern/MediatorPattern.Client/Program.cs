// See https://aka.ms/new-console-template for more information

using MediatorPattern.Infrastructures.Concretes;
using MediatorPattern.Infrastructures.Concretes.Mediator;

Console.WriteLine("┌-------------------------------------------------┐");
Console.WriteLine("|              Mediator Design Patte              |");
Console.WriteLine("└-------------------------------------------------┘");


var networkMediator = new NetworkMediator();
var desktopComputer = new DesktopComputer("computer-1", networkMediator);
var server = new Server("server-1", networkMediator);

networkMediator.Register("computer-1",desktopComputer);
networkMediator.Register("server-1", server);

desktopComputer.SendCommand("server-1", "reboot");
server.SendCommand("computer-1", "trigger-updates");

Console.ReadKey();