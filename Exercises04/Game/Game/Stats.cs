using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public delegate void UpdatedStatsEventHandler(object sender, EventArgs e);

    class Stats
    {
        public int Correct { get; set; }
        public int Missed { get; set; }
        public int Accuracy { get; set; }

        public event UpdatedStatsEventHandler UpdatedStats;

        public void OnUpdatedStats()
        {
            UpdatedStatsEventHandler handler = UpdatedStats;
            if (handler != null)
                handler(this, new EventArgs());
        }

        public void Update(bool correctKey) {
            if (correctKey)
            {
                Correct++;
            }
            else {
                Missed++;
            }

            if ((Correct + Missed) > 0) { 
                Accuracy = Correct*100 / (Correct + Missed);
            }

            OnUpdatedStats();
        }

        public void Restart() {
            Correct = 0;
            Missed = 0;
            Accuracy = 0;
        }

    }
}
