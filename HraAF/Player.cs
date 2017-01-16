using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HraAF {
    class Player : PlayableObject {
        List<Key> _pressedKeys = new List<Key>();
        public MainWindow window;
        public void Init() {
            this.KeyDown += AddKey;
            this.KeyUp += RemoveKey;
            this.Focusable = true;
        }

        public override void ApplyGravity() {
            addX(3);
            if (getX() > 800) {
                window.ResetGame();
            }
        }

        private void AddKey(object sender, KeyEventArgs e) {
            if (_pressedKeys.Contains(e.Key)) {
            } else {
                _pressedKeys.Add(e.Key);
            }
        }

        public void HandleInput() {
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

        private void RemoveKey(object sender, KeyEventArgs e) {
            _pressedKeys.Remove(e.Key);
        }
    }
}
