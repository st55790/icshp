using System;

namespace ChampionsLeague
{
    public enum FootballClub
    {
        None,
        FC_Porto,
        Arsenal,
        Real_Madrid,
        Chelsea,
        Barcelona
    }
    public static class FootballClubInfo
    {
        public static readonly int Count = Enum.GetValues(typeof(FootballClub)).Length;

        public static string GetClubName(FootballClub footballClub)
        {

            switch (footballClub)
            {
                case FootballClub.None:
                    return "";
                case FootballClub.FC_Porto:
                    return "FC_Porto";
                case FootballClub.Arsenal:
                    return "Arsenal";
                case FootballClub.Real_Madrid:
                    return "Real_Madrid";
                case FootballClub.Chelsea:
                    return "Chelsea";
                case FootballClub.Barcelona:
                    return "Barcelona";
            }

            throw new Exception("Invalid input!");
        }
    }
}
