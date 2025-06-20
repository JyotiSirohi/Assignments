
**Order Processing System**
A basic console application built using .NET to simulate an order processing system.

**What the Project Does**
This application processes different types of orders. When you run it, it shows a menu with options like:

1. Process a new order
2. Process example orders
3. Exit
You can either manually enter order details or run built-in example orders. Based on the order type, the system does different actions such as:

Generating a packing slip
Sending an email
Activating or upgrading a membership
Adding a free video (for certain products)
Generating a commission payment

**Supported Order Types**
Physical Product – Generates a packing slip and a commission.
Book – Generates a packing slip, a duplicate for the royalty department, and a commission.
Membership – Activates membership and sends an email.
Membership Upgrade – Upgrades existing membership and sends an email.
Video (e.g., “Learning to Ski”) – Adds a bonus "First Aid" video if applicable.

**How to Run the Project**
Open the solution in Visual Studio.
Set OrderProcess as the startup project.
Press F5 or Ctrl+F5 to run.
You’ll be prompted with a menu to process orders.

**How to Run Unit Tests**
Make sure OrderProcessTests has a reference to OrderProcess.
Build the solution.
Open Test Explorer and click Run All Tests.
The tests check if each type of payment triggers the correct business logic using NUnit and Moq.

**Technologies Used**
C#
.NET Console App
NUnit (Unit Testing Framework)
Moq (Mocking Dependencies)

