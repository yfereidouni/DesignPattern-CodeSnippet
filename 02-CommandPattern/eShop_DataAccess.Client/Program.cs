// See https://aka.ms/new-console-template for more information

using eShop_DataAccess.Infrastructures;
using eShop_DataAccess.Infrastructures.Commands;
using eShop_DataAccess.Infrastructures.Enums;
using eShop_DataAccess.Repositories;

Console.WriteLine("┌-------------------------------------------------┐");
Console.WriteLine("|                 Command Pattern V2              |");
Console.WriteLine("└-------------------------------------------------┘");

static void PrintCart(ShoppingCartRepositoty shoppingCartRepositoty)
{
    var totalprice = 0m;
	foreach (var lineItem in shoppingCartRepositoty.LineItems)
	{
		var price = lineItem.Value.Product.Price * lineItem.Value.Quantity;

		Console.WriteLine($"{lineItem.Key} " +
			$"${lineItem.Value.Product.Price} x {lineItem.Value.Quantity} = ${price}");

        totalprice += price;
	}

	Console.WriteLine($"Total price:\t${totalprice}");
}

var shoppinCartRepository = new ShoppingCartRepositoty();
var productRepository = new ProductRepository();

var product = productRepository.FindBy("SM7B");

var addToCartCommand = new AddToCartCommand(shoppinCartRepository,
	productRepository,
	product);

var increaseQuantityCommand = new ChangeQuantityCommand(
	Operation.Increase,
	shoppinCartRepository,
	productRepository,
	product);

var manager = new CommandManager();
manager.Invoke(addToCartCommand);
manager.Invoke(increaseQuantityCommand);
manager.Invoke(increaseQuantityCommand);
manager.Invoke(increaseQuantityCommand); 
manager.Invoke(increaseQuantityCommand);

PrintCart(shoppinCartRepository);

manager.Undo();

PrintCart(shoppinCartRepository);