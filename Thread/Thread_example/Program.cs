using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Thread_example
{
    internal class Program
    {
        static void Func()
        {
            Console.WriteLine("스레드에서 호출");
        }
        static void ParameterizedFunc2(Object obj)
        {
            for (int i = 0; i <(int)obj; i++)
            {
                Console.WriteLine("Parameterized 스레드에서 호출 : {0}", i);
            }
        }
        class Test
        {
            public void Print()
            {
                Console.WriteLine("Test!");
            }
        }
        static void Func1()
        {
            for (int i = 0; i<1000; i++)
            { Console.WriteLine("스레드1 호출 {0}", i); }
        }
        static void Func2()
        {
            for (int i = 0; i < 1000; i++)
            { Console.WriteLine("스레드2 호출 {0}", i); }
        }
        static void Main(string[] args)
        {
            ////매개변수 없이 쓰레드
            //Thread th = new Thread(new ThreadStart(Func));
            //// ThreadStart thStart = new ThreadStart(Func); --> 델리게이트 생성
            //// Thread th = new Thread(thStart);
            //th.Start();

            ////매개변수 있이 쓰레드
            //int i = 5;
            //Thread th2 = new Thread(new ParameterizedThreadStart(ParameterizedFunc2));
            //th2.Start(i);

            ////매개변수로 함수를 전달
            //Test test = new Test();
            //Thread th = new Thread(new ThreadStart(test.Print));
            //th.Start();

            ////두개이상의 스레드 함수가 반복
            //Thread th1 = new Thread(new ThreadStart(Func1));
            //Thread th2 = new Thread(new ThreadStart(Func2));
            //th1.Start();
            //th2.Start();
            //Console.WriteLine("메인종료");
        }
    }
}
