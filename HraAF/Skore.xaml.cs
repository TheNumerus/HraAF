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

namespace HraAF {
    /// <summary>
    /// Interaction logic for Skore.xaml
    /// </summary>
    public partial class Skore : Page {
        MainWindow window;
        public Skore() {
            InitializeComponent();
            for (int i = 0; i < RecordsAPI.rekordy.rekordy.GetLength(0); i++) {
                TextBlock tb = new TextBlock();
                tb.Foreground = new SolidColorBrush(Colors.White);
                tb.Text = Helpers.MilisecondsToTime((long)RecordsAPI.rekordy.rekordy[i].rekord);
                SkorePanel.Children.Add(tb);
            }
        }

        public Skore(MainWindow window) {
            this.window = window;
            InitializeComponent();
            for (int i = 0; i < RecordsAPI.rekordy.rekordy.GetLength(0); i++) {
                TextBlock tb = new TextBlock();
                tb.Foreground = new SolidColorBrush(Colors.White);
                tb.Text = Helpers.MilisecondsToTime((long)RecordsAPI.rekordy.rekordy[i].rekord);
                SkorePanel.Children.Add(tb);
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void game_Click(object sender, RoutedEventArgs e) {
            window.StartGame();
        }
    }
}
