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
        public Skore() {
            InitializeComponent();
            for (int i = 0; i < RecordsAPI.rekordy.rekordy.GetLength(0); i++) {
                TextBlock tb = new TextBlock();
                tb.Text = RecordsAPI.rekordy.rekordy[i].rekord.ToString();
                SkorePanel.Children.Add(tb);
            }
        }
    }
}
