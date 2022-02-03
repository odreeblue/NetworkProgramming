using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace lec2_networkclass_IPHostEntry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry HostInfo = Dns.GetHostEntry("www.naver.com");
            foreach(IPAddress ip in HostInfo.AddressList)
            {
                Console.WriteLine("{0}",ip);
            }
            Console.WriteLine("{0}", HostInfo.HostName);
        }
    }
}
