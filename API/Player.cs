using System;

namespace API
{
    public class Player
    {
        private string[] hand;

        public string[] Hand { get => hand; set => hand = value; }

        public void AddCard(string carta)
        {
            Hand = new string[10];
            int cont = 0;
            while (cont < Hand.Length)
            {
                if (Hand[cont] == null)
                {
                    Hand[cont] = carta;
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
