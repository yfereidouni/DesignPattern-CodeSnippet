using eShop_DataAccess.Interfaces;
using eShop_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_DataAccess.Infrastructures.Commands;

public class RemoveFromCartCommand : ICommand
{
    private readonly IShoppingCartRepositoty _shoppingCartRepositoty;
    private readonly IProductRepository _productRepository;
    private readonly Product _product;

    public RemoveFromCartCommand(IShoppingCartRepositoty shoppingCartRepositoty,
        IProductRepository productRepository, Product product)
    {
        _shoppingCartRepositoty = shoppingCartRepositoty;
        _productRepository = productRepository;
        _product = product;
    }

    public bool CanExecute()
    {
        if (_product == null) return false;

        return _shoppingCartRepositoty.Get(_product.Id).Quantity > 0;
    }

    public void Execute()
    {
        if (_product == null) return;

        var lineItem = _shoppingCartRepositoty.Get(_product.Id);

        _productRepository.IncreaseStockBy(_product.Id, lineItem.Quantity);

        _shoppingCartRepositoty.RemoveAll(_product.Id);
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}
