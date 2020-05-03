using Moq;
using MyLogiscool.Data;
using MyLogiscool.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogiscool.Logic.Tests
{
    /// <summary>
    /// Tests for the mainLogic's connection part.
    /// </summary>
    internal class ConnectionLogicTest
    {
        /// <summary>
        /// Mocked connectionRepo.
        /// </summary>
        private Mock<IRepository<OwnerSchoolConnector>> mockconnectionrepo;

        /// <summary>
        /// Business Logic.
        /// </summary>
        private MainLogic ml;

        /// <summary>
        /// Setting up the mocked elements of the connection database.
        /// </summary>
        [SetUp]
        public void InitConnection()
        {
            this.mockconnectionrepo = new Mock<IRepository<OwnerSchoolConnector>>();
            this.ml = new MainLogic(this.mockconnectionrepo.Object);

            List<OwnerSchoolConnector> mockconnections = new List<OwnerSchoolConnector>();
            var connection = new OwnerSchoolConnector()
            {
                Connection_Id = 1,
                Owner_Id = 1,
                School_Id = 1,
            };
            mockconnections.Add(new OwnerSchoolConnector()
            {
                Connection_Id = 1,
                Owner_Id = 1,
                School_Id = 1,
            });
            mockconnections.Add(new OwnerSchoolConnector()
            {
                Connection_Id = 2,
                Owner_Id = 1,
                School_Id = 2,
            });
            mockconnections.Add(new OwnerSchoolConnector()
            {
                Connection_Id = 3,
                Owner_Id = 2,
                School_Id = 3,
            });

            this.mockconnectionrepo.Setup(repo => repo.ReadAll()).Returns(mockconnections);
            this.mockconnectionrepo.Setup(repo => repo.Read(It.IsAny<int>())).Returns(connection);
        }

        /// <summary>
        /// Testing the Create() method.
        /// </summary>
        [Test]
        public void ConnectionCreate()
        {
            ml.CreateConnection(new OwnerSchoolConnector()
            {
                Connection_Id = 4,
                Owner_Id = 2,
                School_Id = 5
            });

            mockconnectionrepo.Verify(v => v.Create(It.IsAny<OwnerSchoolConnector>()));
        }

        /// <summary>
        /// Testing the Delete() method with an object.
        /// </summary>
        [Test]
        public void ConnectionDeleteTestObj()
        {
            ml.DeleteConnection(new OwnerSchoolConnector()
            {
                Connection_Id = 3,
                Owner_Id = 2,
                School_Id = 3
            });

            mockconnectionrepo.Verify(v => v.Delete(It.IsAny<OwnerSchoolConnector>()));
        }

        /// <summary>
        /// Testing the Delete() methid with an int.
        /// </summary>
        [Test]
        public void ConnectionDeleteTestInt()
        {
            ml.DeleteConnection(1);
            mockconnectionrepo.Verify(v => v.Delete(It.IsAny<int>()));
        }

        /// <summary>
        /// Testing the Update() method.
        /// </summary>
        [Test]
        public void ConnectionUpdateTest()
        {
            ml.UpdateConnection(new OwnerSchoolConnector()
            {
                Connection_Id = 2,
                Owner_Id = 1,
                School_Id = 9
            });

            mockconnectionrepo.Verify(v => v.Update(It.IsAny<OwnerSchoolConnector>()));
        }

        /// <summary>
        /// Testing the ReadAll() method.
        /// </summary>
        [Test]
        public void ConnectionReadAllTest()
        {
            var testTemp = ml.ReadAllConnection();
            Assert.NotNull(testTemp);
        }

        /// <summary>
        /// Testing the Read() method.
        /// </summary>
        [Test]
        public void ConnectionReadTest()
        {
            var testTemp = ml.ReadConnection(2);
            Assert.NotNull(testTemp);
        }
    }
}
