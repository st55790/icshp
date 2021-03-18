using System;

namespace ChampionsLeague.Entity
{
    public delegate void CountChangeEventHandler(object sender, CountChangeEventArgs args);
    public class CountChangeEventArgs : EventArgs
    {
        public int OriginalCount { get; set; }
    }
}
