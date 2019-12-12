using System;
using System.Management;

namespace WmiCodeCreator
{
    public class MyWMIQuery
    {
        public static void Main()
        {
            try
            {
                var searcher =
                    new ManagementObjectSearcher("{NAMESPACE}", "{QUERY}");

                foreach (var queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("{CLASS} instance");
                    Console.WriteLine("-----------------------------------");
{PROPERTY}
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine($"An error has occured: {e.Message}");
            }
        }
    }
}