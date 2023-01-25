using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.IO;
using TheBlackTale.Client;

namespace TheBlackTale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                ClientHandler.Connect();

                ClientHandler.Send("wow cool");
                Thread.Sleep(4000);
                ClientHandler.Send("really cool");
            }
            catch(Exception ex)
            {
                StreamWriter sw = new("log.txt");
                sw.WriteLine(ex.Message);
                sw.Close();
            }
            InitializeComponent();
        }
    }
}
