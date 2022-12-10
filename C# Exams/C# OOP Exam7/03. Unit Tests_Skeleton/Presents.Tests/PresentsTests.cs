namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Present present2;
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            present = new Present("test", 2.5);
            present2 = new Present("test2", 1.5);
            bag = new Bag();
        }

        [Test]
        public void TestPresentCtor()
        {
            var pres = new Present("jon", 2.5);

            Assert.That(pres.Name == "jon");
            Assert.That(pres.Magic == 2.5);
        }

        [Test]
        public void TestBagCreateSucceed()
        {
            var result = bag.Create(present);

            Assert.That(result == $"Successfully added present {present.Name}.");
        }

        [Test]
        public void TestBagCreateThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(null);
            });
        }

        [Test]
        public void TestBagCreateThrowsInvalidOperationException()
        {
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void TestBagRemoveSucceed()
        {
            bag.Create(present);

            var result = bag.Remove(present);

            Assert.That(result == true);
        }

        [Test]
        public void TestBagRemoveFailed()
        {
            bag.Create(present);

            var result = bag.Remove(new Present("ss", 1.2));

            Assert.That(result == false);
        }

        [Test]
        public void TestBagGetPresentWithLeastMagicSucceed()
        {
            bag.Create(present);
            bag.Create(present2);

            var result = bag.GetPresentWithLeastMagic();

            Assert.That(result == present2);
        }

        [Test]
        public void TestBagGetPresentWithLeastMagicFailed()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var result = bag.GetPresentWithLeastMagic();
            });
        }

        [Test]
        public void TestBagGetPresentSucceed()
        {
            bag.Create(present);
            bag.Create(present2);

            var result = bag.GetPresent("test");

            Assert.That(result == present);
        }

        [Test]
        public void TestBagGetPresentFailed()
        {
            bag.Create(present);
            bag.Create(present2);

            var result = bag.GetPresent("saas");

            Assert.That(result == null);
        }

        [Test]
        public void TestBagGetPresentsSucceed()
        {
            bag.Create(present);
            bag.Create(present2);

            var result = bag.GetPresents();

            Assert.That(result.Count == 2);
        }


        [Test]
        public void TestBagCtor()
        {
            var b = new Bag();

            Assert.That(b != null);
        }
    }
}
