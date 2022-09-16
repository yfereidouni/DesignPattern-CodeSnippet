using eShop_DataAccess.Interfaces;
using eShop_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    //Using ValueTuple in Dictionary
    private Dictionary<string, (Product Product, int Stock)> products { get; }

    public ProductRepository()
    {
        products = new Dictionary<string, (Product Product, int Stock)>();

        Add(new Product("EOSR1", "Canon EOS R", 1099), 2);
        Add(new Product("EOS70D", "Canon EOS 70D", 699), 1);
        Add(new Product("ATOMOSNV", "Atomos Ninja V", 799), 0);
        Add(new Product("SM7B", "Shure Sm78", 399), 5);
    }

    public void Add(Product product, int stock)
    {
        products[product.Id] = (product, stock);
    }

    public void DecreaseStockBy(string id, int amount)
    {
        if (!products.ContainsKey(id)) return;

        products[id] = (products[id].Product, products[id].Stock - amount);
    }

    public Product FindBy(string id)
    {
        if (products.ContainsKey(id))
        {
            return products[id].Product;
        }

        return null;
    }

    public IEnumerable<Product> GetAll()
    {
        return products.Select(x => x.Value.Product);
    }

    public int GetStockFor(string id)
    {
        if (products.ContainsKey(id))
        {
            return products[id].Stock;
        }

        return 0;
    }

    public void IncreaseStockBy(string id, int amount)
    {
        if (!products.ContainsKey(id)) return;

        products[id] = (products[id].Product, products[id].Stock + amount);
    }
}
