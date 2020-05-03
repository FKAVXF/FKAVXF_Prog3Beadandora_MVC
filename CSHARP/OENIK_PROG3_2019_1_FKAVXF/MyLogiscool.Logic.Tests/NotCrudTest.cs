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
    class NotCrudTest
    {
        Mock<IRepository<OwnerSchoolConnector>> mockconnectionrepo;
        Mock<IRepository<Owners>> mockownerrepo;
        Mock<IRepository<Schools>> mockschoolrepo;
        Mock<IRepository<Teachers>> mockteacherrepo;
        MainLogic ml;

        /// <summary>
        /// Setting up the mocked elements of the owner databese.
        /// </summary>
        [SetUp]
        public void InitNotCrud()
        {
            mockconnectionrepo = new Mock<IRepository<OwnerSchoolConnector>>();
            mockownerrepo = new Mock<IRepository<Owners>>();
            mockschoolrepo = new Mock<IRepository<Schools>>();
            mockteacherrepo = new Mock<IRepository<Teachers>>();
            ml = new MainLogic(mockschoolrepo.Object, mockownerrepo.Object, mockteacherrepo.Object, mockconnectionrepo.Object);

            List<OwnerSchoolConnector> mockconnections = new List<OwnerSchoolConnector>();
            var connection = new OwnerSchoolConnector()
            {
                Connection_Id = 1,
                Owner_Id = 1,
                School_Id = 1
            };
            mockconnections.Add(new OwnerSchoolConnector()
            {
                Connection_Id = 1,
                Owner_Id = 1,
                School_Id = 1

            }
                );
            mockconnections.Add(new OwnerSchoolConnector()
            {
                Connection_Id = 2,
                Owner_Id = 1,
                School_Id = 2

            }
                );
            mockconnections.Add(new OwnerSchoolConnector()
            {
                Connection_Id = 3,
                Owner_Id = 2,
                School_Id = 3

            }
                );
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
            var school = new Schools
            {
                School_Id = 1,
                City = "Budapest",
                ZipCode = 1031,
                Address = "Kolompar utca 8",
                Country = "Hungary",
                NumberOfChildren = 10
            };
            List<Schools> mockschools = new List<Schools>();
            mockschools.Add(new Schools()
            {
                School_Id = 1,
                City = "Budapest",
                ZipCode = 1031,
                Address = "Kolompar utca 8",
                Country = "Hungary",
                NumberOfChildren = 10
            }
                );
            mockschools.Add(new Schools()
            {
                School_Id = 2,
                City = "Wien",
                ZipCode = 1056,
                Address = "HeidrichStraße 5",
                Country = "Austria",
                NumberOfChildren = 13

            }
                );
            mockschools.Add(new Schools()
            {
                School_Id = 3,
                City = "Mos Espa",
                ZipCode = 8000,
                Address = "DalaiLama street 1",
                Country = "Tibet",
                NumberOfChildren = 2

            }
                );
            List<Teachers> mockteachers = new List<Teachers>();
            var teacher = new Teachers
            {
                Teacher_Id = 1,
                School_Id = 6,
                Name = "Gondy Szergely",
                Salary = 10,
                StartYear = 2019,
                WellLiked = false,
                CourseNumber = 5,
                HealthCare = "statefunded"
            };

            mockteachers.Add(new Teachers()
            {
                Teacher_Id = 1,
                School_Id = 6,
                Name = "Gondy Szergely",
                Salary = 10,
                StartYear = 2019,
                WellLiked = false,
                CourseNumber = 5,
                HealthCare = "statefunded"
            }
                );
            mockteachers.Add(new Teachers()
            {
                Teacher_Id = 2,
                School_Id = 1,
                Name = "Farpad Prozo",
                Salary = 1000,
                StartYear = 2010,
                WellLiked = true,
                CourseNumber = 15,
                HealthCare = "statefunded",
            });
            mockteachers.Add(new Teachers()
            {
                Teacher_Id = 3,
                School_Id = 2,
                Name = "Farkas Judit",
                Salary = 1600,
                StartYear = 2017,
                WellLiked = true,
                CourseNumber = 65,
                HealthCare = "fucked",
            });
            mockconnectionrepo.Setup(repo => repo.ReadAll()).Returns(mockconnections);
            mockownerrepo.Setup(repo => repo.ReadAll()).Returns(mockowners);
            mockschoolrepo.Setup(repo => repo.ReadAll()).Returns(mockschools);
            mockteacherrepo.Setup(repo => repo.ReadAll()).Returns(mockteachers);
        }

        /// <summary>
        /// Testing HungarianTeachers().
        /// </summary>
        [Test]
        public void HungarianTeacherTest()
        {
            var temp = ml.HungarianTeachers();
            Assert.NotNull(temp);
        }

        /// <summary>
        /// Testing OwnerWithMostSchoolsTest().
        /// </summary>
        [Test]
        public void OwnerWithMostSchoolsTest()
        {
            var temp = ml.OwnerWithMostTeachers();
            Assert.NotNull(temp);
        }

        /// <summary>
        /// OwnerInSameCityAsSchool().
        /// </summary>
        [Test]
        public void OwnerInSameCityAsSchool()
        {
            var temp = ml.OwnerLivesInCityWhereSchoolIs();
            Assert.NotNull(temp);
        }
    }
}
