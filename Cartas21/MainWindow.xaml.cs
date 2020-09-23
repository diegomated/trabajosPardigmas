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

        }
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string[] baraja = d.Deck;
            string texto1;
            string texto2 = "";

            txtcarta2.Text = d.Deck[0];

            for(int i = 0; i < baraja.Length; i++)
            {
                texto1 = baraja[i];
                texto2 = texto2 + ", " + texto1;
            }

            prueba.Text = texto2;

            
            string carta1 = d.Deal();
            p.AddCard(carta1);

            txtcarta1.Text = p.Hand[0];
        }

    }
}
