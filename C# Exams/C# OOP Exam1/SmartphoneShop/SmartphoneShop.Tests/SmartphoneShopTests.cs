using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Test_SmartphoneConstructor_Works()
        {
            Smartphone sm = new Smartphone("nokia", 9);

            Assert.AreEqual("nokia", sm.ModelName);
            Assert.AreEqual(9, sm.MaximumBatteryCharge);
            Assert.AreEqual(9, sm.CurrentBateryCharge);
        }

        [Test]
        public void Test_ShopConstructor_Works()
        {
            Shop shop = new Shop(5);


            Assert.AreEqual(0, shop.Count);
            Assert.AreEqual(5, shop.Capacity);

        }

        [Test]
        public void Test_CapacityPropetry_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-5);
            });

        }

        [Test]
        public void Test_ShopAdd_A_Smartphone()
        {
            Shop shop = new Shop(5);
            Smartphone sm = new Smartphone("asdas", 100);
            shop.Add(sm);

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Test_ShopAdd_An_ExistingSmartphone_ThrowsException()
        {
            Shop shop = new Shop(5);
            Smartphone sm = new Smartphone("asdas", 100);
            shop.Add(sm);


            Smartphone sam = new Smartphone("asdas", 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(sam);
            });
        }

        [Test]
        public void Test_ShopAdd_WhenShopCapacity_IsFull_ThrowsException()
        {
            Shop shop = new Shop(2);
            Smartphone sm = new Smartphone("asdas", 100);
            shop.Add(sm);


            Smartphone sam = new Smartphone("as", 120);
            shop.Add(sam);


            Smartphone saam = new Smartphone("was", 20);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(saam);
            });
        }

        [Test]
        public void Test_ShopRemove_A_Smartphone()
        {
            Shop shop = new Shop(2);
            Smartphone sm = new Smartphone("asdas", 100);
            shop.Add(sm);


            shop.Remove("asdas");

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_ShopRemove_A_Smartphone_ThrowsException_WhenTheSmartphone_DoesNotExist()
        {
            Shop shop = new Shop(2);
            Smartphone sm = new Smartphone("asdas", 100);
            shop.Add(sm);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("sd");
            });
        }


        [Test]
        public void Test_ShopTestPhone_Method_Works()
        {
            Shop shop = new Shop(2);
            Smartphone sm = new Smartphone("asdas", 100);
            shop.Add(sm);

            shop.TestPhone("asdas", 20);

            Assert.AreEqual(80, sm.CurrentBateryCharge);
        }

        [Test]
        public void Test_ShopTestPhone_Method_ThrowsException_WhenTheSmartphone_DoesNotExist()
        {
            Shop shop = new Shop(2);
            Smartphone sm = new Smartphone("asdas", 100);
            shop.Add(sm);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("sd", 20);
            });
        }

        [Test]
        public void Test_ShopTestPhone_Method_ThrowsException_WhenTheSmartphoneBattery_IsLowerThan_BatteryUsiage()
        {
            Shop shop = new Shop(2);
            Smartphone sm = new Smartphone("asdas", 10);
            shop.Add(sm);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("asdas", 20);
            });
        }


        [Test]
        public void Test_ShopChargePhone_Method_Works()
        {
            Shop shop = new Shop(2);
            Smartphone sm = new Smartphone("asdas", 100);
            shop.Add(sm);

            shop.TestPhone("asdas", 30);
            shop.ChargePhone("asdas");

            Assert.AreEqual(100, sm.CurrentBateryCharge);
        }


        [Test]
        public void Test_ShopChargePhone_Method_ThrowsException_WhenTheSmartphone_DoesNotExist()
        {
            Shop shop = new Shop(2);
            Smartphone sm = new Smartphone("asdas", 100);
            shop.Add(sm);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("sd");
            });
        }
    }
}