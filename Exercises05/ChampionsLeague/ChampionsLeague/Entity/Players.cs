using System;

namespace ChampionsLeague.Entity
{
    public class Players
    {
        public int CountPlayers { get; set; } = 0;
        //public Player[] ListOfPlayers { get; set; } = new Player[2];
        public LinkedList list = new LinkedList();

        public event CountChangeEventHandler CountChange;

        public void Remove(int index)
        {
            //if (index < 0 || index > CountPlayers)
            //{
            //    throw new IndexOutOfRangeException("Invalid index");
            //}

            //for (int i = index; i < CountPlayers - 1; i++)
            //{
            //    ListOfPlayers[i] = ListOfPlayers[i + 1];
            //}

            //ListOfPlayers[--CountPlayers] = null;

            list.RemoveAt(index);
            CountPlayers--;

            OnCountChange(CountPlayers + 1);
        }

        public void Add(Player player)
        {
            //if (ListOfPlayers.Length == CountPlayers)
            //{
            //    Resize();
            //}
            //ListOfPlayers[CountPlayers++] = player;

            list.Add(player);
            CountPlayers++;

            OnCountChange(CountPlayers - 1);
        }

        private void Resize()
        {
            //Player[] tmpList = new Player[ListOfPlayers.Length * 2];
            //Array.Copy(ListOfPlayers, tmpList, ListOfPlayers.Length);
            //ListOfPlayers = tmpList;
        }

        public Player this[int index]
        {
            //get => (Player)ListOfPlayers[index];
            get => (Player)list[index];
        }

        public void GetBestClubs(out FootballClub[] clubs, out int goals)
        {
            goals = 0;
            int teamGoals = 0;
            clubs = new FootballClub[FootballClubInfo.Count];

            //foreach (var item in (FootballClub[])Enum.GetValues(typeof(FootballClub)))
            //{

            //    for (int i = 0; i < CountPlayers; i++)
            //    {
            //        if (ListOfPlayers[i].Club == item)
            //        {
            //            teamGoals += ListOfPlayers[i].Goals;
            //        }
            //    }
            //    if (teamGoals > goals)
            //    {
            //        Array.Clear(clubs, 0, FootballClubInfo.Count);
            //        clubs[(int)item] = item;
            //        goals = teamGoals;
            //    }
            //    if (teamGoals == goals)
            //    {
            //        clubs[(int)item] = item;
            //    }
            //    teamGoals = 0;
            //}
            foreach (var item in (FootballClub[])Enum.GetValues(typeof(FootballClub)))
            {

                for (int i = 0; i < CountPlayers; i++)
                {
                    if (((Player)list[i]).Club == item)
                    {
                        teamGoals += ((Player)list[i]).Goals;
                    }
                }
                if (teamGoals > goals)
                {
                    Array.Clear(clubs, 0, FootballClubInfo.Count);
                    clubs[(int)item] = item;
                    goals = teamGoals;
                }
                if (teamGoals == goals)
                {
                    clubs[(int)item] = item;
                }
                teamGoals = 0;
            }

        }

        private void OnCountChange(int count)
        {
            CountChange?.Invoke(this, new CountChangeEventArgs()
            {
                OriginalCount = count
            });
        }

    }
}
