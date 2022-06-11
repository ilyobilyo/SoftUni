namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        [TestCaseSource("TestEnrollWarriorsInArena")]
        public void Test_Enroll_Warriors_In_Arena(Warrior[] warriors,int expectedCount)
        {
            Arena arena = new Arena();

            foreach (Warrior war in warriors)
            {
                arena.Enroll(war);
            }

            Assert.That(expectedCount, Is.EqualTo(arena.Count));
        }

        public static IEnumerable<TestCaseData> TestEnrollWarriorsInArena()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("asdqw", 50, 80),
                        new Warrior("asdasd", 20, 78)
                    },
                    2
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("asdqw", 50, 80),
                        new Warrior("as", 20, 78),
                        new Warrior("vxc", 20, 78),
                        new Warrior("dfs", 20, 78),
                        new Warrior("rg", 20, 78),
                        new Warrior("gg", 20, 78),

                    },
                    6
                    ),
                new TestCaseData(
                    new Warrior[]
                    {
                        new Warrior("asdqw", 50, 80),
                        new Warrior("asdasd", 20, 78),
                        new Warrior("qwe", 20, 78),
                        new Warrior("qw", 20, 78),
                        new Warrior("hrfhj", 20, 78),
                        new Warrior("mn", 20, 78),
                        new Warrior("ashgjdasd", 20, 78),

                    },
                    7
                    ),

            };

            foreach (TestCaseData testCase in testCases)
            {
                yield return testCase;
            }
        }

        [Test]
        public void Test_Enroll_Throw_Exeption()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Ils", 60, 100);
            Warrior warrior1 = new Warrior("Ils", 34, 77);

            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior1);

            });

        }

        [Test]
        public void Test_Fight()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Ils", 60, 100);
            Warrior warrior1 = new Warrior("as", 30, 70);

            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            arena.Fight("Ils", "as");

            Assert.That(10, Is.EqualTo(warrior1.HP));
            Assert.That(70, Is.EqualTo(warrior.HP));

        }
    }
}
