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

namespace App_MultiThreading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Task_Click(object sender, RoutedEventArgs e)
        {
            //DoWork();
            //Creazione di un thread
            Task.Factory.StartNew(DoWork);
        }

        private void DoWork()
        {
            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 10000; j++)
                {

                }
            }

            //AggiornaInterfaccia();
            Dispatcher.Invoke(AggiornaInterfaccia);
        }

        private void AggiornaInterfaccia()
        {
            throw new NotImplementedException();
        }

        private void AggiornaInterfaccia(int j)
        {
            Lbl_Risultato.Content = "Finito";
        }

        private void Btn_Conta_Click(object sender, RoutedEventArgs e)
        {
            //DoCount();
            Task.Factory.StartNew(AggiornaInterfaccia);
        }

        private void DoCount()
        {
            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 10000; j++)
                {
                    Dispatcher.Invoke(() => AggiornaInterfaccia(j));
                }
            }
        }

        private void AggiornaInterfacia(int j)
        {
            Lbl_Conteggio.Content = j.ToString();
        }
    }
}
