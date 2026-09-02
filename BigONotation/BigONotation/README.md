

Here is a C# lab to help understand Big O notation.

Think of Big O notation as a way to measure how much longer a program takes to finish as you give it more work to do.

Imagine you are looking for a specific book in a library:

O(1) is like instantly knowing which shelf the book is on.

O(N) is like looking at every single book one by one until you find it.

O(N 
2
 ) is like comparing every book to every other book in the entire library.

The C# Lab: The Great Number Search
Copy and paste this code into a new C# Console Application and run it!

C#
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== BIG O NOTATION LAB ===\n");

        // We create a list of numbers from 0 to 9,999,999
        int arraySize = 10_000_000;
        int[] numbers = new int[arraySize];
        for (int i = 0; i < arraySize; i++)
        {
            numbers[i] = i;
        }

        Stopwatch timer = new Stopwatch();

        // -------------------------------------------------------------
        // 1. CONSTANT TIME: O(1)
        // -------------------------------------------------------------
        // Problem: Grab the very first number in the list.
        // Rule: It takes 1 step, no matter how big the list is!
        timer.Start();
        int firstNumber = numbers[0]; 
        timer.Stop();

        Console.WriteLine($"[O(1) Constant Time]");
        Console.WriteLine($"Found number '{firstNumber}' instantly.");
        Console.WriteLine($"Time taken: {timer.Elapsed.TotalMilliseconds} ms\n");

        // -------------------------------------------------------------
        // 2. LINEAR TIME: O(N)
        // -------------------------------------------------------------
        // Problem: Find the last number in the list by checking one by one.
        // Rule: If the list has N items, it takes up to N steps.
        int target = arraySize - 1; // Looking for 9,999,999
        
        timer.Reset();
        timer.Start();
        
        bool found = false;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == target)
            {
                found = true;
                break;
            }
        }
        
        timer.Stop();

        Console.WriteLine($"[O(N) Linear Time]");
        Console.WriteLine($"Checked {arraySize:N0} numbers one by one to find '{target}'.");
        Console.WriteLine($"Time taken: {timer.Elapsed.TotalMilliseconds} ms\n");

        // -------------------------------------------------------------
        // 3. QUADRATIC TIME: O(N^2)
        // -------------------------------------------------------------
        // Problem: Compare numbers in a small list against each other (Loop inside a loop).
        // Rule: If you double the items, the time quadruples (N * N)!
        int smallSize = 10_000; // Using a SMALL list because 10 million would freeze your computer!
        int matches = 0;

        timer.Reset();
        timer.Start();

        for (int i = 0; i < smallSize; i++)
        {
            for (int j = 0; j < smallSize; j++)
            {
                if (i == j) matches++;
            }
        }

        timer.Stop();

        Console.WriteLine($"[O(N^2) Quadratic Time]");
        Console.WriteLine($"Ran {smallSize:N0} x {smallSize:N0} loop checks ({smallSize * smallSize:N0} total steps).");
        Console.WriteLine($"Time taken: {timer.Elapsed.TotalMilliseconds} ms\n");
    }
}
What to Look For When You Run It
O(1) takes almost 0 milliseconds. It doesn't matter if the list has 10 items or 10 billion items—grabbing item #0 is always just 1 step.

O(N) takes noticeable time. Searching through 10,000,000 numbers one by one means doing 10,000,000 checks. If you double the list size, the time doubles.

O(N 
2
 ) gets slow FAST. Notice we only used 10,000 numbers instead of 10,000,000 for this one. A loop inside a loop on 10,000 items forces the computer to do 100,000,000 operations! If we tried using the 10,000,000 size array here, your program would freeze for hours.

Would you like to add an O(log N) binary search example to compare against O(N)?

Yes

can you create a md file of the above please

What to Look For When You Run It
O(1) takes almost 0 milliseconds. It doesn't matter if the list has 10 items or 10 billion items—grabbing item #0 is always just 1 step.

O(N) takes noticeable time. Searching through 10,000,000 numbers one by one means doing 10,000,000 checks. If you double the list size, the time doubles.

O(N 
2
 ) gets slow FAST. Notice we only used 10,000 numbers instead of 10,000,000 for this one. A loop inside a loop on 10,000 items forces the computer to do 100,000,000 operations! If we tried using the 10,000,000 size array here, your program would freeze for hours.
