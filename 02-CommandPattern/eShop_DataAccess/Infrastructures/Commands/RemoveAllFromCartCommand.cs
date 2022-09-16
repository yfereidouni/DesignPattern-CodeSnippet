using eShop_DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_DataAccess.Infrastructures.Commands;

public class RemoveAllFromCartCommand : ICommand
{
    private readonly IShoppingCartRepositoty _shoppingCartRepositoty;
    private readonly IProductRepository _productRepository;

    public RemoveAllFromCartCommand(IShoppingCartRepositoty shoppingCartRepositoty,
        IProductRepository productRepository)
    {
        _shoppingCartRepositoty = shoppingCartRepositoty;
        _productRepository = productRepository;
    }

    public bool CanExecute()
    {
        return _shoppingCartRepositoty.GetAll().Any();
    }

    public void Execute()
    {
        var items = _shoppingCartRepositoty.GetAll().ToArray(); //Make a local copy

        foreach (var lineItem in items)
        {
            _productRepository.IncreaseStockBy(lineItem.Product.Id, lineItem.Quantity);

            _shoppingCartRepositoty.RemoveAll(lineItem.Product.Id);
        }
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}
