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
        private TestGame game;

        [SetUp]
        public void SetUp()
        {
            this.game = new TestGame();
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
        public void have_zero_players_when_constructed()
        {
            Assert.Zero(game.howManyPlayers());
        }
            
        [Test]    
        public void increment_the_number_of_players_when_adding()
        {
            const string NEW_PLAYER_NAME = "New Player";

            int beforeAdding = game.howManyPlayers();
            bool additionResult = game.add(NEW_PLAYER_NAME);

            Assert.True(additionResult);
            Assert.AreEqual(
                beforeAdding+1,
                game.howManyPlayers());
        }

        [Test]
        public void not_be_playable_with_fewer_than_two_players()
        {
            Assert.IsFalse(this.game.isPlayable());

            this.game.add("new player");

            Assert.IsFalse(this.game.isPlayable());
        }

        [Test]
        public void update_the_places_slot_when_a_player_is_added()
        {
            this.game.add("P1");
            Assert.Zero(this.game.Places[this.game.howManyPlayers()]);
        }

        [Test]
        public void update_the_purses_slot_when_a_player_is_added()
        {
            this.game.add("P1");
            Assert.Zero(this.game.Purses[this.game.howManyPlayers()]);
        }

        [Test]
        public void update_the_in_penalty_box_slot_when_a_player_is_added()
        {
            this.game.add("P1");
            Assert.False(this.game.InPenaltyBox[this.game.howManyPlayers()]);
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void be_playable_with_two_or_more_players(int numPlayers)
        {
            for (int ii = 0; ii < numPlayers; ii++)
            {
                this.game.add("new player " + ii);
            }

            Assert.True(this.game.isPlayable());
        }

        [Test]
        public void initialize_50_of_each_question_type()
        {
            AssertQuestionListExists(this.game.PopQuestions, "Pop Question ");
            AssertQuestionListExists(this.game.ScienceQuestions, "Science Question ");
            AssertQuestionListExists(this.game.SportsQuestions, "Sports Question ");
            AssertQuestionListExists(this.game.RockQuestions, "Rock Question ");
        }

        private void AssertQuestionListExists(LinkedList<string> questions, string expectedPrefix)
        {
            int ii = 0;
            foreach (string question in questions)
            {
                Assert.AreEqual(expectedPrefix + ii, question);
                ii++;
            }
        }
    }
}
