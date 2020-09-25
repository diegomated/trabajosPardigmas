using System;

namespace API
{
    public class Dealer
    {
        private string[] deck;
        private string[] hand;
        private Card cartas;

        public Dealer()
        {
            cartas = new Card();
            hand = new string[10];
        }

        public string[] Deck { get => deck; set => deck = value; }
        public string[] Hand { get => hand; set => hand = value; }

        public string[] Generate()
        {
            string[] baraja;
            baraja = new string[13 * 4];
            int cont = 0;
            string[] suit = cartas.Suit;
            string[] symbol = cartas.Symbol;
            int[] valor = cartas.Score;

            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 13; a++)
                {
                    baraja[cont] = suit[a] + symbol[i];
                    cont = cont + 1;
                }
            }
            return baraja;
        }

        public void Randomize()
        {
            string[] listaC;
            listaC = new string[13*4];
            string[] baraja = Generate();

            Random numeroAlt = new Random();
            int numero;
            int cont = 0;

            while(cont != listaC.Length)
            {
                numero = numeroAlt.Next(0, listaC.Length);
                if (listaC[numero] == null)
                {
                    listaC[numero] = baraja[cont];
                    cont = cont + 1;
                }
            }
            deck = listaC;
        }


        public string Deal()
        {
            string cont;
            string retorno = deck[0];

            for (int i = 0; i < 52; i++)
            {
                if (i == 52 - 1)
                {
                    deck[i] = "";
                }
                else
                {
                    cont = deck[i+1];
                    deck[i] = cont;
                }
            }
            return retorno;
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

        public void Init()
        {
            string carta1 = Deal();
            string carta2 = Deal();

            AddCard(carta1);
            AddCard(carta2);
        }

    }
}
