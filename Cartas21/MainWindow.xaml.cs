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
            JuegoInicio();
            
        }
        
        private void JuegoInicio()
        {
            d.Randomize();

            string[] carta1 = d.Deal();
            string[] carta2 = d.Deal();
            p.Init(carta1, carta2);

            txtcarta1.Text = p.Hand[0, 0];
            txtcarta2.Text = p.Hand[1, 0];
            txtValor1.Text = (Int16.Parse(p.Hand[0, 1]) + Int16.Parse(p.Hand[1, 1])).ToString();

            int valorCartas = Int16.Parse(txtValor1.Text);
            valorCartas = revisar(valorCartas, p.Hand);
            txtValor1.Text = valorCartas.ToString();

            if (valorCartas == 21)
            {
                reiniciar();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            p.AddCard(d.Deal());

            txtValor1.Text = "";

            txtcarta3.Text = p.Hand[2, 0];
            txtcarta4.Text = p.Hand[3, 0];
            txtcarta5.Text = p.Hand[4, 0];
            txtcarta6.Text = p.Hand[5, 0];
            txtcarta7.Text = p.Hand[6, 0];
            txtValor1.Text = (Int16.Parse(p.Hand[0, 1])+ Int16.Parse(p.Hand[1, 1])+ Int16.Parse(p.Hand[2, 1])+ Int16.Parse(p.Hand[3, 1])+ Int16.Parse(p.Hand[4, 1]) + Int16.Parse(p.Hand[5, 1]) + Int16.Parse(p.Hand[6, 1])).ToString();
            int valorCartas = Int16.Parse(txtValor1.Text);

            valorCartas = revisar(valorCartas, p.Hand);
            txtValor1.Text = valorCartas.ToString();

            if (valorCartas == 21)
            {
                MessageBox.Show("Has ganado esta ronda, Felicidades");
                txtRondasG.Text = (Int16.Parse(txtRondasG.Text) + 1).ToString();
                reiniciar();
            }
            else if(valorCartas > 21)
            {
                MessageBox.Show("Has perdido esta ronda, Te pasaste de 21");
                txtRondasP.Text = (Int16.Parse(txtRondasP.Text) + 1).ToString();
                reiniciar();
            }
        }

        private void btnPtr_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("EL Dealer roba 2 cartas");

            int valorCartasPlayer = Int16.Parse(txtValor1.Text);

            d.Init();
            txtcartaD1.Text = d.Hand[0, 0];
            txtcartaD2.Text = d.Hand[1, 0];

            txtValor2.Text = (Int16.Parse(d.Hand[0, 1]) + Int16.Parse(d.Hand[1, 1])).ToString();
            int valorCartas = Int16.Parse(txtValor2.Text);

            if (valorCartas == 21)
            {
                MessageBox.Show("Has perdido, el Dealer hiso 21");
                valorCartas = 0;
                txtRondasP.Text = (Int16.Parse(txtRondasP.Text) + 1).ToString();
                reiniciar();
            }
            else
            {
                if (valorCartas > 0)
                {
                    valorCartas = RobarCartas(txtcartaD3, 2, valorCartas, valorCartasPlayer);
                }
                if (valorCartas > 0)
                {
                    valorCartas = RobarCartas(txtcartaD4, 3, valorCartas, valorCartasPlayer);
                }
                if (valorCartas > 0)
                {
                    valorCartas = RobarCartas(txtcartaD5, 4, valorCartas, valorCartasPlayer);
                }
                if (valorCartas > 0)
                {
                    valorCartas = RobarCartas(txtcartaD6, 5, valorCartas, valorCartasPlayer);
                }
                if (valorCartas > 0)
                {
                    valorCartas = RobarCartas(txtcartaD7, 6, valorCartas, valorCartasPlayer);
                }
            }
        }
        

        public int RobarCartas(TextBox bloque, int numCarta, int valorCartas, int valorCartaP)
        {

            MessageBox.Show("El Dealer roba 1 carta");
            d.AddCard(d.Deal());
            bloque.Text = d.Hand[numCarta, 0];

            int valorCard = Int16.Parse(d.Hand[numCarta, 1]);
            txtValor2.Text = (valorCartas + valorCard).ToString();
            valorCartas = Int16.Parse(txtValor2.Text);

            valorCartas = revisar(valorCartas, d.Hand);
            txtValor2.Text = valorCartas.ToString();

            if (valorCartas == 21)
            {
                MessageBox.Show("Has perdido, el Dealer hiso 21");
                valorCartas = 0;
                txtRondasP.Text = (Int16.Parse(txtRondasP.Text) + 1).ToString();
                reiniciar();
            }
            else if (valorCartas >= valorCartaP && valorCartas < 21)
            {
                MessageBox.Show("Has perdido, el Delaer saco una mejor mano que tu");
                valorCartas = 0;
                txtRondasP.Text = (Int16.Parse(txtRondasP.Text) + 1).ToString();
                reiniciar();
            }
            else if (valorCartas > 21)
            {
                MessageBox.Show("Has ganado, el Dealer se paso de 21");
                valorCartas = 0;
                txtRondasG.Text = (Int16.Parse(txtRondasG.Text) + 1).ToString();
                reiniciar();
            }
            return valorCartas;
        }

        public void reiniciar()
        {
            txtcarta1.Text = "";
            txtcarta2.Text = "";
            txtcarta3.Text = "";
            txtcarta4.Text = "";
            txtcarta5.Text = "";
            txtcarta6.Text = "";
            txtcarta7.Text = "";
            txtcartaD1.Text = "";
            txtcartaD2.Text = "";
            txtcartaD3.Text = "";
            txtcartaD4.Text = "";
            txtcartaD5.Text = "";
            txtcartaD6.Text = "";
            txtcartaD7.Text = "";
            txtValor1.Text = "";
            txtValor2.Text = "";
            d = new Dealer();
            p = new Player();
            JuegoInicio();
        }

        public int revisar(int valorCartas, string[,] mano)
        {
            string[,] baraja = mano;
            int valores = valorCartas;

            for(int i = 0; i < 10 / 2; i++)
            {
                if(mano[i,1] == "11" && valores>21)
                {
                    valores = valores - 10;
                }

            }
            return valores;
        }

    }
}
