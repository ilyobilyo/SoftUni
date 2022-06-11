using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test_If_Weapon_Loses_Durability_After_Attak()
        {
            Axe axe = new Axe(10, 20);
            axe.Attack(new Dummy(30, 1));
            Assert.That(axe.DurabilityPoints, Is.EqualTo(19));
        }

        [Test]
        public void Test_Attaking_With_Broken_Weapon()
        {
            Axe axe = new Axe(10, -1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(new Dummy(30, 1));

            });
        }
    }
}