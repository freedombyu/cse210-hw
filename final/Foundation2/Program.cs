using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Address address1 = new Address("101 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("18 Reynolds St", "Reynolds View", "Johannesburg", "South Africa");

        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Freedom Mukanza", address2);

        Product product1 = new Product("Product1", 1, 10.5, 2);
        Product product2 = new Product("Product2", 2, 8.75, 3);
        Product product3 = new Product("Product3", 3, 5.99, 1);

        Order order1 = new Order(new List<Product> { product1, product2 }, customer1);
        Order order2 = new Order(new List<Product> { product2, product3 }, customer2);

        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Order 1 Total Price: $" + order1.CalculateTotalPrice());

        Console.WriteLine("\nOrder 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Order 2 Total Price: $" + order2.CalculateTotalPrice());
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}, {country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}

class Product
{
    private string name;
    private int productId;
    private double price;
    private int quantity;

    public Product(string name, int productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double CalculateProductPrice()
    {
        return price * quantity;
    }

    public string GetProductInfo()
    {
        return $"{name} (ID No: {productId}) - ${price} each x {quantity} = ${CalculateProductPrice()}";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public double CalculateTotalPrice()
    {
        double totalPrice = 0;
        foreach (var product in products)
        {
            totalPrice += product.CalculateProductPrice();
        }
        totalPrice += customer.IsInUSA() ? 5 : 35; // Shipping cost

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += product.GetProductInfo() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\nAddress: {customer.GetAddress()}";
    }
}
