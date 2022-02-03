using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace lec2_networkclass_DNS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress[] IP = Dns.GetHostAddresses("www.naver.com");
            foreach (IPAddress HostIP in IP)
            {
                Console.WriteLine("{0}", HostIP);
            }
        }
    }
}
