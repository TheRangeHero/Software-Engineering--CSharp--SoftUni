using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FootBallPlayer_Constructor_Shoudl_SetProperly()
        {
            var footballPLayer = new FootballPlayer("Dido", 9, "Forward");

            var expectedPosition = "Forward";
            var expectedNumber = 9;
            var expectedName = "Dido";
            var expectedScoreGoals = 0;

            Assert.That(footballPLayer.Name, Is.EqualTo(expectedName));
            Assert.That(footballPLayer.PlayerNumber, Is.EqualTo(expectedNumber));
            Assert.That(footballPLayer.Position, Is.EqualTo(expectedPosition));
            Assert.That(footballPLayer.ScoredGoals, Is.EqualTo(expectedScoreGoals));
        }

        [Test]
        public void FootBallPlayer_Constructor_ShouldThrowException_WhenInFormationIsWrong()
        {
            //  Assert.Throws<ArgumentException>(() => { new FootballPlayer(" ", 9, "Forward"); });
            Assert.Throws<ArgumentException>(() => { new FootballPlayer(null, 9, "Forward"); });
            Assert.Throws<ArgumentException>(() => { new FootballPlayer("", 9, "Forward"); });


            Assert.Throws<ArgumentException>(() => { new FootballPlayer("Dido", 0, "Forward"); });
            Assert.Throws<ArgumentException>(() => { new FootballPlayer("Dido", -1, "Forward"); });
            Assert.Throws<ArgumentException>(() => { new FootballPlayer("Dido", 30, "Forward"); });

            Assert.Throws<ArgumentException>(() => { new FootballPlayer("Dido", 9, "Zashtita"); });
            Assert.Throws<ArgumentException>(() => { new FootballPlayer("Dido", 9, "FeederJung"); });
            Assert.Throws<ArgumentException>(() => { new FootballPlayer("Dido", 9, "Defender"); });


        }
        [Test]
        public void FootBallPlayer_ScoreGoal_ShouldWork_Correctly()
        {
            var footballPLayer = new FootballPlayer("Dido", 9, "Forward");

            footballPLayer.Score();
            Assert.That(footballPLayer.ScoredGoals, Is.EqualTo(1));
        }

        [Test]
        public void FootballTeam_Constructor_Should_SetInformationProperly()
        {
            var footballTeam = new FootballTeam("G2", 16);

            var expectedName = "G2";
            var expectedNumber = 16;

            Assert.That(footballTeam.Name, Is.EqualTo(expectedName));
            Assert.That(footballTeam.Capacity, Is.EqualTo(expectedNumber));
            Assert.That(footballTeam.Players.Count, Is.EqualTo(0));
        }

        [Test]
        public void FootballTeam_Constructor_ShouldThrowException_WithWrongInformation()
        {
            Assert.Throws<ArgumentException>(() => { new FootballTeam(null, 16); });
            Assert.Throws<ArgumentException>(() => { new FootballTeam("", 16); });
            Assert.Throws<ArgumentException>(() => { new FootballTeam(string.Empty, 16); });


            Assert.Throws<ArgumentException>(() => { new FootballTeam("G2", 9); });
            Assert.Throws<ArgumentException>(() => { new FootballTeam("G2", -1); });
        }

        [Test]
        public void FootballTeam_AddNewPlayer_ShouldAddNewPlayer_Correctly()
        {
            var footballTeam = new FootballTeam("G2", 16);
            var footballPLayer = new FootballPlayer("Dido", 9, "Forward");
            var footballPLayerTow = new FootballPlayer("Genadi", 11, "Forward");

            footballTeam.AddNewPlayer(footballPLayer);

            Assert.That(footballTeam.Players.Count, Is.EqualTo(1));
            footballTeam.AddNewPlayer(footballPLayerTow);
            Assert.That(footballTeam.Players.Count, Is.EqualTo(2));
        }


        [Test]
        public void FootballTeam_AddNewPlayer_ShouldThrowException_UponAddingOverTeamCapacity()
        {
            var footballTeam = new FootballTeam("G2", 16);
            for (int i = 0; i < 16; i++)
            {
                footballTeam.AddNewPlayer(new FootballPlayer("DIdo", 9, "Forward"));
            }


            var footballPLayerTow = new FootballPlayer("Genadi", 11, "Forward");


            Assert.That(footballTeam.AddNewPlayer(footballPLayerTow), Is.EqualTo("No more positions available!"));
        }


        [Test]
        public void FootballTeam_PickPlayer_ShouldReturn_CorectInformation()
        {
            var footballTeam = new FootballTeam("G2", 16);
            var footballPLayer = new FootballPlayer("Dido", 9, "Forward");
            var footballPLayerTow = new FootballPlayer("Genadi", 11, "Forward");
            footballTeam.AddNewPlayer(footballPLayer);
            footballTeam.AddNewPlayer(footballPLayerTow);


            Assert.That(footballTeam.PickPlayer("Dido"), Is.EqualTo(footballPLayer));
            Assert.That(footballTeam.PickPlayer("Genadi"), Is.EqualTo(footballPLayerTow));
        }


        [Test]
        public void FootBallTeam_PlayerScore_ShouldReturn_CorrectMessage()
        {
            var footballTeam = new FootballTeam("G2", 16);
            var footballPLayer = new FootballPlayer("Dido", 9, "Forward");
            var footballPLayerTow = new FootballPlayer("Genadi", 11, "Forward");
            footballTeam.AddNewPlayer(footballPLayer);
            footballTeam.AddNewPlayer(footballPLayerTow);



            Assert.That(footballPLayer.PlayerNumber, Is.EqualTo(9));
            Assert.That(footballPLayerTow.PlayerNumber, Is.EqualTo(11));
      
            Assert.That(footballTeam.PlayerScore(9), Is.EqualTo($"{footballPLayer.Name} scored and now has {footballPLayer.ScoredGoals} for this season!"));
            Assert.That(footballTeam.PlayerScore(11), Is.EqualTo($"{footballPLayerTow.Name} scored and now has {footballPLayerTow.ScoredGoals} for this season!"));
            Assert.That(footballPLayer.ScoredGoals, Is.EqualTo(1));
            Assert.That(footballPLayerTow.ScoredGoals, Is.EqualTo(1));
        }


        //[Test]
        //public void AA()
        //{ 

        //}


        //[Test]
        //public void AA()
        //{ 

        //}


        //[Test]
        //public void AA()
        //{ 

        //}



    }
}