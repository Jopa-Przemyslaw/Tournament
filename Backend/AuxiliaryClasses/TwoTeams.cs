using System;

namespace Backend.AuxiliaryClasses
{
    /// <summary>
    /// <see cref="Tuple"/> class that can hold two objects of <see cref="Team"/> type.
    /// </summary>
    /// <seealso cref="System.Tuple{Backend.Team, Backend.Team}" />
    class TwoTeams : Tuple<Team, Team>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwoTeams"/> class.
        /// </summary>
        /// <param name="first">The first <see cref="Team"/>.</param>
        /// <param name="second">The second <see cref="Team"/>.</param>
        public TwoTeams(Team first, Team second) : base(first, second) { }

        /// <summary>
        /// Gets the host <see cref="Team"/>.
        /// </summary>
        /// <value>
        /// The host <see cref="Team"/>.
        /// </value>
        public Team GetHostTeam => this.Item1;
        /// <summary>
        /// Gets the guest <see cref="Team"/>.
        /// </summary>
        /// <value>
        /// The guest <see cref="Team"/>.
        /// </value>
        public Team GetGuestTeam => this.Item2;
    }
}
