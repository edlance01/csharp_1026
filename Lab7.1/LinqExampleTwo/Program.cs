using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExampleTwo
{
    public record TodoItem(string Title, bool IsCompleted, int Priority, string Category);

    /*
     * Let’s update our demo to answer a more complex question: "What is the average priority of tasks, and how many are there per category?"
     * 
     * This example demonstrates more advanced LINQ operations, including grouping and aggregation.
     * We have a list of TodoItem objects, and we want to analyze them by category.
     * We will group the tasks by their category and calculate the count and average priority for each category.
     * Additionally, we will check if there are any high-priority work tasks pending.
     */

    class Program
    {
        static void Main()
        {
            var myTasks = new List<TodoItem>
        {
            new TodoItem("Buy groceries", true, 2, "Personal"),
            new TodoItem("Finish LINQ demo", false, 1, "Work"),
            new TodoItem("Call the bank", false, 1, "Personal"),
            new TodoItem("Fix bike tire", false, 3, "Personal"),
            new TodoItem("Read a book", true, 2, "Hobby"),
            new TodoItem("Email Boss", false, 1, "Work")
        };

            // 1. Grouping and Aggregation
            var stats = myTasks
                .GroupBy(t => t.Category)
                .Select(group => new
                {
                    CategoryName = group.Key,
                    Count = group.Count(),
                    AvgPriority = group.Average(t => t.Priority)
                });

            Console.WriteLine("--- Category Stats ---");
            foreach (var s in stats)
            {
                Console.WriteLine($"{s.CategoryName}: {s.Count} tasks, Avg Priority: {s.AvgPriority:F1}");
            }

            // 2. Checking Conditions (Any/All)
            bool hasHighPriorityWork = myTasks.Any(t => t.Category == "Work" && t.Priority == 1);
            Console.WriteLine($"\nUrgent work pending? {hasHighPriorityWork}");
        }
    }
}