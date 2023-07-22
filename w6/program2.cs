/*
Program 2: Encapsulation with Online Ordering
*/

using System;
using System.Collections.Generic;

public class Order 
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer) 
    {
        this.products = products;
        this.customer = customer;
    }

    public List<Product> Products 
    {
        get { return products; }
        set { products = value; }
    }

    public Customer Customer 
    {
        get { return customer; }
        set { customer = value; }
    }

    public double GetTotalPrice() 
    {
        double totalPrice = 0;
        foreach (Product product in products) 
        {
            totalPrice += product.GetPrice();
        }
        if (customer.IsInUSA()) 
        {
            totalPrice += 5;
        } 
        else 
        {
            totalPrice += 35;
        }
        return totalPrice;
    }

    public string GetPackingLabel() 
    {
        string packingLabel = "";
        foreach (Product product in products) 
        {
            packingLabel += $"{product.Name} ${product.Price}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel() 
    {
        return $"{customer.Name}\n{customer.Address.GetAddress()}";
    }
}

public class Product 
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

    public string Name 
    {
        get { return name; }
        set { name = value; }
    }

    public int ProductId 
    {
        get { return productId; }
        set { productId = value; }
    }

    public double Price 
    {
        get { return price; }
        set { price = value; }
    }

    public int Quantity 
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public double GetPrice() 
    {
        return price * quantity;
    }
}

public class Customer 
{
    private string name;
    private Address address;

    public Customer(string name, Address address) 
    {
        this.name = name;
        this.address = address;
    }

    public string Name 
    {
        get { return name; }
        set { name = value; }
    }

    public Address Address 
    {
        get { return address; }
        set { address = value; }
    }

    public bool IsInUSA() 
    {
        return address.IsInUSA();
    }
}

public class Address 
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string streetAddress, string city, string stateProvince, string country) 
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public string StreetAddress 
    {
        get { return streetAddress; }
        set { streetAddress = value; }
    }

    public string City 
    {
        get { return city; }
        set { city = value; }
    }

    public string StateProvince 
    {
        get { return stateProvince; }
        set { stateProvince = value; }
    }

    public string Country 
    {
        get { return country; }
        set { country = value; }
    }

    public bool IsInUSA() 
    {
        return country == "USA";
    }

    public string GetAddress() 
    {
        return $"{streetAddress}\n{city}, {stateProvince} {country}";
    }
}



class Program
{
    static void Main(string[] args)
    {
        // Order 1
        Address address1 = new Address("False Street 123", "MainCity", "NY", "USA");
        Customer customer1 = new Customer("Joaquin Solis", address1);
        Product product1 = new Product("iPhone 13 Pro Max", 111, 1230, 2);
        Product product2 = new Product("Macbook Pro M2", 222, 2400, 1);
        List<Product> products1 = new List<Product>();
        products1.Add(product1);
        products1.Add(product2);
        Order order1 = new Order(products1, customer1);
        Console.WriteLine("Order List");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine("Total Price");
        Console.WriteLine("$" + order1.GetTotalPrice());
        Console.WriteLine();
        // Order 2
        Address address2 = new Address("True Street 321", "SecondCity", "CA", "MX");
        Customer customer2 = new Customer("Joaquin Solis", address2);
        Product product3 = new Product("iPhone 13 Pro Max", 111, 1230, 2);
        Product product4 = new Product("Macbook Pro M2", 222, 2400, 1);
        List<Product> products2 = new List<Product>();
        products2.Add(product3);
        products2.Add(product4);
        Order order2 = new Order(products2, customer2);
        Console.WriteLine("Order List");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine("Total Price");
        Console.WriteLine("$" + order2.GetTotalPrice());

    }

}
