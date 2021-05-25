using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserGroup.Data;

namespace UserGroup.Business.Tests
{
    [TestClass]
    public class EventManagerTests
    {
        [TestMethod]
        public void Create_WithNullEvent_ThrowsException()
        {
            var manager = new EventManager(new Random());
            Assert.ThrowsException<ArgumentNullException>(() => manager.Create(null!));
        }

        [TestMethod]
        public void Create_WithEventThatHasSpeaker_AddsEvent()
        {
            //Arrange
            var manager = new EventManager(new Random());
            Event userGroup = new();
            Speaker speaker = new();
            userGroup.Speakers.Add(speaker);

            //Act
            manager.Create(userGroup);

            //Assert
            Assert.IsTrue(EventContext.Events.Contains(userGroup));
            Assert.AreEqual(1, userGroup.Speakers.Count);
            Assert.AreEqual(speaker, userGroup.Speakers[0]);
            Assert.AreNotEqual(0, userGroup.Id);
            Assert.AreEqual(1, EventContext.Events.Count(x => x.Id == userGroup.Id));
        }

        [TestMethod]
        public void Create_WithEventThatHasNoSpeaker_AssignsRandomSpeaker()
        {
            //Arrange
            var random = new Random(42);
            var manager = new EventManager(random);
            Event userGroup = new();

            //Act
            manager.Create(userGroup);

            //Assert
            var random2 = new Random(42);
            int expectedIndex = random2.Next(EventContext.Speakers.Count);
            Assert.IsTrue(EventContext.Events.Contains(userGroup));
            Assert.AreEqual(1, userGroup.Speakers.Count);
            Assert.AreEqual(EventContext.Speakers[expectedIndex], userGroup.Speakers[0]);
        }
    }
}
