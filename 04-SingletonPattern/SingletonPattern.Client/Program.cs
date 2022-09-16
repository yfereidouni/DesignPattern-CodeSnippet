// See https://aka.ms/new-console-template for more information

using SingletonPattern;

Console.WriteLine("┌-------------------------------------------------┐");
Console.WriteLine("|                      Singleton                  |");
Console.WriteLine("└-------------------------------------------------┘");


var object1 =  SingletonObject.GetInstance();
Console.WriteLine($"Data of object1: {object1.Data}");

var object2 = SingletonObject.GetInstance();
Console.WriteLine($"Data of object2: {object1.Data}");

Console.WriteLine($"Are objects equal? {object.Equals(object1, object2)}");
Console.WriteLine($"Are objects reference equal? {object.ReferenceEquals(object1, object2)}");


Console.ReadKey();