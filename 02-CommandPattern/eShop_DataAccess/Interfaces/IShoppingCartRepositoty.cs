using eShop_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_DataAccess.Interfaces;

public interface IShoppingCartRepositoty
{
    (Product Product, int Quantity) Get(string id);
    IEnumerable<(Product Product, int Quantity)> GetAll();
    void Add(Product Product);
    void RemoveAll(string id);
    void IncreaseQuantity(string id);
    void DecreaseQuantity(string id);
}
