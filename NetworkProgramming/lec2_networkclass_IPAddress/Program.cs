using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace lec2_networkclass_IPAddress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Address = Console.ReadLine();
            IPAddress IP = IPAddress.Parse(Address);
            Console.WriteLine("ip : {0}", IP.ToString());
        }
    }
}
