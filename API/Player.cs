using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    class Player
    {
        private string[] hand;

        public void AddCard(string carta)
        {
            hand = new string[10];
            int cont = 0;
            while (cont < hand.Length)
            {
                if (hand[cont] == null)
                {
                    hand[cont] = carta;
                    break;
                }
                else
                {
                    cont = cont + 1;
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
