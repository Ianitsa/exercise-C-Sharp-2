using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tests_Thrends
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new ConcurrentDictionary<string,string>();
            var dictionary= new Dictionary<string,string>();
            Thread th1 = new Thread(() =>
            {
                string list = "";
                for (int i = 1; i <= 10; i++)
                {
                    list = "A" + i;
                    d.TryAdd(list, list);
                    //dictionary.Add(list, list);
                    //Thread.Sleep(3);
                }

                //foreach (var item in dictionary)
                //{
                //    Console.WriteLine("{0} - {1}", item.Key, item.Value);
                //}
            });
            
            //Thread.Sleep(10);
            Thread th2 = new Thread(() =>
            {
                
                string list = "";
                for (int i = 1; i <= 10; i++)
                {
                    list = "B" + i;

                    d.TryAdd(list, list);
                   // dictionary.Add(list, list);
                    Thread.Sleep(3);
                }
                //foreach (var item in dictionary)
                //{
                //    Console.WriteLine("{0} - {1}", item.Key, item.Value);
                //}
            });
            th1.Start();
            th2.Start();

            //List<Thread> threads = new List<Thread>();
            //threads.Add(th1);
            //threads.Add(th2);

            //foreach (var item in threads)
            //{
            //    item.Join();
            //}
            th1.Join();
            th2.Join();

            
            foreach (var item in dictionary)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
             
        }







        //public static void SededInfo()
        //{
        //    var listSended = new List<int>();
        //    for (int i = 1; i < 1000; i++)
        //    {
        //        listSended.Add(i);
        //    }


        //}

        //public static void ThreadsB()
        //{
        //    Thread.Sleep(100);
        //}
    }
}
