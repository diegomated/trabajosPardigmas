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
            string carta1 = d.Deal();
            string carta2 = d.Deal();
            p.Init(carta1, carta2);

            txtcarta1.Text = p.Hand[0];
            txtcarta2.Text = p.Hand[1];
        }
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string[] baraja = d.Deck;
            string texto1;
            string texto2 = "";

            for(int i = 0; i < 52; i++)
            {
                texto1 = baraja[i];
                texto2 = texto2 + ", " + texto1;
            }
            prueba.Text = texto2;

        }

    }
}
