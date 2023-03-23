using CSharpCourseEnumExercise.Entities;
using CSharpCourseEnumExercise.Entities.Enums;

Console.Write("Enter client data:\nName: ");
string name = Console.ReadLine();
Console.Write("E-mail: ");
string email = Console.ReadLine();
Console.Write("Birth date (DD/MM/YYYY): ");
DateTime date = DateTime.Parse(Console.ReadLine());
Console.Write("Enter order data:\nStatus: ");
OrderStatus os = Enum.Parse<OrderStatus>(Console.ReadLine());
Console.Write("How many items to this order?: ");
int n = int.Parse(Console.ReadLine());

Client client = new(name,email,date);
Order order = new(DateTime.Now, os, client);

for (int i = 0; i < n; i++) {
    Console.Write($"Enter #{i+1} item data:\nProduct name: " );
    string pName = Console.ReadLine();
    Console.Write("Product price: ");
    double price = double.Parse(Console.ReadLine());
    Console.Write("Quantity: ");
    int q = int.Parse(Console.ReadLine());

    order.addItem(new OrderItem(q, price, new Product(pName, price)));
}

Console.WriteLine("ORDER SUMMARY:");
Console.WriteLine($"Order moment: {order.Moment}");
Console.WriteLine($"Order status: {order.Status}");
Console.WriteLine($"Client {client.Name} ({client.birthDate}) - {client.Email}");
Console.WriteLine("Order items:");
foreach (OrderItem item in order.Items) {
    Console.WriteLine($"{item.Product.Name}, ${item.Price}, Quantity: {item.Quantity}, Subtotal: ${item.subTotal()}");
}
