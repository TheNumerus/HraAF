using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HraAF {
    class Meteor : PlayableObject{
        Random r = new Random();
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
    }
}
