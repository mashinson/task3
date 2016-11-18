using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enum_without_flags
{
    enum Days : byte// Дни недели 
    {
        New_Day = 0x00,
        Monday = 0x01,       // 0000 0001 
        Tuesday = 0x02,      // 0000 0010
        Wednesday = 0x04,    // 0000 0100
        Thursday = 0x08,     // 0000 1000
        Friday = 0x10,       // 0001 0000
        Saturday = 0x20,     // 0010 0000
        Sunday = 0x40        // 0100 0000
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            // Предметы
            byte Algorithms = 0x17;     // 0001 0111
            byte Graphics = 0xC;        // 0000 1100
            byte c_sharp = 0x32;        // 0011 0010            
            byte Math = 0x14;           // 0001 0100
            byte Eng = 0x5;             // 0000 0101
                                        // максимум и минимум для дней недели и уроков
            const int min = 1;
            const int maxD = 7;
            const int maxL = 5;

            // Пароль 
            const byte CorrectPassword = 0x87;  // 1000 0111


            Console.WriteLine("Список предметов:  ");
            Console.WriteLine("Algorithms (1)");
            Console.WriteLine("Graphics (2)");
            Console.WriteLine("c# (3)");
            Console.WriteLine("Math (4)");
            Console.WriteLine("English (5)");
            Console.WriteLine();


            Console.WriteLine("Дни недели:  ");
            Console.WriteLine("Понедельник (1)");
            Console.WriteLine("Вторник (2)");
            Console.WriteLine("Среда (3)");
            Console.WriteLine("Четверг (4)");
            Console.WriteLine("Пятница (5)");
            Console.WriteLine("Суббота (6)");
            Console.WriteLine("Воскресенье (7)");

            Console.WriteLine();

            // номер предмета и номер дня, которые вводит пользователь 
            int day = 0,
              lesson = 0;

            // предмет и день которые соответствуют номеру предмета и номеру дня, которые вводит пользователь 
            byte d = 0,
                 l = 0;

            bool ch = true;  //счетчик который определяет сколько раз смотреть и менять расписание 

            while (ch)
            {
                Console.WriteLine("Хотите поменять расписание? (да (Yes), нет (No))");
                string s3 = Console.ReadLine();
                Console.WriteLine();
                if (s3.Contains("yes"))
                {
                    Console.WriteLine("Введите пароль: ");
                    string p = Console.ReadLine();
                    byte password = 0;
                    bool pwd = byte.TryParse(p, out password);

                    if (pwd && (password ^ CorrectPassword) == 0)
                    {
                        Console.WriteLine("Пароль правильный!");

                        Console.Write("Введите номер предмета: ");
                        string s4 = Console.ReadLine();
                        bool result3 = int.TryParse(s4, out lesson);
                        Console.WriteLine();

                        Console.Write("Введите номер дня недели: ");
                        string s5 = Console.ReadLine();
                        bool result4 = int.TryParse(s5, out day);
                        Console.WriteLine();

                        if ((result3) && (result4) && (lesson >= min && lesson <= maxL) && (day >= min && day <= maxD))
                        {

                            #region day
                            switch (day)
                            {
                                case 1:
                                    d = (byte)Days.Monday;
                                    break;
                                case 2:
                                    d = (byte)Days.Tuesday;
                                    break;
                                case 3:
                                    d = (byte)Days.Wednesday;
                                    break;
                                case 4:
                                    d = (byte)Days.Thursday;
                                    break;
                                case 5:
                                    d = (byte)Days.Friday;
                                    break;
                                case 6:
                                    d = (byte)Days.Saturday;
                                    break;
                                case 7:
                                    d = (byte)Days.Sunday;
                                    break;
                            }

                            #endregion

                            #region lesson
                            switch (lesson)
                            {
                                case 1:
                                    Algorithms = (byte)(Algorithms ^ d);                            
                                    break;
                                case 2:
                                    Graphics = (byte)(Graphics ^ d);
                                    break;
                                case 3:
                                    c_sharp = (byte)(c_sharp ^ d);
                                    break;
                                case 4:
                                    Math = (byte)(Math ^ d);
                                    break;
                                case 5:
                                    Eng = (byte)(Eng ^ d);
                                    break;
                            }
                            #endregion
                        }
                        else Console.WriteLine("Введите правильный номер соответсвующий дню недели и предмету");

                    }
                    else Console.WriteLine("Пароль неверный");
                }
                else ch = false;
            }

            ch = true;
            while (ch)
            {
                Console.WriteLine("Хотите посмотреть расписание? (да (Yes), нет (No))");
                string str = Console.ReadLine();
                if (str.Contains("yes"))
                {
                    Console.WriteLine();

                    Console.Write("Введите номер дня недели: ");
                    string s1 = Console.ReadLine();
                    bool result1 = int.TryParse(s1, out day);
                    Console.WriteLine();


                    if ((result1) && (day >= min && day <= maxD))
                    {
                        string newday = Days.New_Day.ToString();
                        #region day
                        switch (day)
                        {
                            case 1:
                                d = (byte)Days.Monday;
                                newday = Days.Monday.ToString();
                                break;
                            case 2:
                                d = (byte)Days.Tuesday;
                                newday = Days.Tuesday.ToString();
                                break;
                            case 3:
                                d = (byte)Days.Wednesday;
                                newday = Days.Wednesday.ToString();
                                break;
                            case 4:
                                d = (byte)Days.Thursday;
                                newday = Days.Thursday .ToString();
                                break;
                            case 5:
                                d = (byte)Days.Friday;
                                newday = Days.Friday.ToString();
                                break;
                            case 6:
                                d = (byte)Days.Saturday;
                                newday = Days.Saturday.ToString();
                                break;
                            case 7:
                                d = (byte)Days.Sunday;
                                newday = Days.Sunday.ToString();
                                break;
                        }
                        #endregion

                        #region lesson
                        Console.Write("On {0} you have: ", newday);
                        if ((byte)(d & Algorithms) > 0)
                        {
                            Console.Write("Algorithms ");
                        }

                        if ((byte)(d & Graphics) > 0)
                        {
                            Console.Write("Graphics ");
                        }

                        if ((byte)(d & c_sharp) > 0)
                        {
                            Console.Write("c_sharp ");
                        }

                        if ((byte)(d & Math) > 0)
                        {
                            Console.Write("Math ");
                        }

                        if ((byte)(d & Eng) > 0)
                        {
                            Console.Write("Eng ");
                        }
                        Console.WriteLine();
                        #endregion
                    }
                    else Console.WriteLine("Введите правильный номер соответсвующий дню недели");
                }
                else ch = false;
            }


            Console.ReadLine();
        }
    }
}
