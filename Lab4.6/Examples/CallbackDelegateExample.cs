using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    internal class CallbackDelegateExample
    {
        
            // Declared within the class that uses it
            public delegate void ProgressCallback(int percentComplete);

            public void StartDownload(ProgressCallback callback)
            {
                for (int i = 0; i <= 100; i += 20)
                {
                    Console.WriteLine($"Download progress: {i}%");
                    callback(i); // Triggering the callback
                }
            }
        
    }
}
