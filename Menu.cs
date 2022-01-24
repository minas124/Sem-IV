using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_zaliczeniowy_parydygmaty
{
    class Menu
    { /// <summary>
      /// Class represents menu in application
      /// </summary>
            string[] elements;
            public string ile;
            public int dlugosc;

            /// <summary>
            ///  Creates Menu object with given elements
            /// </summary>
            /// <param name="menuElements">Array if elements in menu object</param>
            public Menu(string[] menuElements)
            {
                if (menuElements != null && menuElements.Length > 0)
                    this.elements = menuElements;
                else
                    this.elements = new string[] { "Example element", "Example element2", "Example element3" };
                var longest = this.elements.Where(s => s.Length == this.elements.Max(m => m.Length)).First(); //sprawdzanie dlugosci elementu w menu
                ile = longest;
                for (int i = 0; i <= ile.Length; i++)
                {
                    dlugosc = i;
                }

            }


            public int ShowMenu()
            {


                int number = 0;
                ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
                Console.CursorVisible = false;
                
            while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape)
                {

                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < elements.Length; i++)
                    {

                        if (i != number)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                    
                    Console.WriteLine(elements[i].PadRight(dlugosc + 1));  //zamiana wartosci na sprawdzona długość menu
                    }

                    keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.UpArrow && number > 0)
                    {
                        number--;
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow && number < elements.Length - 1)
                    {
                        number++;
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        number = -1;
                    }
                }


                Console.CursorVisible = true;
                Console.ResetColor();
                return number;
            }
        }
    }

