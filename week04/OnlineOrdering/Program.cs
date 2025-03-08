using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, double> menu = new Dictionary<string, double>
        {
            { "Pizza", 12.99 },
            { "Burger", 8.99 },
            { "Pasta", 10.49 },
            { "Salad", 6.99 }
        };

        Dictionary<string, int> order = new Dictionary<string, int>();
        double total = 0;
        string choice;

        Console.WriteLine("Welcome to Online Ordering System!");
        Console.WriteLine("Menu:");
        foreach (var item in menu)
        {
            Console.WriteLine($"{item.Key} - ${item.Value}");
        }

        do
        {
            Console.Write("Enter item to order (or 'done' to finish): ");
            choice = Console.ReadLine();

            if (menu.ContainsKey(choice))
            {
                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                if (order.ContainsKey(choice))
                {
                    order[choice] += quantity;
                }
                else
                {
                    order[choice] = quantity;
                }
                total += menu[choice] * quantity;
            }
            else if (choice.ToLower() != "done")
            {
                Console.WriteLine("Invalid item, please choose from the menu.");
            }
        } while (choice.ToLower() != "done");

        Console.WriteLine("\nOrder Summary:");
        foreach (var item in order)
        {
            Console.WriteLine($"{item.Key}: {item.Value} x ${menu[item.Key]} = ${item.Value * menu[item.Key]:F2}");
        }
        Console.WriteLine($"Total: ${total:F2}");
        Console.WriteLine("Thank you for ordering!");
    }
}
