using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media;

namespace HraAF {
    class Spawner : Grid {
        public Canvas canvas;
        public Game page;
        public List<Meteor> meteors;
        public Timer Tick;
        public void Init() {
            meteors = new List<Meteor>();
            Tick = new Timer(400);
            Tick.AutoReset = true;
            Tick.Elapsed += Tick_Elapsed;
            Tick.Start();
        }
        private void Tick_Elapsed(object sender, ElapsedEventArgs e) {
            try {
                Dispatcher.Invoke(new Action(() => {
                    //generovani
                    Random r = new Random();
                    Meteor rect = new Meteor();
                    meteors.Add(rect);
                    //nastanevi hodnot
                    rect.c.Fill = new SolidColorBrush(Colors.Red);
                    int size = r.Next() % 40 + 60;
                    rect.Height = rect.Width = rect.c.Width = rect.c.Height = rect.radius = size;
                    rect.init();
                    RotateTransform rotateTransform1 = new RotateTransform(r.Next(360), size/2, size/2);
                    rect.RenderTransform = rotateTransform1;
                    //prirazeni do kolekci a nastaveni polohy
                    canvas.Children.Add(rect);
                    Canvas.SetLeft(rect, r.Next() % 900);
                    Canvas.SetTop(rect, -200);
                    page.objects.Add(rect);
                }), DispatcherPriority.Send);
            } catch { }
        }
    }
}
