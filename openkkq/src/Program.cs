using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace openkkq
{
    /*                         
     OPENKKQ 0.2
     14.07.2011: с мобилы (sic!) сделана основа, есть база для заебенной системы команд
     15.07.2011: перевел код в проект, нописал ченжлог
         
     OPENKKQ 0.3

     2?.07.2011: запланирована система монет
     06.08.2011: сурс публичный
     10.08.2011: сорта колбасы
         
         
         
   
         
         
         
         
    */
    public partial class program
    {

       

        public static void Main()
        {

         
            currtype = kolblist.Find(kolbtype => kolbtype.name == "колбасная");
            Console.Title = "openkkq 02";


            //меню
          //  Console.Clear();
            Console.WriteLine("OPENKKQ: МОБИЛЬНАЯ ВЕРСИЯ");
            Console.WriteLine("08.02.2005");
            Console.WriteLine("(начать)");   
            string preaction = Console.ReadLine();
            Console.Clear();

            if (preaction == "начать")
            {
                Console.WriteLine("(колбаса)");
                game();

            }

            Main();
        }



        //-------------------
      
        static string kk = "колбаса";

        static int kpa = 1;

        static int m = 4;

        static int money = 1;

        static bool[] u1 = new bool[4];


        static kolbtype currtype = new kolbtype { };
        public static List<kolbtype> kolblist = new List<kolbtype>
        {
             new kolbtype{name = "колбасная", cost = 1, amount = 0},
            new kolbtype{name = "гникивийская", cost = 1 },
             new kolbtype{name = "юморная", cost = 16 }
        };
    
   

        //-------------------
        public static void game()
        {
        
            // string 
            intf();
            string action = Console.ReadLine();
            comm line = new comm(action.ToLower());
            string main = line.main;
            string arg = line.getkey(0);
          
            //П А С К А Л Ь К Е Й С  Н Е Н У Ж О Н 

            switch (line.main.ToLower())
            {
                /*-------------------*/
                case "сорт":
                    if (line.ArgsCount == 1)
                    {
                        try
                        {
                            kolbtype a = kolblist.Find(kolbtype => kolbtype.name == line.getkey(0));
                            if (a != null)
                            {
                                currtype = a;
                           }
                            else
                            {
                                Console.WriteLine("не наиден");
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("не наиден");
                        }
                    }
                    else
                    {

                        Console.WriteLine("(сорт (имя))");
                        Console.WriteLine(currtype.name);
                    }
                    break;
                /*-------------------*/
                case "сорта":
                 foreach(kolbtype a in kolblist)
                    {
                        Console.WriteLine($"{a.amount} {a.name} (цена {a.cost})");
                    }
                    break;
                /*-------------------*/
                case "сделать":
                 try
                    {
                        switch(line.getkey(0))
                        {
                            case "сорт":
                                kolbtype a = new kolbtype { name = "новоя", cost = 1 };
                                a.name = line.getkey(1);
                                a.cost = Convert.ToInt32(line.getkey(2));
                                kolblist.Add(a);
                                break;

                            case "приколюху":

                                break;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("не ьвыьшло........");
                    }
                    break;
                /*-------------------*/
                case "читы":
                    try
                    {
                        if (line.ArgsCount >= 1)
                        {
                            if (line.getkey(1) == null)
                            {
                                int kolb = Convert.ToInt32(line.getkey(0));
                                currtype.amount += kolb;
                            }

                            if (line.ArgsCount >= 2)
                            {
                                if (line.getkey(0) == "колбаса")
                                {
                                    int numb = Convert.ToInt32(line.getkey(1));
                                    currtype.amount += numb;
                                }
                                if (line.getkey(0) == "деньги")
                                {
                                    int numb = Convert.ToInt32(line.getkey(1));
                                    money += numb;
                                }
                            }

                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("ИДИ НАХУЙ");
                    }
                    break;
                /*-------------------*/
                case "продать":
                    if (line.getkey(0) == "колбасу")
                    {
                        if (currtype.amount > 0)
                        {
                            sell();
                        }
                        else
                        {
                            Console.WriteLine("а нечего продавать-то");
                        }
                      
                    }
                    break;
                /*-------------------*/
                case "колбаса":
                    if (m > 0)
                    {
                        currtype.amount += kpa;
                        if (currtype.amount < 0)
                        {
                            Console.WriteLine("колбасная сингулярность ослаблена");
                        }
                    }
                    else
                    {
                        Console.WriteLine("нету мяса........");
                    }
                    break;
                /*-------------------*/
                case "купить":
                   if(line.ArgsCount >= 1)
                    {
                        switch(line.getkey(0))
                        {
                            case "ножницы":
                                if (money >= 8)
                                {
                                    money -= 8;
                                    kpa *= 2;
                                    Console.WriteLine("куплены");
                                }
                                else
                                {
                                    Console.WriteLine("недостаточьно денег!!!!");
                                }
                                break;
                            case "мясо":
                                if (money > 0)
                                {
                                  
                                    if (line.getkey(1) != null)
                                    {
                                        try
                                        {
                                            int a = Convert.ToInt32(line.getkey(1));
                                            if (money >= a)
                                                {
                                                if (a >= 0)
                                                {
                                                    m += a;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("еггог");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("недостаточьно денег!!!!");
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("еггог");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("недостаточьно денег!!!!");
                                }
                                break;

                        }
                    }
                    break;
                /*-------------------*/
                case "чек":
                  
                    Console.WriteLine($"{currtype.amount} колбасы сорта {currtype.name}");
                    Console.WriteLine($"{money} деняг");
                    Console.WriteLine($"{m} мяса");
                    break;
                /*-------------------*/
                case "магазин":

                    Console.WriteLine("тестовыи магазин");
                    Console.WriteLine("(купить (предмет))");
                    Console.WriteLine("ножницы - 8 денях");
                    Console.WriteLine("бумага - 16 денях");
                    Console.WriteLine("постбинарный конвертер колбасных полей - 32 денях");

                    break;
                /*-------------------*/
                default:
                    Console.WriteLine("енге");
                    break;
                /*оформление by DJ_ikonnikov*/
            }
          
            game();
        }
        
        public static void sell()
        {
            Console.WriteLine("скоьлько");
            try
            {
                string selltext = Console.ReadLine();
                if(selltext == "все")
                {
                    money += currtype.amount * currtype.cost;
                    currtype.amount -= currtype.amount;
                    return;
                }

                int sellCount = Int32.Parse(selltext);

                if (sellCount <= currtype.amount && sellCount >= 0)
                {
                    currtype.amount -= sellCount;
                    money += sellCount * currtype.cost;
                }
                else
                {
                    currtype.amount -= sellCount;
                    Console.WriteLine($"получено антиколбасы: {currtype.amount}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("еггог");
            }
         
            game();
        }
        public static void typechng(string kind)
        {

        }
        static int y;
        static int actioncount;
        public static void intf()
        {
            int xdef = Console.CursorLeft;
            int ydef = Console.CursorTop;

            Console.SetCursorPosition(50, y);
            
            Console.Write(currtype.amount);

            Console.SetCursorPosition(xdef, ydef);
        }
     
     


    }

    //игра заканчивается тут
}