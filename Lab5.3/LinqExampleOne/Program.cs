using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExampleOne
{
    // "data model" see notes at bottom of this file for more info on records
    public record TodoItem(string Title, bool IsCompleted, int Priority);

    class Program
    {
        static void Main(string[] args)
        {
            var todoItems = new List<TodoItem>
            {
                new TodoItem("Buy groceries", false, 2),
                new TodoItem("Finish LINQ demo", true, 1),
                new TodoItem("Call mom", false, 3),
                new TodoItem("Pay bills", true, 2),
                new TodoItem("Schedule dentist appointment", false, 1)
            };
            // LINQ query to filter and order the todo items
            var highPriorityIncompleteTasks = from item in todoItems
                                             where !item.IsCompleted && item.Priority <= 2
                                             orderby item.Priority
                                             select item;
            Console.WriteLine("High Priority Incomplete Tasks:");
            foreach (var task in highPriorityIncompleteTasks)
            {
                Console.WriteLine($"- {task.Title} (Priority: {task.Priority})");
            }
        }
    }

    /*
     * Notes on records:
     * - Records are a reference type that provides built-in functionality for value-based equality, immutability, and concise syntax.
     * - They are ideal for representing data models or DTOs (Data Transfer Objects) where the primary purpose is to hold data.
     * - In this example, we use a record to define the TodoItem class, which has three properties: Title, IsCompleted, and Priority.
     * - The record automatically generates methods like Equals(), GetHashCode(), and ToString() based on the properties defined in the record.
     * 
     * Think of a class like a "Machine" (it does things) and a record like a "Receipt" (it just holds facts that shouldn't change).
     */

}
