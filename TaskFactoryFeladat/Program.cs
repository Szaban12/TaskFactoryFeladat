using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFactoryFeladat
{
    class Program
    {
        static void Main(string[] args)
        {
            Karakter[] k = new Karakter[20];
            for (int i = 0; i < k.Length; i++)
            {
                k[i] = new Karakter();
            }
            Task[] taskArray = new Task[19];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew(() => k[i].Move());
            }
            System.Threading.Thread.Sleep(15000);
            Console.ReadKey();
        }
    }
}
