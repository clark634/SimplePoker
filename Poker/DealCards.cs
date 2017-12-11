using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePoker
//////////////////////////////////////////////
//AUTHOR: Brandon Clark
//CLASS: CIT 110
//TITLE: SIMPLE Poker
//VERSION: 0.8
//////////////////////////////////////////////
{
    class DealCards : DeckOfCards
    {
        private Card[] PlayerHand;
        private Card[] ComputerHand;
        private Card[] sortedPlayerHand;
        private Card[] sortedComputerHand;

        public DealCards()
        {
            PlayerHand = new Card[5];
            sortedPlayerHand = new Card[5];
            ComputerHand = new Card[5];
            sortedComputerHand = new Card[5];
        }

        public void Deal()
        {
            setUpDeck(); //create the deck of cards and shuffle them
            GetHand();
            SortCards();
            DisplayCards();
            EvaluateHands();
        }

        public void GetHand()
        {
            //5 cards for the player
            for (int i = 0; i < 5; i++)
            {
                PlayerHand[i] = getDeck[i];
            }
            //5 cards for the computer
            for (int i = 5; i < 10; i++)
            {
                ComputerHand[i -5] = getDeck[i];
            }


        }

        public void SortCards()
        {
            var queryPlayer = from hand in PlayerHand
                              orderby hand.MyValue
                              select hand;
            var queryComputer = from hand in ComputerHand
                                orderby hand.MyValue
                                select hand;
            var index = 0;
            foreach(var element in queryPlayer.ToList())
            {
                sortedPlayerHand[index] = element;
                index++;
            }

            index = 0;
            foreach(var element in queryComputer.ToList())
            {
                sortedComputerHand[index] = element;
                index++;
            }

        }

        public void DisplayCards()
        {
            Console.Clear();
            int x = 0; //position of the cursor. left and right.
            int y = 1; // y position of the cursor. up and down.

            //display player hand
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Players Hand");
            for (int i = 0; i < 5; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(sortedPlayerHand[i], x,y);
                x++;
            }
            y = 15;// move the row of computer cards below the players cards.
            x = 0; //reset the x position
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Computers Hand");
            for (int i = 5; i < 10; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(sortedComputerHand[i - 5], x, y);
                x++;//move to the right
            }
        }

        public void EvaluateHands()
        {
            //create players and computers evaluation objects (passing SORTED hand to constructor
            HandEvaluator playerHandEvaluator = new HandEvaluator(sortedPlayerHand);
            HandEvaluator computerHandEvaluator = new HandEvaluator(sortedComputerHand);

            // get the players and computers hand
            Hand PlayerHand = playerHandEvaluator.EvaluateHand();
            Hand ComputerHand = computerHandEvaluator.EvaluateHand();

            //display each hand
            Console.WriteLine("\n\n\n\n\nPlayers Hand: " + PlayerHand);
            Console.WriteLine("\nComputers Hand: "+ComputerHand);

            //evaluate hands
            if(PlayerHand > ComputerHand)
            {
                Console.WriteLine("Player Wins!");
            }
            else if (PlayerHand < ComputerHand)
            {
                Console.WriteLine("Computer Wins!");
            }


            else // if the hands are the same, evaluate the values
            {
                //first evaluate who has higher hand value
                if (playerHandEvaluator.HandValues.Total > computerHandEvaluator.HandValues.Total)
                {
                    Console.WriteLine("Player Wins!");

                }
                else if (playerHandEvaluator.HandValues.Total < computerHandEvaluator.HandValues.Total)
                {
                    Console.WriteLine("Computer Wins!");
                }
                

                //if both have the same hand
                //next highest card wins
                else if (playerHandEvaluator.HandValues.HighCard > computerHandEvaluator.HandValues.HighCard)
                {
                    Console.WriteLine("Player Wins!");
                }
                else if (playerHandEvaluator.HandValues.HighCard < computerHandEvaluator.HandValues.HighCard)
                {
                    Console.WriteLine("Computer Wins!");
                }

                else
                    Console.WriteLine("DRAW!");

            }
        }


    }
}
