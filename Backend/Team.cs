using System.Collections.Generic;
using System.Linq;

namespace Backend
{
    /// <summary>
    /// Representation of the <see cref="Team"/> class.
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

        #region Methoods
        /// <summary>
        /// Adds the <see cref="Player"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        public void AddPlayer(string name, string surname) { playersList.Add(new Player(name, surname)); }
        /// <summary>
        /// Removes the <see cref="Player"/>.
        /// </summary>
        public void RemovePlayer() { }
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

        /// <summary>
        /// Returns the number of goals scored by <see cref="Team"/>.
        /// </summary>
        /// <returns>Number of goals scored by <see cref="Team"/>.</returns>
        public int ReturnGoalsScored() { return this.goalsScored; }
        /// <summary>
        /// Returns the number of goals lost by <see cref="Team"/>.
        /// </summary>
        /// <returns>Number of goals lost by <see cref="Team"/>.</returns>
        public int ReturnGoalsLost() { return this.goalsLost; }
        /// <summary>
        /// Returs the number matches played by <see cref="Team"/>.
        /// </summary>
        /// <returns>Number of matches played by <see cref="Team"/>.</returns>
        public int ReturMatchesPlayed() { return this.matchesPlayed; }
        /// <summary>
        /// Returns the number of wins.
        /// </summary>
        /// <returns>Number of wins.</returns>
        public int ReturnWins() { return this.wins; }
        /// <summary>
        /// Returns the nubmer loosses.
        /// </summary>
        /// <returns>Number of loosses.</returns>
        public int ReturnLoosses() { return this.loosses; }
        /// <summary>
        /// Returns the number of draws.
        /// </summary>
        /// <returns>Number of draws.</returns>
        public int ReturnDraws() { return this.draws; }
        #endregion
    }
}
