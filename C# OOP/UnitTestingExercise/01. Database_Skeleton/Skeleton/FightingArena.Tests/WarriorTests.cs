namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class WarriorTests
    {
        [TestCase(
            "abdul",
            30,
            100)]
        [TestCase(
            "sdas",
            100,
            1)]
        public void Test_Warrior_Constructors_Parameters(string name, int damage, int hp)
        {
            Warrior war = new Warrior(name, damage, hp);

            Assert.That(war.Name, Is.EqualTo(name));
            Assert.That(war.Damage, Is.EqualTo(damage));
            Assert.That(war.HP, Is.EqualTo(hp));
        }

        [TestCase(
            " ",
            30,
            100)]
        [TestCase(
            "",
            100,
            1)]
        [TestCase(
            null,
            30,
            100)]
        [TestCase(
            "abdul",
            0,
            1)]
        [TestCase(
            "theRock",
            -1,
            100)]
        [TestCase(
            "abdul",
            100,
            -1)]

        public void Test_Warrior_Properties_Set_Invalid_Input(string name, int damage, int hp)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior war = new Warrior(name, damage, hp);
            });

        }

        [TestCaseSource("TestAddMethodThrowsExeptionIfAddMoreThan16Persons")]
        public void Test_Warrior_Attak_Method(Warrior myWarrior, Warrior attakedWarrior,
            int expectedMyWarriorHp, int expectedAttakedWarriorHp)
        {
            myWarrior.Attack(attakedWarrior);

            Assert.That(myWarrior.HP, Is.EqualTo(expectedMyWarriorHp));
            Assert.That(attakedWarrior.HP, Is.EqualTo(expectedAttakedWarriorHp));

        }

        public static IEnumerable<TestCaseData> TestAddMethodThrowsExeptionIfAddMoreThan16Persons()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Warrior("asd", 10, 100),
                    new Warrior("asd", 10, 70),
                    90,
                    60
                    ),
                new TestCaseData(
                    new Warrior("asdqw", 50, 80),
                    new Warrior("asdasd", 20, 49),
                    60,
                    0
                    ),

            };

            foreach (TestCaseData testCase in testCases)
            {
                yield return testCase;
            }
        }

        [TestCaseSource("TestWarriorAttakMethodThrowsExeptionsWithInvalidHp")]
        public void Test_Warrior_Attak_Method_Throws_Exeptions_With_Invalid_Hp(Warrior myWarrior, Warrior attakedWarrior)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                myWarrior.Attack(attakedWarrior);
            });
        }

        public static IEnumerable<TestCaseData> TestWarriorAttakMethodThrowsExeptionsWithInvalidHp()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Warrior("asd", 10, 29),
                    new Warrior("asd", 10, 70)
                    ),
                new TestCaseData(
                    new Warrior("asdqw", 50, 80),
                    new Warrior("asdasd", 20, 30)
                    ),
                new TestCaseData(
                    new Warrior("asdqw", 50, 50),
                    new Warrior("asdasd", 55, 70)
                    ),

            };

            foreach (TestCaseData testCase in testCases)
            {
                yield return testCase;
            }
        }
    }
}