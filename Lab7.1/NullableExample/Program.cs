
using NullableExample;
// 1. Declaration
// An ordinary int cannot be null.  Adding '?' allows it to be null.
int? studentGrade = null;
//NA
Console.WriteLine($"Student grade: {(studentGrade.HasValue ? studentGrade.Value.ToString() : "N/A")}");

Console.WriteLine($"Grade value: {studentGrade.GetValueOrDefault()}"); // 0, the default value for int

// 2. Assigning a value
studentGrade = 85;
//85
Console.WriteLine($"Student grade: {(studentGrade.HasValue ? studentGrade.Value.ToString() : "N/A")}");

// 3. The Null-Coalescing Operator (??)
int? finalScore = null;
// If finalScore is null, use 100 as the default value
int scoreToUse = finalScore ?? 100;
Console.WriteLine($"Final Score: {scoreToUse}");


// 4. Reference Types...normally just check for null
string? studentName = null;

if (studentName != null)
{
    Console.WriteLine($"Student name: {studentName}");
}
else
{
    Console.WriteLine("Student name is not provided.");
}



// 5. Nullable Reference Types (C# 8.0 and later)
Animal? animal = null;
Console.WriteLine($"Animal: {(animal != null ? animal.ToString() : "No animal")}");
