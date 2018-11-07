using Backend.AuxiliaryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    class Cup
    {
        /// <summary>
        /// The list of <see cref="Team" />s that takes part in a <see cref="Cup" />.
        /// </summary>
        /// <value>
        /// The list of teams in cup.
        /// </value>
        public List<Team> listOfTeamsInCup { get; private set; }
        public List<Referee> listOfRefereesInCup { get; private set; }

        private Random random;
        private MatchEngine matchEngine;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cup"/> class.
        /// </summary>
        public Cup()
        {
            //listOfTeamsInCup = new List<Team>();
        }
        public Cup(List<Team> listOfTeamsInCup, List<Referee> listOfRefereesInCup)
        {
            this.listOfTeamsInCup = new List<Team>(listOfTeamsInCup);
            this.listOfRefereesInCup = new List<Referee>(listOfRefereesInCup);
            random = new Random();
            matchEngine = new MatchEngine();
        }

        /// <summary>
        /// Adds the <see cref="Team"/> to the list.
        /// </summary>
        /// <param name="team">The <see cref="Team"/> to add to a <see cref="Cup"/>.</param>
        public void AddTeam(Team team)
        {
            listOfTeamsInCup.Add(team);
        }
        /// <summary>
        /// Returns the <see cref="Team"/> that takes part in the <see cref="Cup"/>.
        /// </summary>
        /// <param name="index">The <see cref="Team"/>'s index in list.</param>
        /// <returns><see cref="Team"/> from the list of <see cref="Team"/>s taking part in the <see cref="Cup"/>.</returns>
        public Team ReturnTeam(int index)
        {
            return listOfTeamsInCup.ElementAt(index);
        }

        public Team StartFootballCup()
        {
            //TODO: Implement StartCup method in Cup class.
            int teamsInCup = listOfTeamsInCup.Count();
            int refereesInCup = listOfRefereesInCup.Count();
            if (teamsInCup < 8 && refereesInCup < 3)
                throw new Exception("Not enough teams or referees in a cup.");
            if (teamsInCup % 2 != 0)
            {

            }
            for (int i = 0; i < teamsInCup - 1; i++)
            {
                TwoTeams teams = RandomTeamsForMatch();
                Team teamA = teams.GetHostTeam;
                Team teamB = teams.GetGuestTeam;

                ThreeReferees referees = RandomRefereesForMatch();
                Referee mainReferee = referees.GetMainReferee;
                Referee suppRef1 = referees.GetSupportingReferee1;
                Referee suppRef2 = referees.GetSupportingReferee2;

                FootballMatch footballMatch = new FootballMatch(mainReferee, teamA, teamB, suppRef1, suppRef2);
                while (footballMatch.GetScoreOfTeamA() == footballMatch.GetScoreOfTeamB())
                {
                    // Implement "play-off" method in MatchEngine.cs so that this while loop can be deleted.
                    matchEngine.SymulateFootballMatch(ref footballMatch);
                }
                if (footballMatch.GetScoreOfTeamA() > footballMatch.GetScoreOfTeamB())
                {
                    listOfTeamsInCup.Remove(teamB);
                }
                else if (footballMatch.GetScoreOfTeamB() > footballMatch.GetScoreOfTeamA())
                {
                    listOfTeamsInCup.Remove(teamA);
                }
            }
            return listOfTeamsInCup.ElementAt(0);
        }

        /// <summary>
        /// Randoms two different <see cref="Team"/>s for the <see cref="Match"/> and returns them in object of <see cref="TwoTeams"/> type.
        /// </summary>
        /// <returns></returns>
        private TwoTeams RandomTeamsForMatch()
        {
            List<Team> helpTeamList = new List<Team>(listOfTeamsInCup);

            int t1 = RandomNumber(helpTeamList.Count());
            Team team1 = helpTeamList.ElementAt(t1);
            helpTeamList.RemoveAt(t1);
            int t2 = RandomNumber(helpTeamList.Count());
            Team team2 = helpTeamList.ElementAt(t2);

            return new TwoTeams(team1, team2);
        }
        /// <summary>
        /// Randoms three different <see cref="Referee" />s for the <see cref="Match" /> and returns them in object of <see cref="ThreeReferees" /> type.
        /// </summary>
        /// <returns>
        /// Object of <see cref="ThreeReferees" /> type.
        /// </returns>
        private ThreeReferees RandomRefereesForMatch()
        {
            List<Referee> helpRefereeList = new List<Referee>(listOfRefereesInCup);

            int r1 = RandomNumber(helpRefereeList.Count());
            Referee mainReferee = helpRefereeList.ElementAt(r1);
            helpRefereeList.RemoveAt(r1);
            int r2 = RandomNumber(helpRefereeList.Count());
            Referee suppRef1 = helpRefereeList.ElementAt(r2);
            helpRefereeList.RemoveAt(r2);
            int r3 = RandomNumber(helpRefereeList.Count());
            Referee suppRef2 = helpRefereeList.ElementAt(r3);

            return new ThreeReferees(mainReferee, suppRef1, suppRef2);
        }
        /// <summary>
        /// Randoms the number in range from 0 to the input parameter - 1.
        /// </summary>
        /// <param name="topRange">The top range.</param>
        /// <returns>The number in range from 0 to the input parameter - 1.</returns>
        private int RandomNumber(int topRange)
        {
            return random.Next(0, topRange - 1);
        }
    }
}
