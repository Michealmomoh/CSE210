using System.Collections.Generic;

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal total = 0;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }

        total += customer.LivesInUSA() ? 5 : 35;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Labels:\n";
        foreach (Product product in products)
        {
            label += $"- {product.GetProductInfo()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Labels:\n{customer.GetName()}\n{customer.GetAddress()}";
    }
}
