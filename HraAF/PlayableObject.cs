using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HraAF {
    public class PlayableObject : Grid {
        virtual public void ApplyGravity() {
            if (getX() < 1200) {
                addX(3);
            }
        }

        public void addX(int number) {
            try {
                Dispatcher.Invoke(new Action(() => {
                    Canvas.SetTop(this, Canvas.GetTop(this) + number);
                }), DispatcherPriority.Send);
            } catch { }
        }

        public void addY(int number) {
            try {
                Dispatcher.Invoke(new Action(() => {
                    Canvas.SetLeft(this, Canvas.GetLeft(this) + number);
                }), DispatcherPriority.Send);
            } catch { }
        }

        public void setX(int number) {
            try {
                Dispatcher.Invoke(new Action(() => {
                    Canvas.SetTop(this, number);
                }), DispatcherPriority.Send);
            } catch { }
        }

        public void setY(int number) {
            try {
                Dispatcher.Invoke(new Action(() => {
                    Canvas.SetLeft(this, number);
                }), DispatcherPriority.Send);
            } catch { }
        }

        public int getX() {
            int value = -1;
            try {
                Dispatcher.Invoke(new Action(() => {
                    value = (int)Canvas.GetTop(this);
                }), DispatcherPriority.Send);
            } catch { }
            return value;
        }

        public int getY() {
            int value = -1;
            try {
                Dispatcher.Invoke(new Action(() => {
                    value = (int)Canvas.GetLeft(this);
                }), DispatcherPriority.Send);
            } catch { }
            return value;
        }
    }
}
