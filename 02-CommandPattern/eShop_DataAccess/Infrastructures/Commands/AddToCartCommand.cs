using eShop_DataAccess.Interfaces;
using eShop_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_DataAccess.Infrastructures.Commands;

public class AddToCartCommand : ICommand
{
    private readonly IShoppingCartRepositoty shoppingCartRepositoty;
    private readonly IProductRepository productRepository;
    private readonly Product product;

    public AddToCartCommand(IShoppingCartRepositoty shoppingCartRepositoty, 
        IProductRepository productRepository, Product product)
    {
        this.shoppingCartRepositoty = shoppingCartRepositoty;
        this.productRepository = productRepository;
        this.product = product;
    }

    public bool CanExecute()
    {
        if (product == null) return false;

        return productRepository.GetStockFor(product.Id) > 0;
    }

    public void Execute()
    {
        if (product == null) return;
        
        
        productRepository.DecreaseStockBy(product.Id, 1);
        
        shoppingCartRepositoty.Add(product);
    }

    public void Undo()
    {
        if (product == null) return;

        var lineItem = shoppingCartRepositoty.Get(product.Id);

        productRepository.IncreaseStockBy(product.Id, lineItem.Quantity);

        shoppingCartRepositoty.RemoveAll(product.Id);
    }
}
