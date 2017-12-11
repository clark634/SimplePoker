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

    class Card
    {
        public enum SUIT
        {
            HEARTS,
            SPADES,
            DIAMONDS,
            CLUBS
        }
        public enum VALUE
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN,
            EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
        }

        //properties
        public SUIT MySuit { get; set; }
        public VALUE MyValue { get; set; }



    }
}