"""

file_path = "big_o_notation_csharp_lab.md"
with open(file_path, "w", encoding="utf-8") as f:
f.write(md_content)

print(f"File created successfully as {file_path}")


```text?code_stdout&code_event_index=1
File created successfully as big_o_notation_csharp_lab.md

Your Markdown file is ready
MD icon
big_o_notation_csharp_lab
 MD 
Open

I have created the Markdown (.md) file containing the full Big O notation explanation and C# lab code.




Your nTier Training chats aren’t used to improve our models. Gemini is AI and can make mistakes. Your privacy & GeminiOpens in a new window

# Big O Notation C# Lab (8th Grade Level)

Big O notation is a way to measure **how much longer a program takes to finish as you give it more work to do**.

Think of searching for a specific book in a library:
* **$O(1)$** is like instantly knowing which exact shelf the book is on.
* **$O(N)$** is like looking at every single book one by one until you find it.
* **$O(N^2)$** is like comparing every book to every other book in the entire library.

---

## The C# Lab: The Great Number Search

Copy and paste this code into a new C# Console Application (`Program.cs`) and run it!

```csharp
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== BIG O NOTATION LAB ===\n");

        // We create a list of numbers from 0 to 9,999,999
        int arraySize = 10_000_000;
        int[] numbers = new int[arraySize];
        for (int i = 0; i < arraySize; i++)
        {
            numbers[i] = i;
        }

        Stopwatch timer = new Stopwatch();

        // -------------------------------------------------------------
        // 1. CONSTANT TIME: O(1)
        // -------------------------------------------------------------
        // Problem: Grab the very first number in the list.
        // Rule: It takes 1 step, no matter how big the list is!
        timer.Start();
        int firstNumber = numbers[0]; 
        timer.Stop();

        Console.WriteLine($"[O(1) Constant Time]");
        Console.WriteLine($"Found number '{firstNumber}' instantly.");
        Console.WriteLine($"Time taken: {timer.Elapsed.TotalMilliseconds} ms\n");

        // -------------------------------------------------------------
        // 2. LINEAR TIME: O(N)
        // -------------------------------------------------------------
        // Problem: Find the last number in the list by checking one by one.
        // Rule: If the list has N items, it takes up to N steps.
        int target = arraySize - 1; // Looking for 9,999,999
        
        timer.Reset();
        timer.Start();
        
        bool found = false;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == target)
            {
                found = true;
                break;
            }
        }
        
        timer.Stop();

        Console.WriteLine($"[O(N) Linear Time]");
        Console.WriteLine($"Checked {arraySize:N0} numbers one by one to find '{target}'.");
        Console.WriteLine($"Time taken: {timer.Elapsed.TotalMilliseconds} ms\n");

        // -------------------------------------------------------------
        // 3. QUADRATIC TIME: O(N^2)
        // -------------------------------------------------------------
        // Problem: Compare numbers in a small list against each other (Loop inside a loop).
        // Rule: If you double the items, the time quadruples (N * N)!
        int smallSize = 10_000; // Using a SMALL list because 10 million would freeze your computer!
        int matches = 0;

        timer.Reset();
        timer.Start();

        for (int i = 0; i < smallSize; i++)
        {
            for (int j = 0; j < smallSize; j++)
            {
                if (i == j) matches++;
            }
        }

        timer.Stop();

        Console.WriteLine($"[O(N^2) Quadratic Time]");
        Console.WriteLine($"Ran {smallSize:N0} x {smallSize:N0} loop checks ({smallSize * smallSize:N0} total steps).");
        Console.WriteLine($"Time taken: {timer.Elapsed.TotalMilliseconds} ms\n");
    }
}
```

---

## What to Look For When You Run It

1. **$O(1)$ takes almost 0 milliseconds.** It doesn't matter if the list has 10 items or 10 billion items—grabbing item #0 is always just 1 step.
2. **$O(N)$ takes noticeable time.** Searching through 10,000,000 numbers one by one means doing 10,000,000 checks. If you double the list size, the time doubles.
3. **$O(N^2)$ gets slow FAST.** Notice we only used 10,000 numbers instead of 10,000,000 for this one. A loop inside a loop on 10,000 items forces the computer to do **100,000,000 operations**! If we tried using the 10,000,000 size array here, your program would freeze for hours.
big_o_notation_csharp_lab.md
Displaying big_o_notation_csharp_lab.md.