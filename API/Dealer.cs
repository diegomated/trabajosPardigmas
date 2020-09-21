using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    class Dealer
    {
        private string[] deck;
        private string[] hand;
        private Card cartas;

        public Dealer()
        {
            cartas = new Card();
        }

        public string[] Deck { get => deck; set => deck = value; }
        public string[] Hand { get => hand; set => hand = value; }

        public string[] Generate()
        {
            string[] baraja;
            baraja = new string[14 * 4];
            int cont = 0;
            string[] suit = cartas.Suit;
            string[] symbol = cartas.Symbol;

            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 14; a++)
                {
                    baraja[cont] = suit[a] + symbol[i];
                }
            }
            return baraja;
        }

        public void Randomize()
        {
            string[] listaC;
            listaC = new string[14*4];
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

            for(int i = 0; i < deck.Length-1; i++)
            {
                cont = deck[i + 1];
                deck[i] = cont;
            }
            
            return retorno;
        }

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

        public void Init()
        {
            string carta1 = Deal();
            string carta2 = Deal();

            AddCard(carta1);
            AddCard(carta2);
        }

    }
}
