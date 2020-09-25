using System;

namespace API
{
    public class Player
    {
        private string[] hand;
        
        public string[] Hand { get => hand; set => hand = value; }

        public Player()
        {
            Hand = new string[10];
        }

        public void AddCard(string carta)
        {
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i] == null)
                {
                    hand[i] = carta;
                    break;
                }
            }
        }

        public void Init(string carta1, string carta2)
        {
            AddCard(carta1);
            AddCard(carta2);
        }


    }
}
