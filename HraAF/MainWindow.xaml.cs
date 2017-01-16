using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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
using System.Windows.Threading;

namespace HraAF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public List<PlayableObject> objects = new List<PlayableObject>();
        public MainWindow() {
            InitializeComponent();
            Timer Tick = new Timer(1);
            objects.Add(Player);
            Tick.AutoReset = true;
            Tick.Elapsed += Tick_Elapsed;
            Tick.Start();
            Player.Init();
            Player.window = this;
            SpawnerMeteor.Init();
            SpawnerMeteor.canvas = MainCanvas;
            SpawnerMeteor.window = this;
        }

        public void ResetGame() {
            objects = new List<PlayableObject>();
            objects.Add(Player);
            Canvas.SetTop(Player, 200);
        }
        private void Tick_Elapsed(object sender, ElapsedEventArgs e) {
            try {
                Dispatcher.Invoke(new Action(() => {
                    Keyboard.Focus(Player);
                }), DispatcherPriority.Send);
            } catch { }
            Player.HandleInput();
            try {
                foreach (PlayableObject o in objects) {
                    o.ApplyGravity();
                }
            } catch { }
        }
    }
}
