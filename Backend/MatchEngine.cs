using System;
using System.Diagnostics;

namespace Backend
{
    /// <summary>
    /// Representation of <see cref="MatchEngine"/> class.
    /// </summary>
    class MatchEngine
    {
        /// <summary>
        /// The game time.
        /// </summary>
        private int gameTime;
        /// <summary>
        /// The random number.
        /// </summary>
        private Random random;
        /// <summary>
        /// The <see cref="Team"/> that have the ball.
        /// </summary>
        private Team inPossession;


        /// <summary>
        /// Initializes a new instance of the <see cref="MatchEngine"/> class.
        /// </summary>
        public MatchEngine()
        {
            random = new Random();
            gameTime = 5400000; // 90' to 5400000ms  // 1' to 60000ms
        }


        /// <summary>
        /// Symulates the football match.
        /// </summary>
        /// <param name="footballMatch">The football match.</param>
        public void SymulateFootballMatch(ref FootballMatch footballMatch)
        {
            bool breaktime = false;
            //Debug.WriteLine($"00': Match started.");
            for (int i = random.Next(600000, 900000); i <= gameTime; i += random.Next(600000, 900000))
            {
                //Debug.Write($"{i / 1000 / 60}': The ball is in possession of ");
                if (Chance() % 2 == 0)
                {
                    // Team A has the ball
                    //Debug.Write($"{footballMatch.ReturnTeamA().name}. ");
                    inPossession = footballMatch.ReturnTeamA();
                    if (ifTeamScored())
                    {
                        //Debug.WriteLine($"\tThey scored a beautiful GOAL!");
                        footballMatch.AddScoreToTeamA();
                    }
                    else
                    {
                        //Debug.WriteLine($" \t Ball in game.");
                    }
                }
                else
                {
                    // Team B has the ball
                    //Debug.Write($"{footballMatch.ReturnTeamB().name}. ");
                    inPossession = footballMatch.ReturnTeamB();
                    if (ifTeamScored())
                    {
                        //Debug.WriteLine($"\tThey scored a beautiful GOAL!");
                        footballMatch.AddScoreToTeamB();
                    }
                    else
                    {
                        //Debug.WriteLine($" \t Ball in game.");
                    }
                }
                //Thread.Sleep(i / 1000);
                if (breaktime == false)
                {
                    if ((i + 600000) > 2700000 && breaktime == false)
                    {
                        //Debug.WriteLine($"45': First half ended. Braktime.\tTeamA {footballMatch.GetScoreOfTeamA()} : {footballMatch.GetScoreOfTeamB()} TeamB.");
                        breaktime = true;
                    }
                }
                else if ((i + 600000) > gameTime) i -= 540000;
            }
            //Debug.WriteLine($"90': Time's up. Match ended.\tTeamA {footballMatch.GetScoreOfTeamA()} : {footballMatch.GetScoreOfTeamB()} TeamB.");
        }

        private void Engine()
        {
            // one engine for several matches types
        }

        /// <summary>
        /// Random a number.
        /// </summary>
        /// <returns>Random number typeof <see cref="int"/>.</returns>
        private int Chance()
        {
            int rndChance = random.Next(0, 9);
            return rndChance;
        }
        /// <summary>
        /// Ifs the team scored.
        /// </summary>
        /// <returns>True if scored. False if not.</returns>
        private bool ifTeamScored()
        {
            if (Chance() <= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
