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
    /// Tests for the mainLogic's school part.
    /// </summary>
    internal class SchoolLogicTest
    {

        /// <summary>
        /// Mocked SchoolRepo.
        /// </summary>
        Mock<IRepository<Schools>> mockschoolrepo;
        
        /// <summary>
        /// Business Logic.
        /// </summary>
        MainLogic ml;

        /// <summary>
        /// Setting up the mocked elements of the owner databese.
        /// </summary>
        [SetUp]
        public void InitSchool()
        {
            mockschoolrepo = new Mock<IRepository<Schools>>();
            ml = new MainLogic(mockschoolrepo.Object);
            var school = new Schools
            {
                School_Id = 1,
                City = "Budapest",
                ZipCode = 1031,
                Address = "Kolompar utca 8",
                Country = "Magyarorszag",
                NumberOfChildren = 10
            };
            List<Schools> mockschools = new List<Schools>();
            mockschools.Add(new Schools()
            {
                School_Id = 1,
                City = "Budapest",
                ZipCode = 1031,
                Address = "Kolompar utca 8",
                Country = "Magyarorszag",
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

            mockschoolrepo.Setup(repo => repo.ReadAll()).Returns(mockschools);
            mockschoolrepo.Setup(repo => repo.Read(It.IsAny<int>())).Returns(school);
        }

        /// <summary>
        /// Testing the Create() method.
        /// </summary>
        [Test]
        public void SchoolCreateTest()
        {
            ml.CreateSchools(new Schools()
            {
                School_Id = 4,
                City = "El Salvador",
                ZipCode = 8300,
                Address = "Gun street 3",
                Country = "San Salvador",
                NumberOfChildren = 30
            });

            mockschoolrepo.Verify(v => v.Create(It.IsAny<Schools>()));
        }

        /// <summary>
        /// Testing the Delete() method with an object.
        /// </summary>
        [Test]
        public void SchoolDeleteTestObj()
        {
            ml.DeleteSchools(new Schools()
            {
                School_Id = 3,
                City = "Mos Espa",
                ZipCode = 8000,
                Address = "DalaiLama street 1",
                Country = "Tibet",
                NumberOfChildren = 2
            });

            mockschoolrepo.Verify(v => v.Delete(It.IsAny<Schools>()));
        }

        /// <summary>
        /// Testing the Delete() methid with an int.
        /// </summary>
        [Test]
        public void SchoolDeleteTestInt()
        {
            ml.DeleteSchools(1);
            mockschoolrepo.Verify(v => v.Delete(It.IsAny<int>()));
        }

        /// <summary>
        /// Testing the Update() method.
        /// </summary>
        [Test]
        public void SchoolUpdateTest()
        {
            ml.UpdateSchools(new Schools()
            {
                School_Id = 3,
                City = "Mos Espa",
                ZipCode = 8100,
                Address = "DalaiLama street 13",
                Country = "Tibet",
                NumberOfChildren = 2
            });

            mockschoolrepo.Verify(v => v.Update(It.IsAny<Schools>()));
        }

        /// <summary>
        /// Testing the ReadAll() method.
        /// </summary>
        [Test]
        public void SchoolReadAllTest()
        {
            var testTemp = ml.ReadAllSchools();
            Assert.NotNull(testTemp);
        }

        /// <summary>
        /// Testing the Read() method.
        /// </summary>
        [Test]
        public void SchoolReadTest()
        {
            var testTemp = ml.ReadSchools(2);
            Assert.NotNull(testTemp);
        }
    }
}
