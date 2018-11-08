using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Backend
{
    /// <summary>
    /// Representation of the <see cref="Team" /> class.
    /// </summary>
    class Team
    {
        #region Variables
        /// <summary>
        /// Gets the name of the <see cref="Team"/>.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; private set; }
        /// <summary>
        /// The <see cref="Player"/>'s list.
        /// </summary>
        private List<Player> playersList;
        /// <summary>
        /// The goals scored or lost.
        /// </summary>
        private int goalsScored, goalsLost;
        /// <summary>
        /// The matches played.
        /// </summary>
        private int matchesPlayed;
        /// <summary>
        /// The wins, looses or draws.
        /// </summary>
        private int wins, loosses, draws;
        /// <summary>
        /// The tournaments won.
        /// </summary>
        private int tournamentsWon;
        #endregion

        #region Getters N Setters
        /// <summary>
        /// Returns the list of <see cref="Player"/>'s.
        /// </summary>
        /// <returns>List of <see cref="Player"/>s in the <see cref="Team"/>.</returns>
        public List<Player> ReturnPlayers() => this.playersList;
        /// <summary>
        /// Returns the number of goals scored by <see cref="Team"/>.
        /// </summary>
        /// <returns>Number of goals scored by <see cref="Team"/>.</returns>
        public int ReturnGoalsScored() => this.goalsScored;
        /// <summary>
        /// Returns the number of goals lost by <see cref="Team"/>.
        /// </summary>
        /// <returns>Number of goals lost by <see cref="Team"/>.</returns>
        public int ReturnGoalsLost() => this.goalsLost;
        /// <summary>
        /// Returs the number matches played by <see cref="Team"/>.
        /// </summary>
        /// <returns>Number of matches played by <see cref="Team"/>.</returns>
        public int ReturMatchesPlayed() => this.matchesPlayed;
        /// <summary>
        /// Returns the number of wins.
        /// </summary>
        /// <returns>Number of wins.</returns>
        public int ReturnWins() => this.wins;
        /// <summary>
        /// Returns the nubmer loosses.
        /// </summary>
        /// <returns>Number of loosses.</returns>
        public int ReturnLoosses() => this.loosses;
        /// <summary>
        /// Returns the number of draws.
        /// </summary>
        /// <returns>Number of draws.</returns>
        public int ReturnDraws() => this.draws;
        /// <summary>
        /// Returns the number of tournaments won.
        /// </summary>
        /// <returns>Number of tournaments won.</returns>
        public int ReturnTournamentsWon() => this.tournamentsWon;

        /// <summary>
        /// Adds the goal scored.
        /// </summary>
        public void AddGoalScored() => goalsScored++;
        /// <summary>
        /// Adds the goal lost.
        /// </summary>
        public void AddGoalLost() => goalsLost++;
        /// <summary>
        /// Adds the match played.
        /// </summary>
        public void AddMatchPlayed() => matchesPlayed++;
        /// <summary>
        /// Adds the win.
        /// </summary>
        public void AddWin() => wins++;
        /// <summary>
        /// Adds the loss.
        /// </summary>
        public void AddLoss() => loosses++;
        /// <summary>
        /// Adds the draw.
        /// </summary>
        public void AddDraw() => draws++;
        /// <summary>
        /// Adds the tournament won.
        /// </summary>
        public void AddTournamentWon() => tournamentsWon++;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Team" /> class.
        /// </summary>
        /// <param name="name">The name of the <see cref="Team"/>.</param>
        /// <param name="number">The number of <see cref="Player"/>s.</param>
        public Team(string name, int number)
        {
            this.name = name;
            playersList = new List<Player>(number);
            goalsScored = 0; goalsLost = 0;
            matchesPlayed = 0;
            wins = 0; loosses = 0; draws = 0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the <see cref="Player" /> to this <see cref="Team"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        public void AddPlayer(string name, string surname) { playersList.Add(new Player(name, surname, this)); }
        /// <summary>
        /// Removes the <see cref="Player" /> by the position on playersList.
        /// </summary>
        /// <param name="positionOnList">The position on list.</param>
        public void RemovePlayer(int positionOnList)
        {
            try
            {
                if (!playersList.Any())
                    throw new NotImplementedException();
                playersList.RemoveAt(positionOnList);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Catched Exception! {playersList.ToString()} is null, can not remove element. {e}");
            }
        }
        /// <summary>
        /// Returns the <see cref="Player"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>Object of <see cref="Player"/> type.</returns>
        public Player ReturnPlayer(int position) { return playersList.ElementAt(position); }
        /// <summary>
        /// Returns number of <see cref="Player"/>s in <see cref="Team"/>.
        /// </summary>
        /// <returns>Object of <see cref="int"/> type.</returns>
        public int ReturnTeamCount() { return playersList.Count; }
        /// <summary>
        /// Returns the <see cref="Team"/>.
        /// </summary>
        /// <returns>Object of <see cref="Team"/> type.</returns>
        public Team ReturnTeam() { return this; }

        #endregion
    }
}
