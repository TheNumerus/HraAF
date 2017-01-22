using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HraAF {
    class Meteor : PlayableObject{
        Random r = new Random();
        public Ellipse c = new Ellipse();
        public TextBlock t = new TextBlock();
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
                setColor(true);
                setX(-200);
                setY(r.Next() % 900);
            }
        }
        public void init() {
            this.Children.Add(c);
            this.Children.Add(t);
            t.Foreground = new SolidColorBrush(Colors.White);
        }
        public void setColor(bool reset) {
            Dispatcher.Invoke(new Action(() => {
                if (!reset) {
                    c.Fill = new SolidColorBrush(Colors.Green);
                } else {
                    c.Fill = new SolidColorBrush(Colors.Red);
                }
            }), DispatcherPriority.Send);
        }
    }
}
