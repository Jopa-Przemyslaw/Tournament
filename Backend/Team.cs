using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    /// <summary>
    /// Representation of the <see cref="Team"/> class.
    /// </summary>
    class Team
    {
        /// <summary>
        /// The <see cref="Player"/>'s list.
        /// </summary>
        private List<Player> playersList = new List<Player>();
        /// <summary>
        /// Gets the name of the <see cref="Team"/>.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        public Team() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Team" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Team(string name) { this.name = name; }
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
    }
}
