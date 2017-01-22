using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace HraAF {
    class Player : PlayableObject {
        List<Key> _pressedKeys = new List<Key>();
        public Game page;
        public void Init() {
            this.KeyDown += AddKey;
            this.KeyUp += RemoveKey;
            this.Focusable = true;
        }

        public override void ApplyGravity() {
            addX(3);
            if (getX() > 800) {
                Dispatcher.Invoke(new Action(() => {
                    page.begin.Stop();
                    page.ResetGame(); 
                }), DispatcherPriority.Send);
            }
        }

        private void AddKey(object sender, KeyEventArgs e) {
            if (_pressedKeys.Contains(e.Key)) {
            } else {
                _pressedKeys.Add(e.Key);
            }
        }

        public void HandleInput() {
            HandleCollisions();
            if (_pressedKeys.Contains(Key.Left) && getY() > 0) {
                addY(-5);
            }
            if (_pressedKeys.Contains(Key.Right) && getY() < 1245) {
                addY(5);
            }
            if (_pressedKeys.Contains(Key.Up)) {
                addX(-6);
            }
            if (_pressedKeys.Contains(Key.Down)) {
                addX(6);
            }
        }

        public void HandleCollisions() {
            try {
                foreach (Meteor m in page.SpawnerMeteor.meteors) {
                    if (getDistance(m) < m.radius-20) {
                        Dispatcher.Invoke(new Action(() => {
                            page.begin.Stop();
                            page.ResetGame();
                            m.setColor(false);
                        }), DispatcherPriority.Send);
                    }
                }
            } catch { }
        }
        public float getDistance(Meteor m) {
            float output = 9001;
            float playerY = (float)getY()+ (float)7.5;
            float meteorY = m.getY();
            meteorY += m.radius / 2;
            if (Math.Abs(playerY - meteorY) < 100) {
                float playerX = getX();
                float meteorX = m.getX() + m.radius / 2;
                output = (float)Math.Sqrt(Math.Abs(Math.Pow(playerX - meteorX,2)) + Math.Abs(Math.Pow(playerY - meteorY,2)));
                /*Dispatcher.Invoke(new Action(() => {
                    m.t.Text = output.ToString();
                }), DispatcherPriority.Send);*/
            }
            return output;
        }

        private void RemoveKey(object sender, KeyEventArgs e) {
            _pressedKeys.Remove(e.Key);
        }
    }
}
