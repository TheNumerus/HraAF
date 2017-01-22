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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public List<PlayableObject> objects = new List<PlayableObject>();
        public Stopwatch begin;
        public MainWindow() {
            InitializeComponent();
            begin = Stopwatch.StartNew();
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

        string MilisecondsToTime (long miliseconds) {
            int seconds = (int)(miliseconds / 1000);
            int remMiliseconds = (int)(miliseconds - (long)seconds*1000);
            int minutes = seconds / 60;
            seconds -= minutes * 60;
            String output = minutes + ":";

            if (seconds > 9) {
                output += seconds;
            } else {
                output += "0" + seconds;
            }
            output += ":";
            if (remMiliseconds > 99) {
                output += remMiliseconds;
            } else if (remMiliseconds > 9 && remMiliseconds < 100) {
                output += "0" + remMiliseconds;
            } else {
                output += "00" + remMiliseconds;
            }
            return output;
        }

        private void Tick_Elapsed(object sender, ElapsedEventArgs e) {
            try {
                Dispatcher.Invoke(new Action(() => {
                    Keyboard.Focus(Player);
                    cas.Text = MilisecondsToTime(begin.ElapsedMilliseconds);
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
