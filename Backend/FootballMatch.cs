
namespace Backend
{
    /// <summary>
    /// Representation of <see cref="FootballMatch"/> class.
    /// </summary>
    /// <seealso cref="Backend.Match" />
    class FootballMatch : Match
    {
        #region Variables
        /// <summary>
        /// The first supporting <see cref="Referee"/>.
        /// </summary>
        private Referee suppRef1;
        /// <summary>
        /// The second supporting <see cref="Referee"/>.
        /// </summary>
        private Referee suppRef2;
        #endregion

        #region Getters N Setters
        /// <summary>
        /// Gets the score of <see cref="Team"/> a.
        /// </summary>
        /// <returns>Number of <see cref="int"/> type.</returns>
        public int GetScoreOfTeamA() => matchScore.GetScoreOfTeamA();
        /// <summary>
        /// Gets the score of <see cref="Team"/> b.
        /// </summary>
        /// <returns>Number of <see cref="int"/> type.</returns>
        public int GetScoreOfTeamB() => matchScore.GetScoreOfTeamB();

        /// <summary>
        /// Returns the main <see cref="Referee"/>.
        /// </summary>
        /// <returns>Object typeof <see cref="Referee"/>.</returns>
        public Referee ReturnMainReferee() => this.mainReferee;
        /// <summary>
        /// Returns the first supporting <see cref="Referee"/>.
        /// </summary>
        /// <returns>Object typeof <see cref="Referee"/>.</returns>
        public Referee ReturnSuppRef1() => this.suppRef1;
        /// <summary>
        /// Returns the second supporting <see cref="Referee"/>.
        /// </summary>
        /// <returns>Object typeof <see cref="Referee"/>.</returns>
        public Referee ReturnSuppRef2() => this.suppRef2;
        /// <summary>
        /// Returns the <see cref="Team"/> a.
        /// </summary>
        /// <returns>Object typeof <see cref="Team"/>.</returns>
        public Team ReturnTeamA() => this.teamA;
        /// <summary>
        /// Returns the <see cref="Team"/> b.
        /// </summary>
        /// <returns>Object typeof <see cref="Team"/>.</returns>
        public Team ReturnTeamB() => this.teamB;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FootballMatch"/> class.
        /// </summary>
        /// <param name="mainReferee">The main <see cref="Referee"/>.</param>
        /// <param name="teamA">The <see cref="Team"/> a.</param>
        /// <param name="teamB">The <see cref="Team"/> b.</param>
        /// <param name="suppRef1">The first supporting <see cref="Referee"/>.</param>
        /// <param name="suppRef2">The second supporting <see cref="Referee"/>.</param>
        public FootballMatch(Referee mainReferee, Team teamA, Team teamB, Referee suppRef1, Referee suppRef2)
            : base(mainReferee, teamA, teamB)
        {
            this.suppRef1 = suppRef1;
            this.suppRef2 = suppRef2;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the score to <see cref="Team"/> a.
        /// </summary>
        public void AddScoreToTeamA()
        {
            matchScore.AddScoreToTeamA();
        }
        /// <summary>
        /// Adds the score to <see cref="Team"/> b.
        /// </summary>
        public void AddScoreToTeamB()
        {
            matchScore.AddScoreToTeamB();
        }

        #endregion
    }
}
