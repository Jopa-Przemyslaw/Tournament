using System;
using System.Diagnostics;
using System.Threading;

namespace Backend
{
    //TODO: klasa zmieniona na public
    /// <summary>
    /// Representation of <see cref="MatchEngine"/> class.
    /// </summary>
    public class MatchEngine
    {
        /// <summary>
        /// The game time.
        /// </summary>
        private readonly int playTime;
        /// <summary>
        /// The playoff time.
        /// </summary>
        private readonly int playoffTime;
        private int min;
        private int max;
        /// <summary>
        /// The random number.
        /// </summary>
        private Random random;
        /// <summary>
        /// The <see cref="Team"/> that has the ball.
        /// </summary>
        private Team inPossession;


        /// <summary>
        /// Initializes a new instance of the <see cref="MatchEngine"/> class.
        /// </summary>
        public MatchEngine()
        {
            playTime = 5400000; // 90' equals 5400000ms  // 1' to 60000ms
            playoffTime = 1800000;  // 30' equals 1800000ms
            random = new Random();
        }


        /// <summary>
        /// Symulates the football match.
        /// </summary>
        /// <param name="footballMatch">The football match.</param>
        /// <param name="isDeathmatch">If set to <c>true</c> than this is deathmatch.</param>
        public void SimulateFootballMatch(ref FootballMatch footballMatch, bool isDeathmatch)
        {
            Debug.WriteLine($"----------------------------------------------------------");
            Engine(ref footballMatch, isDeathmatch);
            Debug.WriteLine($"----------------------------------------------------------");
        }

        public async void SimulateFootballMatchAsync(FootballMatch footballMatch, bool isDeathmatch)
        {
            Debug.WriteLine($"----------------------------------------------------------");
            Engine(ref footballMatch, isDeathmatch);
            Debug.WriteLine($"----------------------------------------------------------");
        }

