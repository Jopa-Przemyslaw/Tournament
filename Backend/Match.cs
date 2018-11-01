﻿using System.Collections.Generic;

namespace Backend
{
    abstract class Match
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
        /// The supporting <see cref="Referee"/>s list.
        /// </summary>
        protected List<Referee> supportingRefereesList;

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
        /// <param name="refereeName">Name of the <see cref="Referee" />.</param>
        /// <param name="refereeSurname">The <see cref="Referee" />'s surname.</param>
        /// <param name="number">The number of supporting <see cref="Referee" />s in a <see cref="Match"/>.</param>
        /// <param name="teamA">The <see cref="Team"/> a.</param>
        /// <param name="teamB">The <see cref="Team"/> b.</param>
        public Match(string refereeName, string refereeSurname, int number, Team teamA, Team teamB)
        {
            mainReferee = new Referee(refereeName, refereeName);
            supportingRefereesList = new List<Referee>(number);
            this.teamA = teamA;
            this.teamB = teamB;
            matchScore = new MatchScore(0, 0);
        }
        #endregion

        #region Methoods
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
        /// <summary>
        /// Gets the score of <see cref="Team"/> a.
        /// </summary>
        /// <returns>Number of <see cref="int"/> type.</returns>
        public int GetScoreOfTeamA()
        {
            return matchScore.GetScoreOfTeamA();
        }
        /// <summary>
        /// Gets the score of <see cref="Team"/> b.
        /// </summary>
        /// <returns>Number of <see cref="int"/> type.</returns>
        public int GetScoreOfTeamB()
        {
            return matchScore.GetScoreOfTeamB();
        }
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
