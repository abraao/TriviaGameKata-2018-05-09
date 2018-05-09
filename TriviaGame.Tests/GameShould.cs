using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UglyTrivia;

namespace TriviaGame.Tests
{
    [TestFixture]
    public class GameShould
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            this.game = new Game();
        }

        [Test]
        public void Create_rock_question_with_int()
        {
            const int QUESTION_NUM = 1;

            string question = this.game.createRockQuestion(QUESTION_NUM);

            Assert.AreEqual(
                "Rock Question " + QUESTION_NUM.ToString(),
                question);
        }

        [Test]
        public void should_have_zero_players_when_constructed()
        {
            Assert.Zero(game.howManyPlayers());
        }
    }
}