        /// <summary>
        ///   <see cref="Engine(ref FootballMatch, int, int, int)" /> is the specified football match engine, which is responsible for executing play simulation.
        /// </summary>
        /// <param name="footballMatch">The football match.</param>
        /// <param name="isDeathmatch">If set to <c>true</c> than this is deathmatch.</param>
        private void Engine(ref FootballMatch footballMatch, bool isDeathmatch)
        { 
            min = 600000;
            max = 900000;
            int matchTime = playTime / 1000 / 60;
            int currentTime;
            bool breaktime = false;
            Debug.WriteLine($"00': Match started.");

            for (int i = random.Next(min, max); i <= this.playTime; i += random.Next(min, max))
            {
                currentTime = i / 1000 / 60;
                Debug.Write($"{currentTime}': The ball is in possession of ");
                if (Chance() % 2 == 0)
                {
                    // Team A has the ball
                    Debug.Write($"{footballMatch.ReturnTeamA().name}. ");
                    inPossession = footballMatch.ReturnTeamA();
                    if (IfTeamScored(3))
                    {
                        Debug.WriteLine($"\tThey scored a beautiful GOAL!");
                        footballMatch.AddScoreToTeamA();
                    }
                    else
                    {
                        Debug.WriteLine($" \tThey shot... and missed.");
                    }
                }
                else
                {
                    // Team B has the ball
                    Debug.Write($"{footballMatch.ReturnTeamB().name}. ");
                    inPossession = footballMatch.ReturnTeamB();
                    if (IfTeamScored(3))
                    {
                        Debug.WriteLine($"\tThey scored a beautiful GOAL!");
                        footballMatch.AddScoreToTeamB();
                    }
                    else
                    {
                        Debug.WriteLine($" \tThey shot... and missed.");
                    }
                }
                //Thread.Sleep(i / 1000);   //Uncomment for real time.
                if (breaktime == false)
                {
                    if ((i + max) > this.playTime / 2 && breaktime == false)
                    {
                        Debug.WriteLine($"{this.playTime / 2 / 1000 / 60}': First half ended. Braktime.\t{footballMatch.ReturnTeamA().name} {footballMatch.GetScoreOfTeamA()} : {footballMatch.GetScoreOfTeamB()} {footballMatch.ReturnTeamB().name}.");
                        breaktime = true;
                        i += max - min;
                        Debug.WriteLine($"{this.playTime / 2 / 1000 / 60}': Second half on the go.");
                    }
                }
                else if ((i + min) > this.playTime) i -= min / 10;
            }
            Debug.WriteLine($"{matchTime}': Regular time's up.");

            if (isDeathmatch == true &&
                footballMatch.GetScoreOfTeamA() == footballMatch.GetScoreOfTeamB())
            {
                Debug.WriteLine($"90': Regular time wasn't enough.\t{footballMatch.ReturnTeamA().name} {footballMatch.GetScoreOfTeamA()} : {footballMatch.GetScoreOfTeamB()} {footballMatch.ReturnTeamB().name}.");
                Debug.WriteLine($"90': Play-off time! It's a lottery now.");
                matchTime += playoffTime / 1000 / 60;
                breaktime = false;
                currentTime = playTime / 1000 / 60;
                min = 300000;
                max = 600000;
                for (int i = random.Next(min, max); i <= playoffTime; i += random.Next(min, max))
                {
                    currentTime = (playTime + i) / 1000 / 60;
                    Debug.Write($"{currentTime}': The ball is in possession of ");
                    if (Chance() % 2 == 0)
                    {
                        // Team A has the ball
                        Debug.Write($"{footballMatch.ReturnTeamA().name}. ");
                        inPossession = footballMatch.ReturnTeamA();
                        if (IfTeamScored(3))
                        {
                            Debug.WriteLine($"\tThey scored a beautiful GOAL!");
                            footballMatch.AddScoreToTeamA();
                        }
                        else
                        {
                            Debug.WriteLine($" \tThey shot... and missed.");
                        }
                    }
                    else
                    {
                        // Team B has the ball
                        Debug.Write($"{footballMatch.ReturnTeamB().name}. ");
                        inPossession = footballMatch.ReturnTeamB();
                        if (IfTeamScored(3))
                        {
                            Debug.WriteLine($"\tThey scored a beautiful GOAL!");
                            footballMatch.AddScoreToTeamB();
                        }
                        else
                        {
                            Debug.WriteLine($" \tThey shot... and missed.");
                        }
                    }
                    //Thread.Sleep(i / 1000);
                    if (breaktime == false)
                    {
                        if ((i + max) > this.playoffTime / 2 && breaktime == false)
                        {
                            Debug.WriteLine($"{playoffTime / 2 / 1000 / 60 + playTime / 1000 / 60}': First half ended. Braktime.\t{footballMatch.ReturnTeamA().name} {footballMatch.GetScoreOfTeamA()} : {footballMatch.GetScoreOfTeamB()} {footballMatch.ReturnTeamB().name}.");
                            breaktime = true;
                            i += max - min;
                        }
                    }
                    else if ((i + min) > this.playoffTime) i -= min / 10;
                }
                Debug.WriteLine($"{(playTime + playoffTime) / 1000 / 60}': Play-off time's up.");
                if (footballMatch.GetScoreOfTeamA() == footballMatch.GetScoreOfTeamB())
                {
                    Debug.WriteLine($"{(playTime + playoffTime) / 1000 / 60}': It is time for penalty kicks.");
                    PenaltyKicksEngine(ref footballMatch);
                    Debug.WriteLine($"Penalty kicks ended. The winner is: {(footballMatch.GetScoreOfTeamA() > footballMatch.GetScoreOfTeamB() ? footballMatch.ReturnTeamA().name : footballMatch.ReturnTeamB().name)}.");
                }

            }
            Debug.WriteLine($"{matchTime}': Match ends with result:\t{footballMatch.ReturnTeamA().name} {footballMatch.GetScoreOfTeamA()} : {footballMatch.GetScoreOfTeamB()} {footballMatch.ReturnTeamB().name}.");

            if (footballMatch.GetScoreOfTeamA() > footballMatch.GetScoreOfTeamB())
            {
                footballMatch.ReturnTeamA().AddWin();
                footballMatch.ReturnTeamB().AddLoss();
            }
            else if (footballMatch.GetScoreOfTeamB() > footballMatch.GetScoreOfTeamA())
            {
                footballMatch.ReturnTeamB().AddWin();
                footballMatch.ReturnTeamA().AddLoss();
            }
            else
            {
                footballMatch.ReturnTeamA().AddDraw();
                footballMatch.ReturnTeamB().AddDraw();
            }
            footballMatch.ReturnTeamA().AddMatchPlayed();
            footballMatch.ReturnTeamB().AddMatchPlayed();
            System.Threading.Thread.Sleep(100);

        }

