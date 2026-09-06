using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExamples
{
    internal class BasicLinq
    {
        static void Main()
        {
            // 1. Data Source
            List<int> numbers = new List<int> { 5, 12, 3, 8, 20, 1, 14 };

            // 2. Query Construction (Filtering, Sorting, Projecting)
            IEnumerable<string> result = numbers
                .Where(n => n > 5)                  // Filter: keep numbers > 5
                .OrderBy(n => n)                    // Sort: ascending
                .Select(n => $"Value: {n}");        // Project: transform into string

            // 3. Query Execution
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
