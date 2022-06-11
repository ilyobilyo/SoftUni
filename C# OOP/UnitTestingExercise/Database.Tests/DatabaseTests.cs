namespace Database.Tests
{
    using NUnit.Framework;
    using System.Reflection;
    using System.Linq;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(
            new[] { 1, 2, 3 },
            new[] { 2, 3 },
            5
            )]
        [TestCase(
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, },
            new[] { 1, 2 },
            16
            )]
        [TestCase(
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
            new int[0],
            14
            )]
        public void Test_Constructor_And_Count_Propery(int[] constructorParams, int[] paramsToAdd, int expectedValue)
        {
            Database db = new Database(constructorParams);
            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                db.Add(paramsToAdd[i]);
            }

            Assert.That(db.Count, Is.EqualTo(expectedValue));
        }


        [TestCase(
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }
            )]
        public void Test_Constructor_Throws_Exeption_After_Add_More_Than_16_Elements(int[] constructorParams)
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(
                () => database = new Database(constructorParams));

        }

        [TestCase(
            new[] { 1, 2, 3 },
            new[] { 2, 3 },
            5
            )]
        [TestCase(
            new int[0],
            new[] { 2, 3 },
            2
            )]
        public void Test_Add_Element_At_The_Next_Free_Cell(int[] constructorParams, int[] paramsToAdd, int expectedValue)
        {
            Database database = new Database(constructorParams);
            foreach (var item in paramsToAdd)
            {
                database.Add(item);
            }

            Assert.That(database.Count, Is.EqualTo(expectedValue));
        }


        [TestCase(
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
            new[] { 1 }
            )]
        [TestCase(
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
            new[] { 14, 15, 16, 17 }
            )]
        [TestCase(
            new int[0],
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }
            )]
        public void Test_AddMethod_Throws_Exeption_When_Try_Add_17_Element(int[] constructorParams, int[] paramsToAdd)
        {
            Database database = new Database(constructorParams);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    foreach (var item in paramsToAdd)
                    {
                        database.Add(item);
                    }
                });
        }

        [TestCase(
            new[] { 1, 2 },
            new[] { 1, 3, 4 },
            2,
            3
            )]
        [TestCase(
            new[] { 1, 2 },
            new[] { 1, 3, 4 },
            5,
            0
            )]
        public void Test_Remove_At_The_Last_Index(int[] constructorParams, int[] paramsToAdd, int removesCount, int expectedCount)
        {
            Database database = new Database(constructorParams);

            foreach (var item in paramsToAdd)
            {
                database.Add(item);
            }

            for (int i = 0; i < removesCount; i++)
            {
                database.Remove();
            }

            Assert.That(database.Count, Is.EqualTo(expectedCount));
        }

        [TestCase(
            new[] { 1, 2 },
            new int[0],
            3
            )]
        [TestCase(
            new int[0],
            new[] { 1, 2 },
            3
            )]
        [TestCase(
            new int[0],
            new int[0],
            1
            )]
        public void Test_Remove_Empty_Database(int[] constructorParams, int[] paramsToAdd, int removeCount)
        {
            Database database = new Database(constructorParams);

            foreach (var item in paramsToAdd)
            {
                database.Add(item);
            }

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    for (int i = 0; i < removeCount; i++)
                    {
                        database.Remove();
                    }

                });

        }


        [TestCase(
            new[] { 1, 2 },
            new[] { 1, 3, 4 },
            new[] {1,2,1,3,4}
            )]
        [TestCase(
            new int[0],
            new[] { 1, 3, 4 },
            new[] { 1, 3, 4 }
            )]
        [TestCase(
            new int[0],
            new int[0],
            new int[0]
            )]
        public void Test_Fetch_Should_Return_Elements_To_Array(int[] constructorParams, int[] paramsToAdd, int[] expectedArray)
        {
            Database database = new Database(constructorParams);

            foreach(var item in paramsToAdd)
            {
                database.Add(item);
            }

            int[] fetchResult = database.Fetch();

            Assert.AreEqual(expectedArray, fetchResult);
        }
    }

}