        /// <summary>
        /// Engine of the penalty kicks competition.
        /// </summary>
        /// <param name="footballMatch">The football match.</param>
        private void PenaltyKicksEngine(ref FootballMatch footballMatch)
        {
            bool isTurnA;
            int regularGoalsCount = footballMatch.GetScoreOfTeamA();

            if (Chance() % 2 == 0)
            {
                // Starts Team A.
                isTurnA = true;
                PenaltyEngine(ref footballMatch, isTurnA);
            }
            else
            {
                // Starts Team B.
                isTurnA = false;
                PenaltyEngine(ref footballMatch, isTurnA);
            }
            Debug.WriteLine($"\t{footballMatch.ReturnTeamA().name} {footballMatch.GetScoreOfTeamA() - regularGoalsCount} : {footballMatch.GetScoreOfTeamB() - regularGoalsCount} {footballMatch.ReturnTeamB().name}");

            int tenShots = 1;
            while (tenShots < 10)
            {
                if (!isTurnA)
                {
                    // It's Team A turn.
                    isTurnA = true;
                    PenaltyEngine(ref footballMatch, isTurnA);
                    tenShots++;
                }
                else
                {
                    // It's Team B turn.
                    isTurnA = false;
                    PenaltyEngine(ref footballMatch, isTurnA);
                    tenShots++;
                }
                Debug.WriteLine($"\t{footballMatch.ReturnTeamA().name} {footballMatch.GetScoreOfTeamA() - regularGoalsCount} : {footballMatch.GetScoreOfTeamB() - regularGoalsCount} {footballMatch.ReturnTeamB().name}");

                if (footballMatch.GetScoreOfTeamA() == footballMatch.GetScoreOfTeamB() + 3
                    | footballMatch.GetScoreOfTeamB() == footballMatch.GetScoreOfTeamA() + 3)
                {
                    // If it's 3:0 / 4:1 / 5:2 in penalties.
                    Debug.WriteLine("That's over now.");
                    break;
                }

                //TODO: Add elese if here to check if the last penalty execution is necessary.
                //if(footballMatch.GetScoreOfTeamA())
            }

            Debug.WriteLine("MORE");
            while (footballMatch.GetScoreOfTeamA() == footballMatch.GetScoreOfTeamB() + 1
                | footballMatch.GetScoreOfTeamA() + 1 == footballMatch.GetScoreOfTeamB())
            {
                if (footballMatch.GetScoreOfTeamA() == footballMatch.GetScoreOfTeamB() + 1)
                {
                    if (!isTurnA)
                    {
                        isTurnA = true;
                        int score = footballMatch.GetScoreOfTeamA();
                        PenaltyEngine(ref footballMatch, isTurnA);
                        if (footballMatch.GetScoreOfTeamA() != score)
                            break;
                    }
                    else
                    {
                        isTurnA = false;
                        int score = footballMatch.GetScoreOfTeamB();
                        PenaltyEngine(ref footballMatch, isTurnA);
                        if (footballMatch.GetScoreOfTeamB() == score)
                            break;
                    }
                }
                else if (footballMatch.GetScoreOfTeamA() + 1 == footballMatch.GetScoreOfTeamB())
                {
                    if (!isTurnA)
                    {
                        isTurnA = true;
                        int score = footballMatch.GetScoreOfTeamA();
                        PenaltyEngine(ref footballMatch, isTurnA);
                        if (footballMatch.GetScoreOfTeamA() == score)
                            break;
                    }
                    else
                    {
                        isTurnA = false;
                        int score = footballMatch.GetScoreOfTeamB();
                        PenaltyEngine(ref footballMatch, isTurnA);
                        if (footballMatch.GetScoreOfTeamB() != score)
                            break;
                    }
                }
                Debug.WriteLine($"\t{footballMatch.ReturnTeamA().name} {footballMatch.GetScoreOfTeamA() - regularGoalsCount} : {footballMatch.GetScoreOfTeamB() - regularGoalsCount} {footballMatch.ReturnTeamB().name}");
            }

            Debug.WriteLine("DRAW");
            while (footballMatch.GetScoreOfTeamA() == footballMatch.GetScoreOfTeamB())
            {
                if (!isTurnA)
                {
                    isTurnA = true;
                    PenaltyEngine(ref footballMatch, isTurnA);
                }
                else
                {
                    isTurnA = false;
                    PenaltyEngine(ref footballMatch, isTurnA);
                }
                Debug.WriteLine($"\t{footballMatch.ReturnTeamA().name} {footballMatch.GetScoreOfTeamA() - regularGoalsCount} : {footballMatch.GetScoreOfTeamB() - regularGoalsCount} {footballMatch.ReturnTeamB().name}");
            }
        }
        /// <summary>
        /// Engine of penalty kick.
        /// </summary>
        /// <param name="footballMatch">The football match.</param>
        /// <param name="isTurnA">If set to <c>true</c> then it is turn of <see cref="Team"/> A.</param>
        private void PenaltyEngine(ref FootballMatch footballMatch, bool isTurnA)
        {
            if (isTurnA)
            {
                Debug.Write($"{footballMatch.ReturnTeamA().name} is executing this penalty... ");
                if (IfTeamScored(5))
                {
                    Debug.Write($"and they scored a beautiful GOAL!");
                    footballMatch.AddScoreToTeamA();
                }
                else
                {
                    Debug.Write($"and they missed.");
                }
            }
            else
            {
                Debug.Write($"{footballMatch.ReturnTeamB().name} is executing this penalty... ");
                if (IfTeamScored(5))
                {
                    Debug.Write($"and they scored a beautiful GOAL!");
                    footballMatch.AddScoreToTeamB();
                }
                else
                {
                    Debug.Write($"and they missed.");
                }
            }
        }

        /// <summary>
        /// Random a number from 1 to 10.
        /// </summary>
        /// <returns>
        /// Random number typeof <see cref="int" />.
        /// </returns>
        private int Chance()
        {
            int rndChance = random.Next(1, 10);
            return rndChance;
        }
        /// <summary>
        /// If the <see cref="Team"/> has scored returns <c>true</c>.
        /// </summary>
        /// <param name="scoreChance">The chance to score. 0 no chance, 10 always. Recommended value is 3.</param>
        /// <returns>
        /// True if scored. False if not.
        /// </returns>
        private bool IfTeamScored(int scoreChance)
        {
            if (Chance() <= scoreChance)
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
