using System;

class Program
{
    static void Main(string[] args)
    {
        // -------- ORDER 1 (USA) --------
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P1001", 800, 1));
        order1.AddProduct(new Product("Mouse", "P1002", 25, 2));

        // -------- ORDER 2 (International) --------
        Address address2 = new Address("45 Oxford St", "London", "London", "UK");
        Customer customer2 = new Customer("Emma Brown", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Phone", "P2001", 600, 1));
        order2.AddProduct(new Product("Case", "P2002", 20, 3));

        // -------- DISPLAY ORDER 1 --------
        Console.WriteLine("========= ORDER 1 =========");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"TOTAL: ${order1.CalculateTotalCost()}");

        // -------- DISPLAY ORDER 2 --------
        Console.WriteLine("========= ORDER 2 =========");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"TOTAL: ${order2.CalculateTotalCost()}");
    }
}