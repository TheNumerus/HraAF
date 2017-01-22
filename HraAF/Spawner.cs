﻿using System;
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
        public MainWindow window;
        public List<Meteor> meteors;
        public void Init() {
            meteors = new List<Meteor>();
            Timer Tick = new Timer(400);
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
                    rect.Height = rect.Width = rect.c.Width = rect.c.Height = r.Next() % 40 + 60;
                    rect.init();
                    //RotateTransform rotateTransform1 = new RotateTransform(r.Next() % 360, rect.Height / 2, rect.Width / 2);
                    //rect.RenderTransform = rotateTransform1;
                    //prirazeni do kolekci a nastaveni polohy
                    canvas.Children.Add(rect);
                    Canvas.SetLeft(rect, r.Next() % 1300);
                    Canvas.SetTop(rect, -400);
                    window.objects.Add(rect);
                }), DispatcherPriority.Send);
            } catch { }
        }
    }
}
