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
    /// Tests for the mainLogic's teacher part.
    /// </summary>
    internal class TeacherLogicTests
    {
        /// <summary>
        /// Mocked TeacherRepo.
        /// </summary>
        Mock<IRepository<Teachers>> mockteacherrepo;
        /// <summary>
        /// Business Logic.
        /// </summary>
        MainLogic ml;

        /// <summary>
        /// Setting up the mocked elements of the owner databese.
        /// </summary>
        [SetUp]
        public void InitTeacher()
        {
            mockteacherrepo = new Mock<IRepository<Teachers>>();
            ml = new MainLogic(mockteacherrepo.Object);

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
                HealthCare = "statefunded"
            }
                );
            mockteachers.Add(new Teachers()
            {
                Teacher_Id = 3,
                School_Id = 2,
                Name = "Farkas Judit",
                Salary = 1600,
                StartYear = 2017,
                WellLiked = true,
                CourseNumber = 65,
                HealthCare = "fucked"
            }
                );

            mockteacherrepo.Setup(repo => repo.ReadAll()).Returns(mockteachers);
            mockteacherrepo.Setup(repo => repo.Read(It.IsAny<int>())).Returns(teacher);
        }

        /// <summary>
        /// Testing the Create() method.
        /// </summary>
        [Test]
        public void TeacherCreateTest()
        {
            ml.CreateTeachers(new Teachers()
            {
                Teacher_Id = 4,
                School_Id = 2,
                Name = "Lakatos Franciska",
                Salary = 600,
                StartYear = 2019,
                WellLiked = true,
                CourseNumber = 25,
                HealthCare = "fucked"
            });

            mockteacherrepo.Verify(v => v.Create(It.IsAny<Teachers>()));
        }

        /// <summary>
        /// Testing the Delete() method with an object.
        /// </summary>
        [Test]
        public void TeacherDeleteTestObj()
        {
            ml.DeleteTeachers(new Teachers()
            {
                Teacher_Id = 3,
                School_Id = 2,
                Name = "Farkas Judit",
                Salary = 1600,
                StartYear = 2017,
                WellLiked = true,
                CourseNumber = 65,
                HealthCare = "fucked"
            });

            mockteacherrepo.Verify(v => v.Delete(It.IsAny<Teachers>()));
        }

        /// <summary>
        /// Testing the Delete() methid with an int.
        /// </summary>
        [Test]
        public void TeacherDeleteTestInt()
        {
            ml.DeleteTeachers(1);
            mockteacherrepo.Verify(v => v.Delete(It.IsAny<int>()));
        }

        /// <summary>
        /// Testing the Update() method.
        /// </summary>
        [Test]
        public void TeacherUpdateTest()
        {
            ml.UpdateTeachers(new Teachers()
            {
                Teacher_Id = 3,
                School_Id = 2,
                Name = "Farkas Judit",
                Salary = 1800,
                StartYear = 2012,
                WellLiked = false,
                CourseNumber = 65,
                HealthCare = "statefunded"
            });

            mockteacherrepo.Verify(v => v.Update(It.IsAny<Teachers>()));
        }

        /// <summary>
        /// Testing the ReadAll() method.
        /// </summary>
        [Test]
        public void TeacherReadAllTest()
        {
            var testTemp = ml.ReadAllTeachers();
            Assert.NotNull(testTemp);
        }

        /// <summary>
        /// Testing the Read() method.
        /// </summary>
        [Test]
        public void TeacherReadTest()
        {
            var testTemp = ml.ReadTeachers(2);
            Assert.NotNull(testTemp);
        }
    }
}
