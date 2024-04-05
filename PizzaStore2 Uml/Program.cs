using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pizzastore
{
    public class Program
    {
        static void Main(string[] args)
        {
            
           
            Store store = new Store();
            store.Run();
            Console.Write("Hit any key to continue");
            Console.ReadKey();

        }
    }
}