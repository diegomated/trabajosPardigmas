using System;

namespace API
{
    public class Player
    {
        private string[,] hand;
        
        public string[,] Hand { get => hand; set => hand = value; }

        public Player()
        {
            Hand = new string[10,2];
            for(int i = 0; i < 10; i++)
            {
                Hand[i, 1] = "0";
            }
        }

        public void AddCard(string[] carta)
        {
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i,0] == null)
                {
                    hand[i,0] = carta[0];
                    hand[i, 1] = carta[1];
                    break;
                }
            }
        }

        public void Init(string[] carta1, string[] carta2)
        {
            AddCard(carta1);
            AddCard(carta2);
        }


    }
}
