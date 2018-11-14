using Backend.AuxiliaryClasses;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <summary>
        /// Gets the list of <see cref="Referee"/>s in <see cref="Cup"/>.
        /// </summary>
        /// <value>
        /// The list of <see cref="Referee"/>s in <see cref="Cup"/>.
        /// </value>
        public List<Referee> listOfRefereesInCup { get; private set; }
        /// <summary>
        /// Gets the name of the <see cref="Cup"/>.
        /// </summary>
        /// <value>
        /// The name of the <see cref="Cup"/>.
        /// </value>
        public string name { get; private set; }
        /// <summary>
        /// True if the Cup is already played out. False if it's not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is finished; otherwise, <c>false</c>.
        /// </value>
        public bool isFinished { get; private set; }

        private Random random;
        private MatchEngine matchEngine;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cup"/> class.
        /// </summary>
        public Cup()
        {
            listOfTeamsInCup = new List<Team>();
            listOfRefereesInCup = new List<Referee>();
            name = "New Cup";
            random = new Random();
            matchEngine = new MatchEngine();
            isFinished = false;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Cup"/> class.
        /// </summary>
        /// <param name="name">The name of the new <see cref="Cup"/>.</param>
        public Cup(string name)
        {
            listOfTeamsInCup = new List<Team>();
            listOfRefereesInCup = new List<Referee>();
            this.name = name;
            random = new Random();
            matchEngine = new MatchEngine();
            isFinished = false;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Cup" /> class.
        /// </summary>
        /// <param name="listOfTeamsInCup">The list of <see cref="Team" />s in <see cref="Cup" />.</param>
        /// <param name="listOfRefereesInCup">The list of <see cref="Referee" />s in <see cref="Cup" />.</param>
        /// <param name="name">The name of the new <see cref="Cup"/>.</param>
        public Cup(List<Team> listOfTeamsInCup, List<Referee> listOfRefereesInCup, string name)
        {
            this.listOfTeamsInCup = new List<Team>(listOfTeamsInCup);
            this.listOfRefereesInCup = new List<Referee>(listOfRefereesInCup);
            this.name = name;
            random = new Random();
            matchEngine = new MatchEngine();
            isFinished = false;
        }

        /// <summary>
        /// Adds the <see cref="Team"/> to the list of <see cref="Team"/>s in <see cref="Cup"/>.
        /// </summary>
        /// <param name="team">The <see cref="Team"/> to add to a <see cref="Cup"/>.</param>
        public void AddTeam(Team team)
        {
            if (!listOfTeamsInCup.Contains(team))
                listOfTeamsInCup.Add(team);
        }
        /// <summary>
        /// Removes the <see cref="Team"/> from a <see cref="Cup"/> list.
        /// </summary>
        /// <param name="team">The <see cref="Team"/> to remove.</param>
        public void RemoveTeam(Team team)
        {
            if (listOfTeamsInCup.Contains(team))
                listOfTeamsInCup.Remove(team);
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
        /// <summary>
        /// Adds the <see cref="Referee"/> to the list of <see cref="Referee"/>s in <see cref="Cup"/>.
        /// </summary>
        /// <param name="referee">The <see cref="Referee"/> to add to a <see cref="Cup"/>.</param>
        public void AddReferee(Referee referee)
        {
            if (!listOfRefereesInCup.Contains(referee))
                listOfRefereesInCup.Add(referee);
        }
        /// <summary>
        /// Removes the <see cref="Referee"/> from a <see cref="Cup"/> list.
        /// </summary>
        /// <param name="referee">The <see cref="Referee"/> to remove.</param>
        public void RemoveReferee(Referee referee)
        {
            if (listOfRefereesInCup.Contains(referee))
                listOfRefereesInCup.Remove(referee);
        }
        /// <summary>
        /// Returns the <see cref="Referee"/> that takes part in the <see cref="Cup"/>.
        /// </summary>
        /// <param name="index">The <see cref="Referee"/>'s index in list.</param>
        /// <returns><see cref="Referee"/> from the list of <see cref="Referee"/>s taking part in the <see cref="Cup"/>.</returns>
        public Referee ReturnReferee(int index)
        {
            return listOfRefereesInCup.ElementAt(index);
        }

        /// <summary>
        /// Starts the football <see cref="Cup" />.
        /// </summary>
        /// <returns>
        /// The winner <see cref="Team" />.
        /// </returns>
        /// <exception cref="Exception">Not enough teams or referees in a cup.
        /// or
        /// Not even number of teams in a cup.</exception>
        public Team StartFootballCup()
        {
            if (isFinished)
                throw new Exception("Cup already played out.");
            int teamsInCup = listOfTeamsInCup.Count();
            int refereesInCup = listOfRefereesInCup.Count();
            if (teamsInCup < 8 && refereesInCup < 3)
                throw new Exception("Not enough teams or referees in a cup.");
            if (teamsInCup % 2 != 0)
                throw new Exception("Not even number of teams in a cup.");
            if (teamsInCup != 8 & teamsInCup != 16 & teamsInCup != 24)
                throw new Exception("Need to be 8, 16 or 24 teams for a cup.");
            int xx = 1;
            int yy = listOfTeamsInCup.Count();
            while ((yy / 2) > 1)
            {
                xx++;
                yy /= 2;
            }
            for (int h = 0; h < xx; h++)
            {
                List<Team> tempList = new List<Team>(listOfTeamsInCup);
                for (int i = 0; i < teamsInCup / 2; i++)
                {
                    TwoTeams teams = RandomTeamsForMatch(tempList);
                    Team teamA = teams.GetHostTeam;
                    Team teamB = teams.GetGuestTeam;

                    ThreeReferees referees = RandomRefereesForMatch();
                    Referee mainReferee = referees.GetMainReferee;
                    Referee suppRef1 = referees.GetSupportingReferee1;
                    Referee suppRef2 = referees.GetSupportingReferee2;

                    FootballMatch footballMatch = new FootballMatch(mainReferee, teamA, teamB, suppRef1, suppRef2);
                    matchEngine.SimulateFootballMatch(ref footballMatch, true);
                    if (footballMatch.GetScoreOfTeamA() > footballMatch.GetScoreOfTeamB())
                    {
                        listOfTeamsInCup.Remove(teamB);
                    }
                    else if (footballMatch.GetScoreOfTeamB() > footballMatch.GetScoreOfTeamA())
                    {
                        listOfTeamsInCup.Remove(teamA);
                    }
                    tempList.Remove(teamA);
                    tempList.Remove(teamB);
                }
                teamsInCup /= 2;
            }
            listOfTeamsInCup.ElementAt(0).AddTournamentWon();
            isFinished = true;
            return listOfTeamsInCup.ElementAt(0);
        }

        /// <summary>
        /// Randoms two different <see cref="Team"/>s for the <see cref="Match"/> and returns them in object of <see cref="TwoTeams"/> type.
        /// </summary>
        /// <returns></returns>
        private TwoTeams RandomTeamsForMatch(List<Team> listOfTeamsInCup)
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
