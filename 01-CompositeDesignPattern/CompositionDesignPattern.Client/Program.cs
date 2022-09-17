// See https://aka.ms/new-console-template for more information

using CompositionDesignPattern.Infrastructures;
using CompositionDesignPattern.Interfaces;

Console.WriteLine("┌-------------------------------------------------┐");
Console.WriteLine("|           Composition Design Pattern            |");
Console.WriteLine("└-------------------------------------------------┘");

Console.WriteLine("***************** Asset Price ********************");

//Create Leaf Objects
ICustomComponent cpu = new Leaf("CPU", 10);
ICustomComponent ram = new Leaf("RAM", 10);
ICustomComponent hardDisk = new Leaf("Hard Disk", 10);
ICustomComponent mouse = new Leaf("Mouse", 10);
ICustomComponent keyboard = new Leaf("Keyboard", 50);

//Creating composite objects
ICustomComponent motherBoard = new Composite("Board");
ICustomComponent cabinet = new Composite("Case");
ICustomComponent peripherals = new Composite("Peripherals");

//Whole Device
ICustomComponent computer = new Composite("Computer");

//Creating Tree structure

//Adding CPU and RAM in Mother board
motherBoard.AddComponent(cpu);
motherBoard.AddComponent(ram);
//Adding Mother board and hard disk in Case
cabinet.AddComponent(motherBoard);
cabinet.AddComponent(hardDisk);
//Adding mouse and keyboard in Peripherals
peripherals.AddComponent(mouse);
peripherals.AddComponent(keyboard);
//Adding cabinet and peripherals in computer
computer.AddComponent(cabinet);
computer.AddComponent(peripherals);


//To display the price of the Computer
var price = computer.CalculatePrice();
Console.WriteLine(price.ToString());
Console.WriteLine();