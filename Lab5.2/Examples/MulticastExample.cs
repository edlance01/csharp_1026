using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Aviation
{
    internal class MulticastExample
    {
        public delegate void Notify(string message);

        static void Main(string[] args)
        {
            Notify? notifyHandler = SendMail;
            notifyHandler += SendSMS;
            notifyHandler += WriteToLog;

            Console.WriteLine("---First Invocation (3 methods attached) ---");
            notifyHandler("System alert: Disk space is running low!");

            Console.WriteLine("\n---Second Invocation (SMS removed) ---");
            notifyHandler -= SendSMS;
            notifyHandler?.Invoke("System alert: CPU usage is high!");
        }

        //methods matching the delegate signature
        static void SendMail(string message) => Console.WriteLine($"[Email Sent]: {message}");
        static void SendSMS(string message) => Console.WriteLine($"[SMS Sent]: {message}");
        static void WriteToLog(string message) => Console.WriteLine($"[Log Entry]: {message}");

      
    }
}