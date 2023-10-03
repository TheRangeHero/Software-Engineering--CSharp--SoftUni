namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database defDb;
        [SetUp]
        public void SetUp()
        {
            this.defDb = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Text_ConstructorShouldIntializeData_WithCorrectCount(int[] data)
        {
            Database db = new Database(data);

            int expectedCount = data.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 })]
        public void Text_ConstructorShouldThrowException_WhenInputDataisAbove_16Count(int[] data)
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(data);

            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_ConstructorShouldAddElementsIntoDataField(int[] data)
        {
            Database database = new Database(data);
            int[] expectedArray = data;
            int[] actualArray = database.Fetch();

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_CountShouldReturnCorrectCount(int[] data)
        {
            Database database = new Database(data);

            int expectedCount = data.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }
        [Test]
        public void Test_AddingElements_ShouldIncreasecount()
        {
            int excpectedCount = 5;
            for (int i = 1; i <= excpectedCount; i++)
            {
                defDb.Add(i);
            }
            int actualCount = this.defDb.Count;
            Assert.AreEqual(excpectedCount, actualCount);
        }
        [Test]
        public void Test_AddingElements_ShouldAddthemToTheDataCollection()
        {
            int[] expectedData = new int[5];
            for (int i = 1; i <= 5; i++)
            {
                defDb.Add(i);
                expectedData[i - 1] = i;
            }
           
            int[] actualData = this.defDb.Fetch();
            CollectionAssert.AreEqual(expectedData, actualData);
        }
        [Test]
        public void Test_AddingMoreThan16ElementsShouldThrowException()
        {
            for (int i = 1; i <= 16; i++)
            {
                this.defDb.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defDb.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void Text_RemovingElement_ShouldDecreaseCount()
        {
            
            int initialCount = 5;
            for (int i = 1; i <= initialCount; i++)
            {
                this.defDb.Add(i);
            }

            int removeCount = 2;
            for (int i = 1; i <= removeCount; i++)
            {
                this.defDb.Remove();
            }

            int expectedCount = initialCount-removeCount;
            int actualCount = this.defDb.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void Test_RemovingElement_ShouldRemoveFromTheDataCollection()
        {
            int initialCount = 5;
            for (int i = 1; i <= initialCount; i++)
            {
                this.defDb.Add(i);
            }

            int removeCount = 2;
            for (int i = 1; i <= removeCount; i++)
            {
                this.defDb.Remove();
            }
            int[] expectedData = new int[] { 1, 2, 3 };
            int[] actualData = defDb.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }
        [Test]
        public void Test_RemoveShouldthrowExceptionWhenThereAreNoElementsInDB()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defDb.Remove();
            }, "The collection is empty!");
        }
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCollectionWithElementsIntheDB(int[] data)
        {
            Database db = new Database(data);
            int[] expectedData = data;
            int[] actualData = db.Fetch();
            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}
