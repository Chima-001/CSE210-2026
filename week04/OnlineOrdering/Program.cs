using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new("123 Elm Street", "Austin", "Texas", "USA");
        Address address2 = new("12 O'Connell Street Upper", "Dublin", "Leinster", "Ireland");
        Address address3 = new("780 Oak avenue", "Seattle", "WA", "USA");
        Address address4 = new("12 Baker Street", "London", "England", "UK");

        Customer customer1 = new("John Mitchell", address1);
        Customer customer2 = new("Walsh Aoife", address2);
        Customer customer3 = new("Sarah Collins", address3);
        Customer customer4 = new("James Fletcher", address4);

        Product prod1 = new("Wireless Mouse", "WM-001", 29.99, 2);
        Product prod2 = new("USB Hub", "UH-002", 15.49, 3);
        Product prod3 = new("Laptop Stand", "LS-003", 45.00, 2 );
        Product prod4 = new("Mechanical Keyboard", "MK-004", 89.99, 1);
        Product prod5 = new("Monitor Light", "ML-005", 35.00, 2);
        Product prod6 = new("Cable Organizer", "CO-006", 12.99, 3);
        Product prod7 = new("Webcam", "WC-007", 79.99, 1);
        Product prod8 = new("Desk Mat", "DM-008", 25.00, 1);
        Product prod9 = new("HDMI Cable", "HC-009", 9.99, 2);
        Product prod10 = new("Noise Cancelling Headphones", "NH-010", 149.99, 1);
        Product prod11 = new("Phone Stand", "PS-011", 18.50, 2);
        Product prod12 = new("Screen Cleaner Kit", "SK-012", 8.99, 3);

        Order order1 = new(customer1);
        Order order2 = new(customer2);
        Order order3 = new(customer3);
        Order order4 = new(customer4);

        order1.AddProduct(prod1);
        order1.AddProduct(prod2);
        order1.AddProduct(prod3);

        order2.AddProduct(prod4);
        order2.AddProduct(prod5);
        order2.AddProduct(prod6);

        order3.AddProduct(prod7);
        order3.AddProduct(prod8);
        order3.AddProduct(prod9);

        order4.AddProduct(prod10);
        order4.AddProduct(prod11);
        order4.AddProduct(prod12);

        List<Order> orders = [
            order1,
            order2,
            order3,
            order4
        ];

        Console.WriteLine("\n----------------------------------------------------");  
        foreach (Order order in orders)
        {
            Console.WriteLine();
            Console.WriteLine($"--- Packing Label ---\n{order.DisplayPackingLabel()}");
            Console.WriteLine($"--- Shipping Label ---\n{order.DisplayShippingLabel()}");
            Console.WriteLine($"Shipping Cost: {order.shippingCost()}");
            Console.WriteLine($"Total Cost: ${order.CalcSubtotal()}");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
        }
    }
}