using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactoryFeladat
{
    class Karakter
    {
        public int AX { get; set; }
        public int AY { get; set; }
        public int PX { get; set; }
        public int PY { get; set; }
        public int DX { get; set; }
        public int DY { get; set; }
        public System.ConsoleColor MyColor { get; set; }
        public char MyChar { get; set; }
        public static class StaticRandom
        {
            static int seed = Environment.TickCount;
            static readonly ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));
            public static int Rand()   //Threading miatt a sima random number gen néha nem randomizal, ezzel igen mivel szálbiztos
            {
                return random.Value.Next(3);
            }
        }
        public Karakter(int y, int dx, int vele)
        {
            Random r = new Random();
            AX = 25;
            AY = y;
            DX = dx;
            DY = 0;
            int vel = StaticRandom.Rand();
            if (vel==0)
            {
                MyChar = '@';
            }
            else if(vel==1)
            {
                MyChar = '&';
            }
            vel = vele;
            if (vel==0)
            {
                MyColor = ConsoleColor.Red;
            }
            else if (vel==1)
            {
                MyColor = ConsoleColor.Green;
            }
            else
            {
                MyColor = ConsoleColor.Blue;
            }
            
        }
        public void Draw()
        {
            Console.ForegroundColor = System.ConsoleColor.Black;
            Console.SetCursorPosition(PX, PY);
            Console.Write(' ');
            PX = AX;PY = AY;
            Console.ForegroundColor = MyColor;
            
            Console.SetCursorPosition(AX, AY);
            Console.Write(MyChar);
        }
        public void Move(CancellationToken token)
        {

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                System.Threading.Thread.Sleep(300);
                Random r = new Random();
                AX = AX + DX; AY = AY + DY;
            }
            //System.Threading.Thread.Sleep(100);
            //PX = AX;
            //PY = AY;
            //AX = PX + DX;
            //AY = PY + DY;
            //Draw();
        }
        public Karakter(int aX, int aY, int pX, int pY, int dX, int dY, ConsoleColor myColor, char myChar)
        {
            AX = aX;
            AY = aY;
            PX = pX;
            PY = pY;
            DX = dX;
            DY = dY;
            MyColor = myColor;
            MyChar = myChar;
        }
    }
}
