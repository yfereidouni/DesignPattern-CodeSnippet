// See https://aka.ms/new-console-template for more information
using CommandPattern.Data;
using CommandPattern.Infrastructures.Commands;
using CommandPattern.Infrastructures.Invoker;

Console.WriteLine("┌-------------------------------------------------┐");
Console.WriteLine("|                  Command Pattern                |");
Console.WriteLine("└-------------------------------------------------┘");

var dataReceiver = new DataReceiver();
var invoker = new DataCommandInvoker();

invoker.SetCommand(new UpsertCommand("item1", "value1", dataReceiver));
invoker.ExecuteCommand();

invoker.SetCommand(new UpsertCommand("item2", "value2", dataReceiver));
invoker.ExecuteCommand();

invoker.SetCommand(new DisplayCommand(dataReceiver));
invoker.ExecuteCommand();

invoker.SetCommand(new DeleteCommand("item1", dataReceiver));
invoker.ExecuteCommand();

invoker.SetCommand(new DisplayCommand(dataReceiver));
invoker.ExecuteCommand();

Console.ReadKey();
