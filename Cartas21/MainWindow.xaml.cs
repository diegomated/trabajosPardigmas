using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cartas21
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dealer d = new Dealer();
        Player p = new Player();

        public MainWindow()
        {
            InitializeComponent();
            d.Randomize();

            string[,] baraja = d.Deck; //
            string texto1;
            string texto2 = "";

            for (int i = 0; i < 52; i++)
            {
                texto1 = baraja[i,0];
                texto2 = texto2 + ", " + texto1;
            }
            prueba.Text = texto2; //

            string[] carta1 = d.Deal();
            string[] carta2 = d.Deal();
            p.Init(carta1, carta2);

            
            txtcarta1.Text = p.Hand[0,0];
            txtcarta2.Text = p.Hand[1,0];
            int valorCard1 = Int16.Parse(p.Hand[0, 1]);
            int valorCard2 = Int16.Parse(p.Hand[1, 1]);

            txtValor1.Text = (valorCard1 + valorCard2).ToString();
        }
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string[] carta = d.Deal();
            p.AddCard(carta);

            txtValor1.Text = "";

            txtcarta3.Text = p.Hand[2, 0];
            txtcarta4.Text = p.Hand[3, 0];
            txtcarta5.Text = p.Hand[4, 0];
            int valorCard1 = Int16.Parse(p.Hand[0, 1]);
            int valorCard2 = Int16.Parse(p.Hand[1, 1]);
            int valorCard3 = Int16.Parse(p.Hand[2, 1]);
            int valorCard4 = Int16.Parse(p.Hand[3, 1]);
            int valorCard5 = Int16.Parse(p.Hand[4, 1]);
            txtValor1.Text = (valorCard1 + valorCard2 + valorCard3 + valorCard4 + valorCard5).ToString();
            int valorCartas = Int16.Parse(txtValor1.Text);

            if (valorCartas == 21)
            {
                MessageBox.Show("Has ganado esta ronda, Felicidades");
            }
            else if(valorCartas > 21)
            {
                MessageBox.Show("Has perdido esta ronda, Te pasaste de 21");
            }

        }

        private void btnPtr_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("EL Dealer roba 2 cartas");

            int valorCartasPlayer = Int16.Parse(txtValor1.Text);

            d.Init();
            txtcartaD1.Text = d.Hand[0, 0];
            txtcartaD2.Text = d.Hand[1, 0];

            int valorCard1 = Int16.Parse(d.Hand[0, 1]);
            int valorCard2 = Int16.Parse(d.Hand[1, 1]);
            txtValor2.Text = (valorCard1 + valorCard2).ToString();
            int valorCartas = Int16.Parse(txtValor2.Text);

            if (valorCartas == 21)
            {
                MessageBox.Show("Has perdido, el Dealer hiso 21");
            }

            MessageBox.Show("El Dealer roba 1 carta");
            string[] carta3 = d.Deal();
            d.AddCard(carta3);
            txtcartaD3.Text = d.Hand[2, 0];

            int valorCard3 = Int16.Parse(d.Hand[2,1]);
            txtValor2.Text = (valorCartas + valorCard3).ToString();
            valorCartas = Int16.Parse(txtValor2.Text);

            if (valorCartas == 21)
            {
                MessageBox.Show("Has perdido, el Dealer hiso 21");
            }
            else if(valorCartas>=valorCartasPlayer && valorCartas < 21)
            {
                MessageBox.Show("Has perdido, el Delaer saco una mejor mano que tu");
            }
            else if (valorCartas > 21)
            {
                MessageBox.Show("Has ganado, el Dealer se paso de 21");
            }

            MessageBox.Show("El Dealer roba 1 carta");
            string[] carta4 = d.Deal();
            d.AddCard(carta4);
            txtcartaD4.Text = d.Hand[3, 0];

            int valorCard4 = Int16.Parse(d.Hand[3, 1]);
            txtValor2.Text = (valorCartas + valorCard4).ToString();
            valorCartas = Int16.Parse(txtValor2.Text);

            if (valorCartas == 21)
            {
                MessageBox.Show("Has perdido, el Dealer hiso 21");
            }
            else if (valorCartas >= valorCartasPlayer && valorCartas < 21)
            {
                MessageBox.Show("Has perdido, el Delaer saco una mejor mano que tu");
            }
            else if (valorCartas > 21)
            {
                MessageBox.Show("Has ganado, el Dealer se paso de 21");
            }

            MessageBox.Show("El Dealer roba 1 carta");
            string[] carta5 = d.Deal();
            d.AddCard(carta5);
            txtcartaD4.Text = d.Hand[4, 0];

            int valorCard5 = Int16.Parse(d.Hand[4, 1]);
            txtValor2.Text = (valorCartas + valorCard4).ToString();
            valorCartas = Int16.Parse(txtValor2.Text);

            if (valorCartas == 21)
            {
                MessageBox.Show("Has perdido, el Dealer hiso 21");
            }
            else if (valorCartas >= valorCartasPlayer && valorCartas < 21)
            {
                MessageBox.Show("Has perdido, el Delaer saco una mejor mano que tu");
            }
            else if (valorCartas > 21)
            {
                MessageBox.Show("Has ganado, el Dealer se paso de 21");
            }

        }
    }
}
