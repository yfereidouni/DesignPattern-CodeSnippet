using eShop_DataAccess.Infrastructures.Enums;
using eShop_DataAccess.Interfaces;
using eShop_DataAccess.Models;
using eShop_DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_DataAccess.Infrastructures.Commands;

public class ChangeQuantityCommand : ICommand
{
    private readonly Operation _operation;
    private readonly IShoppingCartRepositoty _shoppingCartRepository;
    private readonly IProductRepository _productRepository;
    private readonly Product _product;

    public ChangeQuantityCommand(Operation operation,IShoppingCartRepositoty shoppingCartRepositoty,
        IProductRepository productRepository,Product product)
    {
        _operation = operation;
        _shoppingCartRepository = shoppingCartRepositoty;
        _productRepository = productRepository;
        _product = product;
    }
    public bool CanExecute()
    {
        switch (_operation)
        {
            case Operation.Decrease:
                return _shoppingCartRepository.Get(_product.Id).Quantity != 0;
                break;
            case Operation.Increase:
                return (_productRepository.GetStockFor(_product.Id) - 1) >= 0;
        }
        return false;
    }

    public void Execute()
    {
        if (_product == null) return;
        
        _productRepository.DecreaseStockBy(_product.Id,1);
        
        _shoppingCartRepository.Add(_product);
    }

    public void Undo()
    {
        switch (_operation)
        {
            case Operation.Decrease:
                _productRepository.DecreaseStockBy(_product.Id, 1);
                _shoppingCartRepository.IncreaseQuantity(_product.Id);
                break;
            case Operation.Increase:
                _productRepository.IncreaseStockBy(_product.Id, 1);
                _shoppingCartRepository.DecreaseQuantity(_product.Id);
                break;
        }
    }
}
