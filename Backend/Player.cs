
namespace Backend
{
    /// <summary>
    /// Representation of the <see cref="Player"/> class.
    /// </summary>
    /// <seealso cref="Backend.Person" />
    public class Player : Person
    {
        #region Variables
        /// <summary>
        /// The <see cref="Player" />'s <see cref="Team" />.
        /// </summary>
        /// <value>
        /// The <see cref="Player" />'s <see cref="Team" />.
        /// </value>
        public Team playerTeam { get; private set; }
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
        /// <summary>
        /// Gets the amount of trophies won by the <see cref="Player" />.
        /// </summary>
        /// <value>
        /// The amount of trophies won by the <see cref="Player" />
        /// </value>
        public int trophiesWon { get; private set; }
        #endregion

        #region Getters N Setters
        /// <summary>
        /// Gets the <see cref="Player"/>.
        /// </summary>
        /// <value>
        /// The <see cref="Player"/>.
        /// </value>
        public Player GetPlayer => this;
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
        /// <param name="playerTeam">The <see cref="Player"/>'s <see cref="Team"/>.</param>
        public void SetTeam(Team playerTeam)
        {
            //var xd = playerTeam.playersList.Find(x=>x.GetPlayer == this);
            if (playerTeam != null && playerTeam.playersList.Find(x => x.GetPlayer == this) == null)
            {
                if (playerTeam.playersList.Capacity > playerTeam.ReturnTeamCount())
                {
                    this.playerTeam = playerTeam;
                    playerTeam.AddPlayer(this);
                }
                else
                    throw new System.Exception("Team is already full.");
            }
            else if (playerTeam == null)
            {
                this.playerTeam.playersList.Remove(this);
                this.playerTeam = playerTeam;
            }
        }
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
        /// <summary>
        /// Sets the amount of trophies won by the <see cref="Player"/>.
        /// </summary>
        /// <param name="trophiesWon">The amount of trophies.</param>
        public void SetTrophiesWon(int trophiesWon) => this.trophiesWon = trophiesWon;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="name">The name of the <see cref="Player"/>.</param>
        /// <param name="surname">The <see cref="Player"/>'s surname.</param>
        public Player(string name, string surname) : base(name, surname)
        {
            playerTeam = null;
            matchesPlayed = 0;
            goalsScored = 0;
            trophiesWon = 0;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="name">The name of the <see cref="Player"/>.</param>
        /// <param name="surname">The <see cref="Player"/>'s surname.</param>
        /// <param name="playersTeam">The <see cref="Player"/>'s <see cref="Team"/>.</param>
        public Player(string name, string surname, Team playersTeam) : base(name, surname)
        {
            if (playersTeam.playersList.Capacity > playersTeam.ReturnTeamCount())
            {
                this.playerTeam = playersTeam;
                playersTeam.AddPlayer(this);
            }
            else
                throw new System.Exception($"Team \"{playersTeam.name}\" is already full.");
            matchesPlayed = 0;
            goalsScored = 0;
            trophiesWon = 0;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="name">The name of the <see cref="Player" />.</param>
        /// <param name="surname">The <see cref="Player" />'s surname.</param>
        /// <param name="playersTeam">The <see cref="Player" />'s team.</param>
        /// <param name="matchesPlayed">The amount of <see cref="Match" />es played by the <see cref="Player" />.</param>
        /// <param name="goalsScored">The amount of goals scored by the <see cref="Player" />.</param>
        /// <param name="trophiesWon">The amount of trophies won by the <see cref="Player"/>.</param>
        public Player(string name, string surname, Team playersTeam, int matchesPlayed, int goalsScored, int trophiesWon) : base(name, surname)
        {
            this.playerTeam = playersTeam;
            this.matchesPlayed = matchesPlayed;
            this.goalsScored = goalsScored;
            this.trophiesWon = trophiesWon;
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
        /// <summary>
        /// Adds the trophy won by the <see cref="Player" />.
        /// </summary>
        public void AddTrophyWon()
        {
            trophiesWon++;
        }
        #endregion

        public override string ToString()
        {
            string team = (this.playerTeam!=null)?this.playerTeam.name:"";
            return $"{name} {surname} \t{team}";
        }
    }
}
