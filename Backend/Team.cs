using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Backend
{
    /// <summary>
    /// Representation of the <see cref="Team" /> class.
    /// </summary>
    public class Team
    {
        //TODO: Add statistics to players stats.
        #region Variables
        /// <summary>
        /// Gets the name of the <see cref="Team"/>.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; private set; }
        /// <summary>
        /// Gets the <see cref="Player" />'s list.
        /// </summary>
        /// <value>
        /// The players list.
        /// </value>
        public List<Player> playersList { get; private set; }
        /// <summary>
        /// The goals scored.
        /// </summary>
        /// <value>
        /// The goals scored.
        /// </value>
        public int goalsScored { get; private set; }
        /// <summary>
        /// Gets the goals lost.
        /// </summary>
        /// <value>
        /// The goals lost.
        /// </value>
        public int goalsLost { get; private set; }
        /// <summary>
        /// The matches played.
        /// </summary>
        /// <value>
        /// The matches played.
        /// </value>
        public int matchesPlayed { get; private set; }
        /// <summary>
        /// The wins.
        /// </summary>
        /// <value>
        /// The wins.
        /// </value>
        public int wins { get; private set; }
        /// <summary>
        /// Gets the loosses.
        /// </summary>
        /// <value>
        /// The loosses.
        /// </value>
        public int lost { get; private set; }
        /// <summary>
        /// Gets the draws.
        /// </summary>
        /// <value>
        /// The draws.
        /// </value>
        public int draws { get; private set; }
        /// <summary>
        /// The tournaments won.
        /// </summary>
        /// <value>
        /// The tournaments won.
        /// </value>
        public int tournamentsWon { get; private set; }

        #endregion

        #region Getters N Setters
        /// <summary>
        /// Returns the list of <see cref="Player"/>'s.
        /// </summary>
        /// <returns>List of <see cref="Player"/>s in the <see cref="Team"/>.</returns>
        public List<Player> GetPlayers() => this.playersList;

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
            wins = 0; lost = 0; draws = 0;
        }
        #endregion

        #region Methods
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
        public void AddLoss() => lost++;
        /// <summary>
        /// Adds the draw.
        /// </summary>
        public void AddDraw() => draws++;
        /// <summary>
        /// Adds the tournament won.
        /// </summary>
        public void AddTournamentWon() => tournamentsWon++;
        /// <summary>
        /// Adds the <see cref="Player" /> to this <see cref="Team"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        public void AddPlayer(Player player)
        {
            if (playersList.Capacity > playersList.Count())
            {
                playersList.Add(player);
            }
            else
                throw new Exception("Team is already full.");
        }
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

        public override string ToString()
        {
            return $"{name}\t\t MP: {matchesPlayed}\tW: {wins}\tL: {lost}\tD: {draws}\tGS: {goalsScored}\tGL: {goalsLost}\tTW: {tournamentsWon}";
        }
    }
}
