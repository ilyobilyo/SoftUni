using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballPlayer player;
        private FootballPlayer player2;


        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("ils", 10, "Midfielder");
            player2 = new FootballPlayer("los", 11, "Midfielder");
        }

        [Test]
        public void TestTeamCtor()
        {
            var pl = new FootballTeam("spartak", 22);

            Assert.That(pl.Name == "spartak");
            Assert.That(pl.Capacity == 22);
        }

        [Test]
        public void TestTeamNamePropertyThrows()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var team = new FootballTeam(null, 22);
            });
        }

        [Test]
        public void TestTeamNamePropertyEmptyThrows()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var team = new FootballTeam("", 22);
            });
        }

        [Test]
        public void TestTeamCapacityPropertyThrows()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var team = new FootballTeam("towoa", 4);
            });
        }

        [Test]
        public void TestTeamAddPlayerMethod()
        {
            var pl = new FootballTeam("spartak", 22);

            var result = pl.AddNewPlayer(player);

            Assert.That(result == $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}");
        }

        [Test]
        public void TestTeamAddPlayerMethodNoMorePositions()
        {
            var pl = new FootballTeam("spartak", 15);

            string result = null;

            for (int i = 0; i < 16; i++)
            {
                result = pl.AddNewPlayer(player);
            }

            Assert.That(result == $"No more positions available!");
        }

        [Test]
        public void TestTeamPickPlayerMethod()
        {
            var pl = new FootballTeam("spartak", 22);

            pl.AddNewPlayer(player);
            pl.AddNewPlayer(player2);

            var result = pl.PickPlayer("ils");

            Assert.That(result == player);
        }

        [Test]
        public void TestTeamPickPlayerNotFoundMethod()
        {
            var pl = new FootballTeam("spartak", 22);

            pl.AddNewPlayer(player);
            pl.AddNewPlayer(player2);

            var result = pl.PickPlayer("asdasdasd");

            Assert.That(result == null);
        }

        [Test]
        public void TestTeamPlayerScoreMethod()
        {
            var pl = new FootballTeam("spartak", 22);

            pl.AddNewPlayer(player);
            pl.AddNewPlayer(player2);

            var result = pl.PlayerScore(10);

            Assert.That(result == $"{player.Name} scored and now has {player.ScoredGoals} for this season!");
            Assert.That(player.ScoredGoals == 1);
        }

        [Test]
        public void TestTeamPlayersProperty()
        {
            var pl = new FootballTeam("spartak", 22);

            pl.AddNewPlayer(player);
            pl.AddNewPlayer(player2);

            Assert.That(pl.Players.Count == 2);
        }

        [Test]
        public void TestPlayerNameProp()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var pl = new FootballPlayer(null, 10, "Goalkeeper");
            });
        }

        [Test]
        public void TestPlayerNumberProp()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var pl = new FootballPlayer("asdasd", 55, "Goalkeeper");
            });
        }

        [Test]
        public void TestPlayerPositionProp()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var pl = new FootballPlayer("asdasd", 5, "asdasda");
            });
        }
    }
}