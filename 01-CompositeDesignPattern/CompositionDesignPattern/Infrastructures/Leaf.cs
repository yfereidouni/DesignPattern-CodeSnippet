using CompositionDesignPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionDesignPattern.Infrastructures;

public class Leaf : ICustomComponent
{
    public int Price { get; set; }
    public string Name { get; set; }

    public Leaf(string name, int price)
    {
        this.Name = name;
        this.Price = price;
    }

    public void AddComponent(ICustomComponent component)
    {
        throw new NotImplementedException();
    }

    public decimal CalculatePrice()
    {
        return Price;
    }
}
