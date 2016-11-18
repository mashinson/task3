using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lights
{
    [Flags]
    enum Color
    {
        Gray = 1,
        Red = 2,
        Yellow = 4,
        Green = 8,
        DarkGreen = 16
    }
    class Program
    {
        const ConsoleColor gr = ConsoleColor.Gray;
        const ConsoleColor r = ConsoleColor.Red;
        const ConsoleColor y = ConsoleColor.Yellow;
        const ConsoleColor g = ConsoleColor.Green;
        const ConsoleColor dg = ConsoleColor.DarkGreen;

        static void lights()
        {
            Console.WriteLine("╔═══╗");
            Console.WriteLine("║███║");
            Console.WriteLine("╚═══╝");

        }

        // Определяет какой флаг включен
        static void Color_lights(Color one)
        {
            Console.SetCursorPosition(0, 0);
            if (one.HasFlag(Color.Red))
            {
                Console.ForegroundColor = r;
            }
            else
            {
                Console.ForegroundColor = gr;
            }
            lights();

            if (one.HasFlag(Color.Yellow))
            {
                Console.ForegroundColor = y;
            }
            else
            {
                Console.ForegroundColor = gr;
            }
            lights();

            if (one.HasFlag(Color.Green))
            {
                Console.ForegroundColor = g;
            }
            else if (one.HasFlag(Color.DarkGreen))
            {
                Console.ForegroundColor = dg;
            }
            else
            {
                Console.ForegroundColor = gr;
            }

            lights();  

            Console.ReadLine();
        }
        static void Main(string[] args)
        {
           // Переменная в которую мы будем записывать какой цвет будет гореть
            Color one = Color.Gray;

            bool ch = true;
            while (ch)
            {
                one = Color.Red;
                Color_lights(one);

                one = Color.Red | Color.Yellow;
                Color_lights(one);

                one = Color.Green;
                Color_lights(one);

                one = Color.DarkGreen;
                Color_lights(one);

                one = Color.Green;
                Color_lights(one);

                one = Color.DarkGreen;
                Color_lights(one);

                one = Color.Yellow;
                Color_lights(one);

                one = Color.Red;
                Color_lights(one);


                one = Color.Gray;
                Color_lights(one);

            }

        }
    }
}
