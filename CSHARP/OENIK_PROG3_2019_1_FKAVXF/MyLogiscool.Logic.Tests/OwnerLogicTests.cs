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
    /// Tests for the mainLogic's owner part.
    /// </summary>
    internal class OwnerLogicTests
    {
        /// <summary>
        /// Mocked OwnerRepo.
        /// </summary>
        Mock<IRepository<Owners>> mockownerrepo;

        /// <summary>
        /// Business Logic.
        /// </summary>
        MainLogic ml;

        /// <summary>
        /// Setting up the mocked elements of the owner databese.
        /// </summary>
        [SetUp]
        public void InitOwner()
        {
            mockownerrepo = new Mock<IRepository<Owners>>();
            ml = new MainLogic(mockownerrepo.Object);

            List<Owners> mockowners = new List<Owners>();
            var owner = new Owners
            {
                Owner_Id = 1,
                Name = "Kiss Gyozo",
                City = "Budapest",
                HasPaidThisYear = true,
                IsReplaceable = false,
                StartYear = 2018
            };
            mockowners.Add(new Owners()
            {
                Owner_Id = 1,
                Name = "Kiss Gyozo",
                City = "Budapest",
                HasPaidThisYear = true,
                IsReplaceable = false,
                StartYear = 2018

            }
                );
            mockowners.Add(new Owners()
            {
                Owner_Id = 2,
                Name = "Telepes Katalin",
                City = "Szentendre",
                HasPaidThisYear = false,
                IsReplaceable = true,
                StartYear = 2013

            }
                );
            mockowners.Add(new Owners()
            {
                Owner_Id = 3,
                Name = "Kalap Tido",
                City = "Athen",
                HasPaidThisYear = true,
                IsReplaceable = true,
                StartYear = 2019

            }
                );

            mockownerrepo.Setup(repo => repo.ReadAll()).Returns(mockowners);
            mockownerrepo.Setup(repo => repo.Read(It.IsAny<int>())).Returns(owner);
        }

        /// <summary>
        /// Testing the Create() method.
        /// </summary>
        [Test]
        public void OwnerCreateTest()
        {
            ml.CreateOwners(new Owners()
            {
                Owner_Id = 4,
                Name = "Nagy Margareta",
                City = "Miskolc",
                HasPaidThisYear = true,
                IsReplaceable = true,
                StartYear = 2010
            });

            mockownerrepo.Verify(v => v.Create(It.IsAny<Owners>()));
        }

        /// <summary>
        /// Testing the Delete() method with an object.
        /// </summary>
        [Test]
        public void OwnerDeleteTestObj()
        {
            ml.DeleteOwners(new Owners()
            {
                Owner_Id = 1,
                Name = "Kiss Gyozo",
                City = "Budapest",
                HasPaidThisYear = true,
                IsReplaceable = false,
                StartYear = 2018
            });

            mockownerrepo.Verify(v => v.Delete(It.IsAny<Owners>()));
        }

        /// <summary>
        /// Testing the Delete() methid with an int.
        /// </summary>
        [Test]
        public void OwnerDeleteTestInt()
        {
            ml.DeleteOwners(1);
            mockownerrepo.Verify(v => v.Delete(It.IsAny<int>()));
        }

        /// <summary>
        /// Testing the Update() method.
        /// </summary>
        [Test]
        public void OwnerUpdateTest()
        {
            ml.UpdateOwners(new Owners()
            {
                Owner_Id = 2,
                Name = "Telepes Katalin",
                City = "Szentendre",
                HasPaidThisYear = true,
                IsReplaceable = true,
                StartYear = 2013
            });

            mockownerrepo.Verify(v => v.Update(It.IsAny<Owners>()));
        }

        /// <summary>
        /// Testing the ReadAll() method.
        /// </summary>
        [Test]
        public void OwnerReadAllTest()
        {
            var testTemp = ml.ReadAllOwners();
            Assert.NotNull(testTemp);
        }

        /// <summary>
        /// Testing the Read() method.
        /// </summary>
        [Test]
        public void OwnerReadTest()
        {
            var testTemp = ml.ReadOwners(2);
            Assert.NotNull(testTemp);
        }
    }
}
