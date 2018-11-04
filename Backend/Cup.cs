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

        /// <summary>
        /// Initializes a new instance of the <see cref="Cup"/> class.
        /// </summary>
        public Cup()
        {
            listOfTeamsInCup = new List<Team>();
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

        public Team StartCup()
        {
            throw new NotImplementedException("NOT IMPLEMENTED YET");
            //TODO: Implement StartCup method in Cup class.
        }
    }
}
