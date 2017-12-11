using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePoker
{

    //////////////////////////////////////////////
    //AUTHOR: Brandon Clark
    //CLASS: CIT 110
    //TITLE: SIMPLE Poker
    //VERSION: 0.8
    //////////////////////////////////////////////

    //SOURCE https://www.youtube.com/watch?v=Q6R3g4yXr98

    
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(65, 40);
            //remove scroll bars by setting buffer to the actual window size
            Console.BufferWidth =65;
            Console.BufferHeight =40;
            Console.Title = "Poker Game";
            DealCards dc = new DealCards();
            bool quit = false;

            while (!quit)
            {
                dc.Deal();

                char selection = ' ';
                while (!selection.Equals('Y') && !selection.Equals('N'))
                {
                    Console.WriteLine("Play again? (Y/N)");
                    selection = Convert.ToChar(Console.ReadLine().ToUpper());

                    if (selection.Equals('Y'))
                    {
                        quit = false;
                    }
                    else if (selection.Equals('N'))
                    {
                        quit = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Selection. Try again.");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
