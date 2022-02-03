using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/// <summary>
/// 사용 예 1번
/// </summary>
//namespace syncro_example_monitor
//{
//    // lock과 동일하게 private object obj = new object()를 사용하여 동기화 하는 예
//    class Test
//    {
//        int Count = 0;
//        object obj = new object(); //값이기 때문에 이렇게 사용
//        public void IncreaseCount()
//        {
//            Monitor.Enter(obj); 
//            for (int i = 0; i < 5; i++)
//            {
//                Count++;
//                Console.WriteLine("Thread ID:{0} Count:{1}", Thread.CurrentThread.GetHashCode(), Count);
//            }
//            Monitor.Exit(obj);
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Test test = new Test();

//            Thread th1 = new Thread(new ThreadStart(test.IncreaseCount));
//            Thread th2 = new Thread(new ThreadStart(test.IncreaseCount));
//            th1.Start();
//            th2.Start();
//        }
//    }
//}


///사용예 2번
namespace syncro_example_monitor
{
    // lock과 동일하게 private object obj = new object()를 사용하여 동기화 하는 예
    class ThisLock
    {
        public void IncreaseCount(ref int count)//참조형 형태
        {
            count++;
        }
    }
    class Test
    {
        ThisLock lockObject = new ThisLock();
        int Count = 0;
        public void ThreadProc()
        {
            Monitor.Enter(lockObject);
            for (int i = 0; i < 3; i++)
            {
                lockObject.IncreaseCount(ref Count);
                Console.WriteLine("Thread ID:{0} Count:{1}", Thread.CurrentThread.GetHashCode(), Count);
            }
            Monitor.Exit(lockObject);

        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread[] threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(new ThreadStart(test.ThreadProc));
            }
            for (int i = 0; i < 3; i++)
            {
                threads[i].Start();
            }

        }
    }
}
