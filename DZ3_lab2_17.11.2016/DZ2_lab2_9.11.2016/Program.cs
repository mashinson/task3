using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2_lab2_9._11._2016
{
    [Flags]
    enum Days : byte// Дни недели 
    {
        New_Day = 0x00,
        Monday = 0x01,       // 0000 0001 
        Tuesday = 0x02,      // 0000 0010
        Wednesday = 0x04,    // 0000 0100
        Thursday = 0x08,     // 0000 1000
        Friday = 0x10,       // 0001 0000
        Saturday = 0x20,     // 0010 0000
        Sunday = 0x40     // 0100 0000
    }

    //enum Lessons : byte   // Предметы
    //{
    //    Algorithms = 0x17,     // 0001 0010
    //    Graphics = 0xC,        // 0000 1100
    //    c_sharp = 0x12,        // 0011 0010            
    //    Math = 0x14,           // 0001 0100
    //    Eng = 0x5             // 0000 0101
    //}


    class Program
    {
        static void Main(string[] args)
        {
            const int min = 1;
            const int maxD = 7;

            Days Algorithms = Days.Monday | Days.Tuesday | Days.Wednesday;
            Days Graphics = Days.Wednesday | Days.Thursday;
            Days c_sharp = Days.Tuesday | Days.Friday | Days.Saturday;
            Days Math = Days.Wednesday | Days.Friday;
            Days Eng = Days.Monday | Days.Wednesday ;
            Days NewDay = Days.New_Day;

            Console.WriteLine("list of lessons:  ");
            Console.WriteLine("Algorithms (1)");
            Console.WriteLine("Graphics (2)");
            Console.WriteLine("c# (3)");
            Console.WriteLine("Math (4)");
            Console.WriteLine("English (5)");
            Console.WriteLine();

            Console.WriteLine("List of Days:  ");
            Console.WriteLine("Monday (1)");
            Console.WriteLine("Tuesday (2)");
            Console.WriteLine("Wednesday (3)");
            Console.WriteLine("Thursday (4)");
            Console.WriteLine("Friday (5)");
            Console.WriteLine("Saturday (6)");
            Console.WriteLine("Sunday (7)");
            Console.WriteLine();

            // номер предмета и номер дня, которые вводит пользователь 

            int lesson = 0,
                 day = 0;


            bool ch = true;  //счетчик который определяет сколько раз смотреть и менять расписание 

            while (ch)
            {
                Console.WriteLine("Do you want to see the schedule?");
                string s3 = Console.ReadLine();
                Console.WriteLine();
                if (s3.Contains("yes"))
                {

                    Console.Write("Enter lesson's number: ");
                    string s4 = Console.ReadLine();
                    bool result3 = int.TryParse(s4, out lesson);
                    Console.WriteLine();

                    if (result3)
                    {
                        switch (lesson)
                        {
                            case 1:
                                Console.WriteLine("Algorithms in {0}", Algorithms);
                                break;
                            case 2:
                                Console.WriteLine("Graphics in {0}", Graphics);
                                break;
                            case 3:
                                Console.WriteLine("с# in {0}", c_sharp);
                                break;
                            case 4:
                                Console.WriteLine("Math in {0}", Math);
                                break;
                            case 5:
                                Console.WriteLine("English in {0}", Eng);
                                break;
                            default:
                                Console.WriteLine("You don't have such lesson");
                                break;
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    ch = false;
                }
            }

                ch = true;  //счетчик который определяет сколько раз смотреть и менять расписание 

                while (ch)
                {
                    Console.WriteLine("Do you want to change the schedule?");
                    string s = Console.ReadLine();
                    Console.WriteLine();
                    if (s.Contains("yes"))
                    {
                        Console.Write("Enter lesson's number: ");
                        string s4 = Console.ReadLine();
                        bool result3 = int.TryParse(s4, out lesson);
                        Console.WriteLine();

                        Console.Write("Enter day's number: ");
                        string s2 = Console.ReadLine();
                        bool result4 = int.TryParse(s2, out day);
                        Console.WriteLine();

                        if (result4 && result3 && day >= min && day <= maxD)
                        {
                            switch (day)
                            {
                                case 1:
                                    NewDay = Days.Monday;
                                    break;
                                case 2:
                                    NewDay = Days.Tuesday;
                                    break;
                                case 3:
                                    NewDay = Days.Wednesday;
                                    break;
                                case 4:
                                    NewDay = Days.Thursday;
                                    break;
                                case 5:
                                    NewDay = Days.Friday;
                                    break;
                                case 6:
                                    NewDay = Days.Saturday;
                                    break;
                                case 7:
                                    NewDay = Days.Sunday;
                                    break;

                            }


                            switch (lesson)
                            {
                                case 1:
                                    Algorithms = Algorithms ^ NewDay;
                                    Console.WriteLine("Algorithms in {0}", Algorithms);
                                    break;
                                case 2:
                                    Graphics = Graphics ^ NewDay;
                                    Console.WriteLine("Graphics in {0}", Graphics);
                                    break;
                                case 3:
                                    c_sharp = c_sharp ^ NewDay;
                                    Console.WriteLine("с# in {0}", c_sharp);
                                    break;
                                case 4:
                                    Math = Math ^ NewDay;
                                    Console.WriteLine("Math in {0}", Math);
                                    break;
                                case 5:
                                    Eng = Eng ^ NewDay;
                                    Console.WriteLine("English in {0}", Eng);
                                    break;
                                default:
                                    Console.WriteLine("You don't have such lesson");
                                    break;
                            }
                        Console.WriteLine();
                        }
                    }
                    else
                    {
                    Console.WriteLine("Wrong day");
                        ch = false;
                    }
                }


                Console.ReadLine();
            }
        }
    }

