using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test_Lose_Health_If_Attacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(30, 10);

            axe.Attack(dummy);
            Assert.That(dummy.Health, Is.EqualTo(20));
        }

        [Test]
        public void Test_If_Dummy_Dead_Throws_Exeption()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }

        [Test]
        public void Test_Can_Dummy_Give_Xp()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(5, 10);

            axe.Attack(dummy);
            int xp = dummy.GiveExperience();
            Assert.That(xp, Is.EqualTo(10));
        }

        [Test]
        public void Test_Alive_Dummy_Cant_Give_Xp()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(30, 10);

            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() =>
            {
                int xp = dummy.GiveExperience();
            });
        }
    }
}