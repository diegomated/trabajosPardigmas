using System;

namespace API
{
    public class Card
    {
        private string[] suit;
        private string[] symbol;
        private int[] score;
        private string[] color;

        public Card()
        {
            suit = new string[13] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            symbol = new string[4] { "♥", "♦", "♣", "♠" };
            score = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
        }


        public string[] Suit { get => suit; set => suit = value; }
        public string[] Symbol { get => symbol; set => symbol = value; }
        public int[] Score { get => score; set => score = value; }
    }
}
