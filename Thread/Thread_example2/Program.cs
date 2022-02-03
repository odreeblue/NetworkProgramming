using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Thread_example2
{
    internal class Program
    {
        
        static void Func()
        {
            int i = 0;
            while(true)
            {
                Console.Write("{0}  ",i++);
                Thread.Sleep(300); //0.3초
            }
        }
        static void ThreadProc()
        {
            Console.WriteLine("스레드 id: {0}",Thread.CurrentThread.GetHashCode());
        }

        static void Func1()
        {
            for (int i=0;i<30; i++)
            {
                Console.WriteLine("{0} ", i);
                Thread.Sleep(200);
            }
        }
        private static void ThreadProc1()
        {
            Console.WriteLine("ThreadProc1 쓰레드 {0}", Thread.CurrentThread.GetHashCode());
            Thread th = new Thread(new ThreadStart(ThreadProc2));
            th.Start();

            for (int i=0;i<10;i++)
            {
                Console.Write("{0} ", i * 10);
                Thread.Sleep(200);
                if(i==3)
                {
                    Console.WriteLine("ThreadProc1 종료");
                    Thread.CurrentThread.Abort();
                }
            }
        }
        private static void ThreadProc2()
        {
            Console.WriteLine("ThreadProc2 쓰레드 {0}", Thread.CurrentThread.GetHashCode());
            
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} ", i);
                Thread.Sleep(200);
            }
            Console.WriteLine("ThreadProc2 종료");
        }
        static void Main(string[] args)
        {
            ////1. foreground 설정
            //Thread th = new Thread(new ThreadStart(Func));
            //th.Start();
            //Console.WriteLine("Main 종료");

            ////2. background 설정
            //Thread th = new Thread(new ThreadStart(Func));
            //th.IsBackground = true;
            //th.Start();
            //Console.WriteLine("main 종료");

            ////3. Current --> 매우 중요
            //Thread th = new Thread(new ThreadStart(ThreadProc));
            //th.Start();
            //Console.WriteLine("Main 스레드 id: {0}", Thread.CurrentThread.GetHashCode());

            ////4. th.Join() 사용 //스레드가 종료될 때까지 기다림
            //Thread th = new Thread(new ThreadStart(Func1));
            //th.Start();
            //th.Join();
            //Console.WriteLine("Main 종료");

            ////5. Abort() 사용 //자기자신의 쓰레드에 속해있으면서 종료
            //Thread th = new Thread(new ThreadStart(ThreadProc1));
            //th.Start();
            //Console.WriteLine("Main 쓰레드 {0}",Thread.CurrentThread.GetHashCode());
            //Console.WriteLine("Main 종료");
        }
    }
}
