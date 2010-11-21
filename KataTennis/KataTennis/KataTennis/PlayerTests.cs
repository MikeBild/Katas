using KataTennis;
using NUnit.Framework;

namespace ConsoleApplication2
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Player_should_have_0_points()
        {
            var player = new PlayerScore();
            Assert.That(player.Points, Is.EqualTo(Points.Love));
        }


        [Test]
        public void Player_should_more_points_if_he_scores()
        {
            var player = new PlayerScore();
            player.AddPoints();
            Assert.That(player.Points, Is.EqualTo(Points.Fiveteen));
        }

        [Test]
        public void Player_should_wins_with_more_than_5_times_scores()
        {
            var player = new PlayerScore();
            player.AddPoints();
            player.AddPoints();
            player.AddPoints();
            player.AddPoints();
            player.AddPoints();
            Assert.That(player.Points, Is.EqualTo(Points.Game));
        }

        [Test]
        public void PlayerOne_should_remove_advantage_points()
        {
            var player = new PlayerScore();
            player.AddPoints();
            player.AddPoints();
            player.AddPoints();
            player.AddPoints();
            player.RemovePoints();
            Assert.That(player.Points, Is.EqualTo(Points.Forty));
        }

    }
}