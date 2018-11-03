
namespace Backend
{
    /// <summary>
    /// Representation of the <see cref="Player"/> class.
    /// </summary>
    /// <seealso cref="Backend.Person" />
    class Player : Person
    {
        #region Variables
        /// <summary>
        /// The <see cref="Player" />'s <see cref="Team" />.
        /// </summary>
        /// <value>
        /// The <see cref="Player" />'s <see cref="Team" />.
        /// </value>
        public Team playersTeam { get; private set; }
        /// <summary>
        /// The amount of <see cref="Match" />es played by the <see cref="Player" />.
        /// </summary>
        /// <value>
        /// The amount of <see cref="Match" />es played.
        /// </value>
        public int matchesPlayed { get; private set; }
        /// <summary>
        /// The amount of goals scored by the <see cref="Player" />.
        /// </summary>
        /// <value>
        /// The amount of goals scored.
        /// </value>
        public int goalsScored { get; private set; }
        #endregion

        #region Getters N Setters
        /// <summary>
        /// Gets the name of the <see cref="Player"/>.
        /// </summary>
        /// <value>
        /// The name of the <see cref="Player"/>.
        /// </value>
        public string GetName => base.name;
        /// <summary>
        /// Gets the <see cref="Player"/>'s surname.
        /// </summary>
        /// <value>
        /// The <see cref="Player"/>'s surname.
        /// </value>
        public string GetSurname => base.surname;

        /// <summary>
        /// Sets the <see cref="Team"/> for the <see cref="Player"/>.
        /// </summary>
        /// <param name="playersTeam">The <see cref="Player"/>'s <see cref="Team"/>.</param>
        public void SetTeam(Team playersTeam) => this.playersTeam = playersTeam;
        /// <summary>
        /// Sets the amount of goals scored by the <see cref="Player" />.
        /// </summary>
        /// <param name="goalsScored">The amount of goals scored.</param>
        public void SetScoredGoals(int goalsScored) => this.goalsScored = goalsScored;
        /// <summary>
        /// Sets the amount of <see cref="Match" />es played by the <see cref="Player" />.
        /// </summary>
        /// <param name="matchesPlayed">The amount of <see cref="Match" />es played.</param>
        public void SetMatchesPlayer(int matchesPlayed) => this.matchesPlayed = matchesPlayed;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="name">The name of the <see cref="Player"/>.</param>
        /// <param name="surname">The <see cref="Player"/>'s surname.</param>
        public Player(string name, string surname) : base(name, surname)
        {
            playersTeam = null;
            matchesPlayed = 0;
            goalsScored = 0;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="name">The name of the <see cref="Player"/>.</param>
        /// <param name="surname">The <see cref="Player"/>'s surname.</param>
        /// <param name="playersTeam">The <see cref="Player"/>'s <see cref="Team"/>.</param>
        public Player(string name, string surname, Team playersTeam) : base(name, surname)
        {
            this.playersTeam = playersTeam;
            matchesPlayed = 0;
            goalsScored = 0;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">The name of the <see cref="Player"/>.</param>
        /// <param name="surname">The <see cref="Player"/>'s surname.</param>
        /// <param name="playersTeam">The <see cref="Player"/>'s team.</param>
        /// <param name="matchesPlayed">The amount of <see cref="Match"/>es played by the <see cref="Player"/>.</param>
        /// <param name="goalsScored">The amount of goals scored by the <see cref="Player"/>.</param>
        public Player(string name, string surname, Team playersTeam, int matchesPlayed, int goalsScored) : base(name, surname)
        {
            this.playersTeam = playersTeam;
            this.matchesPlayed = matchesPlayed;
            this.goalsScored = goalsScored;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the goal scored by the <see cref="Player" />.
        /// </summary>
        public void AddScoredGoal()
        {
            goalsScored++;
        }
        /// <summary>
        /// Adds the match played by the <see cref="Player" />.
        /// </summary>
        public void AddMatchPlayed()
        {
            matchesPlayed++;
        }
        #endregion
    }
}
