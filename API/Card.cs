using System;

namespace API
{
    public class Card
    {
        private string[] suit;
        private string[] symbol;
        private int[] score;
        private string[] color;
        private string[] prueba;

        public Card()
        {
            suit = new string[14] { "A", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"  };
            symbol = new string[4] { "♥", "♦", "♣", "♠" };
            prueba = new string[14 * 4];
        }


        public string[] Suit { get => suit; set => suit = value; }
        public string[] Symbol { get => symbol; set => symbol = value; }
        public string[] Prueba { get => prueba; set => prueba = value; }
    }
}
