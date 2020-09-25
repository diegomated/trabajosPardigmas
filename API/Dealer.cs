using System;

namespace API
{
    public class Dealer
    {
        private string[,] deck;
        private string[,] hand;
        private Card cartas;

        public Dealer()
        {
            cartas = new Card();
            hand = new string[10,2];
        }

        public string[,] Deck { get => deck; set => deck = value; }
        public string[,] Hand { get => hand; set => hand = value; }

        public string[,] Generate()
        {
            string[,] baraja;
            baraja = new string[13 * 4,2];
            int cont = 0;
            string[] suit = cartas.Suit;
            string[] symbol = cartas.Symbol;
            int[] valor = cartas.Score;

            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 13; a++)
                {
                    baraja[cont,0] = suit[a] + symbol[i];
                    baraja[cont,1] = valor[a].ToString();
                    cont = cont + 1;
                }
            }
            return baraja;
        }

        public void Randomize()
        {
            string[,] listaC;
            listaC = new string[13*4,2];
            string[,] baraja = Generate();

            Random numeroAlt = new Random();
            int numero;
            int cont = 0;

            while(cont != 52)
            {
                numero = numeroAlt.Next(0, 52);
                if (listaC[numero,0] == null)
                {
                    listaC[numero,0] = baraja[cont,0];
                    listaC[numero,1] = baraja[cont,1];
                    cont = cont + 1;
                }
            }
            deck = listaC;
        }


        public string[] Deal()
        {
            string cont;
            string cont2;
            string[] retorno = new string[2];
            retorno[0] = deck[0, 0];
            retorno[1] = deck[0, 1];

            for (int i = 0; i < 52; i++)
            {
                if (i == 52 - 1)
                {
                    deck[i,0] = "";
                    deck[i,1] = "";
                }
                else
                {
                    cont = deck[i+1,0];
                    cont2 = deck[i+1,1];
                    deck[i,0] = cont;
                    deck[i, 1] = cont2;
                }
            }
            return retorno;
        }

        public void AddCard(string[] carta)
        {
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i,0] == null)
                {
                    hand[i,0] = carta[0];
                    hand[i,1] = carta[1];
                    break;
                }
            }
        }

        public void Init()
        {
            string[] carta1 = Deal();
            string[] carta2 = Deal();

            AddCard(carta1);
            AddCard(carta2);
        }

    }
}
