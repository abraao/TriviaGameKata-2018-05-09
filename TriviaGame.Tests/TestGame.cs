using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyTrivia;

namespace TriviaGame.Tests
{
    class TestGame : Game
    {
        public LinkedList<string> PopQuestions => popQuestions;

        public LinkedList<string> ScienceQuestions => scienceQuestions;

        public LinkedList<string> SportsQuestions => sportsQuestions;

        public LinkedList<string> RockQuestions => rockQuestions;

        public int[] Places => places;
        public int[] Purses => purses;
        public bool[] InPenaltyBox => inPenaltyBox;

    }
}
