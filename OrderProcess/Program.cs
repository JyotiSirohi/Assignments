using OrderProcess.Models;
using OrderProcess;
using System;
using OrderProcess.Services;

var processor = new OrderProcessor(
    new PackingSlipService(),
    new EmailService(),
    new MembershipService(),
    new CommissionService()
);

bool running = true;

while (running)
{
    Console.WriteLine("\nOrder Processing System");
    Console.WriteLine("=======================");
    Console.WriteLine("1. Process a new order");
    Console.WriteLine("2. Process example orders");
    Console.WriteLine("3. Exit");
    Console.Write("\nSelect an option (1-3): ");

    string? input = Console.ReadLine();
    Console.WriteLine();

    switch (input)
    {
        case "1":
            ProcessManualOrder(processor);
            break;

        case "2":
            ProcessExampleOrders(processor);
            break;

        case "3":
            Console.WriteLine("Exiting...");
            running = false;
            break;

        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
}

static void ProcessManualOrder(OrderProcessor processor)
{
    Console.Write("Enter product name: ");
    string? name = Console.ReadLine();

    Console.WriteLine("Select type:");
    Console.WriteLine("1. Physical Product");
    Console.WriteLine("2. Book");
    Console.WriteLine("3. Membership");
    Console.WriteLine("4. Membership Upgrade");
    Console.WriteLine("5. Video");

    Console.Write("Enter number (1-5): ");
    string? typeInput = Console.ReadLine();
    if (!int.TryParse(typeInput, out int typeNum) || typeNum < 1 || typeNum > 5)
    {
        Console.WriteLine("Invalid type.");
        return;
    }

    var type = (PaymentType)(typeNum - 1);

    string? email = null;
    if (type == PaymentType.Membership || type == PaymentType.MembershipUpgrade)
    {
        Console.Write("Enter customer email: ");
        email = Console.ReadLine();
    }

    var payment = new Payment
    {
        ProductName = name ?? "",
        Type = type,
        CustomerEmail = email ?? ""
    };

    processor.ProcessPayment(payment);
}

static void ProcessExampleOrders(OrderProcessor processor)
{
    var payments = new List<Payment>
    {
        new Payment { Type = PaymentType.PhysicalProduct, ProductName = "Laptop" },
        new Payment { Type = PaymentType.Book, ProductName = "C# Programming" },
        new Payment { Type = PaymentType.Membership, CustomerEmail = "user@example.com" },
        new Payment { Type = PaymentType.MembershipUpgrade, CustomerEmail = "user@example.com" },
        new Payment { Type = PaymentType.Video, ProductName = "Learning to Ski" }
    };

    foreach (var payment in payments)
    {
        Console.WriteLine($"\nProcessing: {payment.ProductName ?? payment.Type.ToString()}");
        processor.ProcessPayment(payment);
    }
}

