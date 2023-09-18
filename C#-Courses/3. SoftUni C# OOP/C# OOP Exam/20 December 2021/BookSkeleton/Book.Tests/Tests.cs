namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    public class Tests
    {
        private Book defBook;

        [SetUp]
        public void SetUp()
        {
            this.defBook = new Book("Harry Potter", "J. K. Rowling");
        }


        [Test]
        public void Constructor_ShouldInitialize_BookNameCorrectly()
        {
            string expectedBookName = "Harry Potter";
            Book book = new Book(expectedBookName, "J.K.Rowling");

            string actualBookName = book.BookName;
            Assert.AreEqual(expectedBookName, actualBookName);
        }

        [Test]
        public void Constructor_ShouldInitialize_AuthorNameCorrectly()
        {
            string expectedAutorHane = "J.K.Rowling";
            Book book = new Book("Harry Potter", expectedAutorHane);

            string actualAuthorName = book.Author;
            Assert.AreEqual(expectedAutorHane, actualAuthorName);
        }

        [Test]
        public void Constructor_ShouldInitialize_FootNoteDictionary()
        {

            Type bookType = this.defBook.GetType();

            FieldInfo dictFieldInfo = bookType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(fi => fi.Name == "footnote");

            object fieldValue = dictFieldInfo.GetValue(this.defBook);
            Assert.IsNotNull(fieldValue);
        }

        [Test]
        public void Count_ShouldReturnZero_WhenNOFootNotesAdded()
        {
            int expectedCount = 0;
            int actualCount = this.defBook.FootnoteCount;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Count_ShouldReturnCorrectCount_WhenFootNotesAreAdded()
        {
            int expectedCount = 2;
            for (int i = 0; i < expectedCount; i++)
            {
                this.defBook.AddFootnote(i, i.ToString());
            }
            int actualCount = this.defBook.FootnoteCount;
            Assert.AreEqual(expectedCount, actualCount);
        }


        [TestCase("Real Name")]
        [TestCase("1")]
        [TestCase("   ")]
        public void BookName_ShouldSet_CorrectValues(string bookName)
        {
            Book book = new Book(bookName, "Author");
            string expectedBookName = bookName;
            string actualBookName = book.BookName;

            Assert.AreEqual(expectedBookName, actualBookName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void BookName_ShouldThrowExeption_WhenBookNameIsNullOrEmpty(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, "Author");
            }, "Invalid BookName!");
        }


        [TestCase("Real Name")]
        [TestCase("1")]
        [TestCase("   ")]
        public void AuthorName_ShouldSet_CorrectValues(string authorName)
        {
            Book book = new Book("Book name", authorName);
            string expectedAuthorName = authorName;
            string actualauthorName = book.Author;

            Assert.AreEqual(expectedAuthorName, actualauthorName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void AuthorName_ShouldThrowExeption_WhenBookNameIsNullOrEmpty(string authorName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Book name", authorName);
            });
        }

        [Test]
        public void AddingShouldIncreaseCount()
        {
            int expectedCount = 1;
            for (int i = 0; i < expectedCount; i++)
            {
                this.defBook.AddFootnote(i, i.ToString());
            }
            int actualCount = this.defBook.FootnoteCount;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingFootNoteShouldAddKeyInTheDictionary()
        {
            int addedKey = 1;
            this.defBook.AddFootnote(addedKey, "Random text");

            Type bookType = this.defBook.GetType();
            FieldInfo footNoteFieldInfo = bookType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(fi => fi.Name == "footnote");

            Dictionary<int, string> fieldValue = (Dictionary<int, string>)footNoteFieldInfo.GetValue(this.defBook);
            bool containsKey = fieldValue.ContainsKey(addedKey);

            Assert.IsTrue(containsKey);
        }

        [Test]
        public void AddingExistingFootNote_ShouldThrowException()
        {
            int sameKey = 1;
            this.defBook.AddFootnote(sameKey, "Random note");
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defBook.AddFootnote(sameKey, "another text");
            });
        }

        [Test]
        public void FindFootNote_ShouldReturnCorrectText_WhenExisting()
        {
            int footKey = 1;
            string footText = "Text";
            this.defBook.AddFootnote(footKey, footText);

            string expectedResult = $"Footnote #{footKey}: {footText}";
            string actualResult = this.defBook.FindFootnote(footKey);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindFootNote_ShouldThrowException_IfthereAreFootNotesButPassedKeyDoesNotExist()
        {
            int footKey = 1;
            string footText = "Text";
            this.defBook.AddFootnote(footKey, footText);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defBook.FindFootnote(999);
            });
        }

        [Test]
        public void FindFootNote_ShouldThrowException_IfThereAreNOFooTNOtesAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defBook.FindFootnote(1);
            });
        }

        [Test]
        public void AlterFootNoteShouldChangeTextWhenFootNoteExists()
        {
            int footKey = 1;
            string footText = "Text";
            this.defBook.AddFootnote(footKey, footText);

            string expectedText = "New text";
            this.defBook.AlterFootnote(footKey, expectedText);


            Type bookType = this.defBook.GetType();
            FieldInfo footNoteFieldInfo = bookType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(fi => fi.Name == "footnote");

            Dictionary<int, string> fieldValue = (Dictionary<int, string>)footNoteFieldInfo.GetValue(this.defBook);

            string actualText = fieldValue[footKey];
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void AlterFootNoteShouldThrowException_IfThereNotesButPassedKeysDoesNotExists()
        {
            int footKey = 1;
            string footText = "Text";
            this.defBook.AddFootnote(footKey, footText);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defBook.AlterFootnote(999, "New invalid text");
            });
        }

        [Test]
        public void AlterFootNote_ShouldThrowExpection_IfThereAreNoFootNotesAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defBook.AlterFootnote(1, "Invalid Text");
            });
        }
    }
}