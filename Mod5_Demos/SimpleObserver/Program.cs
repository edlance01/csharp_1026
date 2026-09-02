

namespace SimpleObserver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Observable courseOne = new Observable();
            Console.WriteLine(courseOne.AddToCourse("Steve"));
            Console.WriteLine(courseOne.AddToCourse("Bredan"));
            Console.WriteLine(courseOne.AddToCourse("Noel"));
        }
    }
}   
