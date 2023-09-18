using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Hotel_Constructor_ShouldSetInformation_Correctly()
        {
            var hotel = new Hotel("Mimosa", 1);

            var expectedName = "Mimosa";
            var expectedCategory = 1;
            var expectedTurnover = 0;

            Assert.That(hotel.FullName, Is.EqualTo(expectedName));
            Assert.That(hotel.Category, Is.EqualTo(expectedCategory));
            Assert.That(hotel.Turnover, Is.EqualTo(expectedTurnover));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(0));
            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));

        }

        [Test]
        public void Hotel_Constructor_ShouldThrowException_WithInvalidNameAndCategory()
        {
            Assert.Throws<ArgumentNullException>(() => { new Hotel(" ", 3); });
            Assert.Throws<ArgumentNullException>(() => { new Hotel(null, 3); });
            Assert.Throws<ArgumentNullException>(() => { new Hotel("", 3); });


            Assert.Throws<ArgumentException>(() => { new Hotel("Mimosa", 0); });
            Assert.Throws<ArgumentException>(() => { new Hotel("Mimosa", 6); });
            Assert.Throws<ArgumentException>(() => { new Hotel("Mimosa", -1); });

        }

        [Test]
        public void Hotel_AddRoom_ShouldWork_Correcly()
        {
            var hotel = new Hotel("Mimosa", 1);
            var room = new Room(2, 20);

            hotel.AddRoom(room);

            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        [Test]
        public void Hotel_BookRoom_ShoultThrowExceptio_ForIncorectAdults()
        {
            var hotel = new Hotel("Mimosa", 1);
            var room = new Room(3, 53);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => { hotel.BookRoom(0, 2, 2, 200); });
            Assert.Throws<ArgumentException>(() => { hotel.BookRoom(-1, 2, 2, 200); });
        }

        [Test]
        public void Hotel_BookRoom_ShoultThrowExceptio_ForIncorectChildren()
        {
            var hotel = new Hotel("Mimosa", 1);
            var room = new Room(3, 53);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => { hotel.BookRoom(2, -1, 2, 200); });
            Assert.Throws<ArgumentException>(() => { hotel.BookRoom(2, -12, 2, 200); });
        }

        [Test]
        public void Hotel_BookRoom_ShoultThrowExceptio_ForIncorectDuration()
        {
            var hotel = new Hotel("Mimosa", 1);
            var room = new Room(3, 53);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => { hotel.BookRoom(2, 0, 0, 200); });
            Assert.Throws<ArgumentException>(() => { hotel.BookRoom(2, 0, -1, 200); });
        }

        [Test]
        public void Hotel_BookRoom_ShoultWork_Correctly()
        {
            var hotel = new Hotel("Mimosa", 1);
            var room = new Room(3, 50);
            hotel.AddRoom(room);

            hotel.BookRoom(1, 1, 2, 100);
            var expectedTurnover = 100;

            Assert.That(hotel.Turnover, Is.EqualTo(expectedTurnover));
            Assert.That(hotel.Bookings.Count, Is.EqualTo(1));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));

        }

        [Test]
        public void Hotel_BookRoom_ShouldNOT_Work_Correctly_WithMoreGuest()
        {
            var hotel = new Hotel("Mimosa", 1);
            var room = new Room(3, 50);
            hotel.AddRoom(room);

            hotel.BookRoom(2, 2, 2, 100);
            var expectedTurnover = 0;

            Assert.That(hotel.Turnover, Is.EqualTo(expectedTurnover));
            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        [Test]
        public void Hotel_BookRoom_ShouldNOTWork_Correctly_WithLessBudget()
        {
            var hotel = new Hotel("Mimosa", 1);
            var room = new Room(3, 50);
            hotel.AddRoom(room);

            hotel.BookRoom(1, 1, 2, 80);
            var expectedTurnover = 0;

            Assert.That(hotel.Turnover, Is.EqualTo(expectedTurnover));
            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}


    }
}