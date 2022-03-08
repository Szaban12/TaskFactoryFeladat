using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactoryFeladat
{
    class Program
    {
        static void Main(string[] args)
        {
            Karakter[] k = new Karakter[5];
            Random r = new Random();
            using(var tokensource=new CancellationTokenSource())
            {
                for (int i = 0; i < k.Length; i++)
                {
                    k[i] = new Karakter(i, r.Next(0, 3) - 1, r.Next(3));
                }
                Task[] taskArray = new Task[5];
                for (int j = 0; j < taskArray.Length; j++)
                {

                    taskArray[j] = Task.Factory.StartNew(() => k[j].Move(tokensource.Token));
                    System.Threading.Thread.Sleep(100); //Sleep nélkül valamiért elcsúszik és 4-en túl indexel a j

                }
                //int j = 0;
                //taskArray[j]=Task.Factory.StartNew(() => k[j++].Move(cancellation));
                //taskArray[j] = Task.Factory.StartNew(() => k[j++].Move(cancellation));
                //taskArray[j] = Task.Factory.StartNew(() => k[j++].Move(cancellation));
                //taskArray[j] = Task.Factory.StartNew(() => k[j++].Move(cancellation));
                //taskArray[j] = Task.Factory.StartNew(() => k[j++].Move(cancellation));
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        tokensource.Cancel();
                        Console.Clear();
                        Console.WriteLine("Program vége");
                        Thread.Sleep(2000);
                        break;
                    }
                    System.Threading.Thread.Sleep(1000);
                    for (int i = 0; i < k.Length; i++)
                    {
                        k[i].Draw();
                    }
                }
                //for (int i = 0; i < taskArray.Length; i++)
                //{
                //    taskArray[i] = Task.Factory.StartNew(() => k[i].Move());
                //}
                Console.ReadKey();
                //Félkész
            }

        }
    }
}
