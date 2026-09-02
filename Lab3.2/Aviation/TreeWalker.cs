using System;
using System.IO;

namespace NTier.Aviation
{
    internal class TreeWalker
    {
        internal void Walk(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            if (!di.Exists)
            {
                Console.WriteLine($"Directory not found: {path}");
                return;
            }

            Console.WriteLine($"Current Directory: {di.FullName}\n");

            FileInfo[] files = di.GetFiles();

            Console.WriteLine($"{"Last Modified",-20} {"Size (Bytes)",-12} {"Name"}");
            /*
             In C#, the structure inside the curly braces follows this pattern:
                {<interpolationExpression>[,<alignment>][:<formatString>]}

            The Comma (,): This tells C# that the following number is for alignment (padding).

            The Negative Sign (-): This indicates left-alignment. It tells the program to put the text on the left and fill the remaining space to the right with blanks. (A positive number would right-align the text).

            The Numbers (20 and 12): This is the minimum field width.

            -20 means "Reserve at least 20 characters for this string, left-aligned."

            -12 means "Reserve at least 12 characters for this string, left-aligned."
             */
            Console.WriteLine(new string('_', 50));

            foreach (FileInfo file in files)
            {
                //Challenge 24 hour clock time
                string lastWriteTime = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                long fileSize = file.Length;
                string fileName = file.Name;
                Console.WriteLine($"{lastWriteTime,-20} {fileSize,-12} {fileName}");
            }
        }
    }
}