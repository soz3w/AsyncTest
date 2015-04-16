using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Console.WriteLine("Starting\n");
            var worker = new Worker();
            worker.DoWork();           
            worker.DoWork2();
            while (!worker.IsComplete)
            {
                Console.Write("." + i);
                Thread.Sleep(100);
                i++;
            }
            Console.WriteLine("Done");
            Console.ReadKey();
        }

    }
    public class Worker
    {
        public bool IsComplete { get; private set; }
        public bool IsComplete2 { get; private set; }

        public  async void DoWork()
        {
            this.IsComplete = false;
            Console.WriteLine("Doing work 2000");
            await LongOperation(2000);
            Console.WriteLine("Work Completed");
            IsComplete = true;
        }
        public async void DoWork2()
        {
            this.IsComplete2 = false;
            Console.WriteLine("Doing work 1000");
            await LongOperation(1000);
            Console.WriteLine("Work Completed");
            IsComplete2 = true;
        }

        private Task LongOperation(int duration)
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Working estimated duration "+duration);
                Thread.Sleep(duration);
                Console.WriteLine("Finished duration: " +duration);
            });
           
        }
       
    }
}
