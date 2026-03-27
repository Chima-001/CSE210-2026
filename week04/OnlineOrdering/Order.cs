using System;
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = [];
    }

    public void AddProduct(Product product)
    {
       _products.Add(product);
    }

    public double shippingCost()
    {
        if (_customer.IsInUSA())
        {
            return 5;
        }
        else
        {
            return 35;
        }
    }
    public double CalcSubtotal()
    {
        
        double total = 0;
        foreach(Product product in _products)
        {
            total += product.CalcTotalCost();
        }

        total += shippingCost();
        return total;
    }

    public string DisplayPackingLabel()
    {
        string output = "";
        foreach(Product product in _products)
        {
            output += $"{product.GetName()} - {product.GetProductId()}\n";
        }
        return output;
    }

    public string DisplayShippingLabel()
    {
        return $"Name: {_customer.GetName()}\nAddress: {_customer.GetAddress().GetFullAddress()}";
    }
}