using System.Collections.Generic;

namespace Backend
{
    /// <summary>
    /// Abstract representation of <see cref="Match"/> class.
    /// </summary>
    public abstract class Match
    {
        #region Variables
        /// <summary>
        /// Gets or (only privatly) sets the main <see cref="Referee"/>.
        /// </summary>
        /// <value>
        /// The main <see cref="Referee"/>.
        /// </value>
        protected Referee mainReferee { get; private set; }

        /// <summary>
        /// The <see cref="Team"/> a.
        /// </summary>
        protected Team teamA;
        /// <summary>
        /// The <see cref="Team"/> b.
        /// </summary>
        protected Team teamB;
        /// <summary>
        /// The <see cref="Match"/> score.
        /// </summary>
        protected MatchScore matchScore;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Match" /> class.
        /// </summary>
        /// <param name="mainReferee">The main <see cref="Referee" />.</param>
        /// <param name="teamA">The <see cref="Team" /> a.</param>
        /// <param name="teamB">The <see cref="Team" /> b.</param>
        protected Match(Referee mainReferee, Team teamA, Team teamB)
        {
            this.mainReferee = mainReferee;
            this.teamA = teamA;
            this.teamB = teamB;
            matchScore = new MatchScore(0, 0);
        }
        #endregion

        #region Methods
        #endregion

        #region SubClasses
        /// <summary>
        /// Representation of the <see cref="MatchScore"/> class.
        /// </summary>
        protected class MatchScore
        {
            /// <summary>
            /// The score of <see cref="Team"/> a.
            /// </summary>
            private int scoreA;
            /// <summary>
            /// The score of <see cref="Team"/> b.
            /// </summary>
            private int scoreB;

            /// <summary>
            /// Initializes a new instance of the <see cref="MatchScore"/> class.
            /// </summary>
            /// <param name="scoreA">The score of <see cref="Team"/> a.</param>
            /// <param name="scoreB">The score of <see cref="Team"/> b.</param>
            public MatchScore(int scoreA, int scoreB)
            {
                this.scoreA = scoreA;
                this.scoreB = scoreB;
            }

            /// <summary>
            /// Gets the score of <see cref="Team"/> a.
            /// </summary>
            /// <returns>Number of <see cref="int"/> type.</returns>
            public int GetScoreOfTeamA()
            {
                return scoreA;
            }
            /// <summary>
            /// Gets the score of <see cref="Team"/> b.
            /// </summary>
            /// <returns>Number of <see cref="int"/> type.</returns>
            public int GetScoreOfTeamB()
            {
                return scoreB;
            }
            /// <summary>
            /// Adds the score to <see cref="Team"/> a.
            /// </summary>
            public void AddScoreToTeamA()
            {
                scoreA++;
            }
            /// <summary>
            /// Adds the score to <see cref="Team"/> b.
            /// </summary>
            public void AddScoreToTeamB()
            {
                scoreB++;
            }
        }
        #endregion
    }
}
//TODO: klasa zmieniona na public