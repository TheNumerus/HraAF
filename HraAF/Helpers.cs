using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HraAF {
    public static class Helpers {
        public static string MilisecondsToTime(long miliseconds) {
            int seconds = (int)(miliseconds / 1000);
            int remMiliseconds = (int)(miliseconds - (long)seconds * 1000);
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
    }
}
