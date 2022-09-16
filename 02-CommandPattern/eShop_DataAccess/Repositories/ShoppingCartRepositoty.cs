using eShop_DataAccess.Interfaces;
using eShop_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_DataAccess.Repositories;

public class ShoppingCartRepositoty : IShoppingCartRepositoty
{
    public Dictionary<string, (Product Product, int Quantity)> LineItems = new Dictionary<string, (Product Product, int Quantity)>();

    public void Add(Product Product)
    {
        if (LineItems.ContainsKey(Product.Id))
        {
            IncreaseQuantity(Product.Id);
        }
        else
        {
            LineItems[Product.Id] = (Product, 1);
        }
    }

    public void DecreaseQuantity(string id)
    {
        if (LineItems.ContainsKey(id))
        {
            var lineItem = LineItems[id];
            LineItems[id] = (lineItem.Product, lineItem.Quantity - 1);
        }
        else
        {
            throw new KeyNotFoundException($"Product with id {id} not in cart, please add first");
        }
    }

    public (Product Product, int Quantity) Get(string id)
    {
        if (LineItems.ContainsKey(id))
        {
            return LineItems[id];
        }

        return (default, default);
    }

    public IEnumerable<(Product Product, int Quantity)> GetAll()
    {
        return LineItems.Values;
    }

    public void IncreaseQuantity(string id)
    {
        if (LineItems.ContainsKey(id))
        {
            var lineItem = LineItems[id];
            LineItems[id] = (lineItem.Product, lineItem.Quantity + 1);
        }
        else
        {
            throw new KeyNotFoundException($"Product with id {id} not in cart, please add first");
        }
    }

    public void RemoveAll(string id)
    {
       LineItems.Remove(id);
    }
}
