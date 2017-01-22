using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace HraAF {
    static class RecordsAPI {
        public static Records rekordy;

        public static void Save() {
            string json = JsonConvert.SerializeObject(rekordy);
            Properties.Settings.Default.rekordyJSON = json;
            Properties.Settings.Default.Save();
        }

        public static void Load() {
            rekordy = JsonConvert.DeserializeObject<Records>(Properties.Settings.Default.rekordyJSON);
        }
        public static void addRecord(float cas) {
            if (rekordy == null) {
                rekordy = new Records();
            }
            Record newTime = new Record(cas,"Test");
            for (int i = 0; i < 10; i++) {
                if (rekordy.rekordy[i].rekord < newTime.rekord || rekordy.rekordy[i].rekord == (float)-1) {
                    for (int x = 9; x > i; x--) {
                        rekordy.rekordy[x] = rekordy.rekordy[x - 1];
                    }
                    rekordy.rekordy[i] = newTime;
                    break;
                }
            }
            Save();
        }
    }
    class Records {
        public Record[] rekordy;
        
        public Records() {
            rekordy = new Record[10];
            for (int i = 0; i < 10; i++) {
                rekordy[i] = new Record();
            }
        }
    }
    class Record {
        public float rekord;
        public string jmeno;
        public Record() {
            rekord = -1;
            jmeno = "";
        }

        public Record(float cas, string jmenoNew) {
            rekord = cas;
            jmeno = jmenoNew;
        }
    }
}
