using System;

namespace eisenhower
{
    class Program
    {
        static void Main(string[] args)
        {
            var quarter = new TodoQuarter();
            
            quarter.AddItem();

            Console.WriteLine(quarter);
        }
    }
    
    
    
}
