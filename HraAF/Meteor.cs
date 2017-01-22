using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HraAF {
    class Meteor : PlayableObject{
        Random r = new Random();
        public Ellipse c = new Ellipse();
        public TextBlock t = new TextBlock();
        bool generated = false;
        int speed = -1;
        override public void ApplyGravity() {
            if (getX() < 1200) {
                if (generated == false) {
                    speed = r.Next()%6 +3;
                    generated = true;
                }
                addX(speed);
            } else {
                addX(-2000);
                setY(r.Next() % 1400);
            }
        }
        public void init() {
            this.Children.Add(c);
            this.Children.Add(t);
            t.Foreground = new SolidColorBrush(Colors.White);
        }
    }
}
