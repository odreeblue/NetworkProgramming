using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace syncro_example
{
    //class Test
    //{
    //    /// <summary>
    //    /// 사용예 1번 
    //    /// </summary>
    //    //static int Count;
    //    //public void ThreadProc()
    //    //{
    //    //    for (int i = 0; i < 10; i++)
    //    //    {
    //    //        Count++;
    //    //        Console.WriteLine("Thread ID: {0}  Result: {1}", Thread.CurrentThread.GetHashCode(), Count);
    //    //    }
    //    //}

    //    //수정 후
    //    //static object obj = new object();
    //    //static int Count;
    //    //public void ThreadProc()
    //    //{
    //    //    lock(obj)
    //    //    {
    //    //        for (int i = 0; i < 10; i++)
    //    //        {
    //    //            Count++;
    //    //            Console.WriteLine("Thread ID: {0}  Result: {1}", Thread.CurrentThread.GetHashCode(), Count);
    //    //        }
    //    //    }
            
    //    //}
    //}

    /// <summary>
    /// 사용예 2번
    /// </summary>
    class ThisLock
    {
        public void IncreaseCount(ref int count)//참조형 형태
        {
            count++;
        }
    }
    //class Test
    //{
    //    ThisLock lockObject = new ThisLock();
    //    int Count = 0;
    //    public void ThreadProc()
    //    {
    //        for (int i = 0; i < 3; i++)
    //        {
    //            lockObject.IncreaseCount(ref Count);
    //            Console.WriteLine("Thread ID:{0} Count:{1}", Thread.CurrentThread.GetHashCode(), Count);
    //        }
    //    }
    //}

    //수정 후
    class Test
    {
        ThisLock lockObject = new ThisLock();
        int Count = 0;
        public void ThreadProc()
        {
            lock (lockObject) //<--Object형으로 처리해도 결과는 동일함
            {
                for (int i = 0; i < 3; i++)
                {
                    lockObject.IncreaseCount(ref Count);
                    Console.WriteLine("Thread ID:{0} Count:{1}", Thread.CurrentThread.GetHashCode(), Count);
                }
            }
            
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ///사용예 1번
            ///
            //Test test = new Test();
            //Thread th1 = new Thread(new ThreadStart(test.ThreadProc));
            //Thread th2 = new Thread(new ThreadStart(test.ThreadProc));
            //th1.Start();
            //th2.Start();

            ///사용예 2번
            Test test = new Test();
            Thread[] threads = new Thread[3];
            for (int i=0; i<3; i++)
            {
                threads[i] = new Thread(new ThreadStart(test.ThreadProc));
            }
            for (int i=0;i<3;i++)
            {
                threads[i].Start();
            }
               
        }
    }
}
