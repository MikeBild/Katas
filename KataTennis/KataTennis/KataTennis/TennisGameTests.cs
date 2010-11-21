using System;
using NUnit.Framework;

namespace KataTennis
{
    [TestFixture]
    public class TennisGameTests
    {
        [Test]
        public void Game_Init_should_0_point_on_game_start()
        {
            var game = new TennisGame();
            Assert.That(game.PlayerOne.Points, Is.EqualTo(Points.Love));
            Assert.That(game.PlayerTwo.Points, Is.EqualTo(Points.Love));
        }

        [Test]
        public void PlayerOne_should_wins_on_5_scores()
        {
            var game = new TennisGame();
            game.Win(game.PlayerOne);
            game.Win(game.PlayerOne);
            game.Win(game.PlayerOne);
            game.Win(game.PlayerOne);
            game.Win(game.PlayerOne);
            Assert.That(game.Finished, Is.True);
        }

        [Test]
        public void PlayerOne_should_not_wins_on_less_than_5_scores()
        {
            var game = new TennisGame();
            game.Win(game.PlayerOne);
            game.Win(game.PlayerOne);
            game.Win(game.PlayerOne);
            Assert.That(game.Finished, Is.False);
        }

        [Test]
        public void Game_should_swaped_advantage_and_game_should_not_finished_()
        {
            var game = new TennisGame();
            game.Win(game.PlayerOne);
            game.Win(game.PlayerTwo);
            game.Win(game.PlayerOne);
            game.Win(game.PlayerTwo);
            game.Win(game.PlayerOne);
            game.Win(game.PlayerTwo);
            game.Win(game.PlayerOne);
            game.Win(game.PlayerTwo);
            game.Win(game.PlayerOne);
            game.Win(game.PlayerTwo);
            game.Win(game.PlayerOne);
            game.Win(game.PlayerTwo);
            Assert.That(game.PlayerOne.Points, Is.EqualTo(Points.Forty));
            Assert.That(game.Finished, Is.False);            
        }

        [Test]
        public void Game_should_finished_with_2_wins_on_fouty_fouty()
        {
            var game = new TennisGame();
            game.Win(game.PlayerOne);
            game.Win(game.PlayerTwo);
            game.Win(game.PlayerOne);
            game.Win(game.PlayerTwo);
            game.Win(game.PlayerOne);
            game.Win(game.PlayerTwo);
            game.Win(game.PlayerOne);
            game.Win(game.PlayerOne);
            Assert.That(game.PlayerOne.Points, Is.EqualTo(Points.Game));
            Assert.That(game.Finished, Is.True);
        }
    }
}