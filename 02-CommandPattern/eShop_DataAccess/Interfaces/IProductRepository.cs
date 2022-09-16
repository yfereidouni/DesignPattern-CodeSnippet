using eShop_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_DataAccess.Interfaces;

public interface IProductRepository
{
    Product FindBy(string id);
    int GetStockFor(string id);
    IEnumerable<Product> GetAll();
    void DecreaseStockBy(string id, int amount);
    void IncreaseStockBy(string id, int amount);
}
