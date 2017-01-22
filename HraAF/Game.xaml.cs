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
using System.Diagnostics;

namespace HraAF {
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Page {
        public MainWindow window;
        public List<PlayableObject> objects = new List<PlayableObject>();
        public Stopwatch begin;
        Timer Tick = new Timer(1);
        public Game() {
            InitializeComponent();
        }

        public Game(MainWindow window) {
            InitializeComponent();
            begin = Stopwatch.StartNew();
            objects.Add(Player);
            Tick.AutoReset = true;
            Tick.Elapsed += Tick_Elapsed;
            Tick.Start();
            Player.Init();
            Player.page = this;
            SpawnerMeteor.Init();
            SpawnerMeteor.canvas = MainCanvas;
            SpawnerMeteor.page = this;
            this.window = window;
        }

        public void ResetGame() {
            //zastaveni spawnu a ticku
            Tick.Stop();
            SpawnerMeteor.Tick.Stop();
            foreach (PlayableObject o in objects) {
                MainCanvas.Children.Remove(o);
            }
            //ulozeni casu
            
            RecordsAPI.addRecord(begin.ElapsedMilliseconds);
            begin.Stop();
            window.ResetGame();
        }

        private void Tick_Elapsed(object sender, ElapsedEventArgs e) {
            try {
                Dispatcher.Invoke(new Action(() => {
                    Keyboard.Focus(Player);
                    cas.Text = Helpers.MilisecondsToTime(begin.ElapsedMilliseconds);
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
