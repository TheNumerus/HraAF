using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HraAF {
    class Meteor : PlayableObject{
        Random r = new Random();
        public Rectangle c = new Rectangle();
        public int radius;
        bool generated = false;
        int speed = -1;
        override public void ApplyGravity() {
            if (getX() < 700) {
                if (generated == false) {
                    speed = r.Next()%6 +3;
                    generated = true;
                }
                addX(speed);
            } else {
                setX(-200);
                setY(r.Next() % 900);
            }
        }
        public void init() {
            this.Children.Add(c);
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("pack://application:,,,/HraAF;component/0017.png");
            logo.EndInit();
            c.Fill = new ImageBrush(logo);
        }
    }
}
