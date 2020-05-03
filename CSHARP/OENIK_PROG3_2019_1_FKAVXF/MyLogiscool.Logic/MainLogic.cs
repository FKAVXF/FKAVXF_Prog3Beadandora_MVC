// <copyright file="MainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLogiscool.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MyLogiscool.Data;
    using MyLogiscool.Repository;

    /// <summary>
    /// Business Logic.
    /// </summary>
    public class MainLogic : ILogic
    {
        /// <summary>
        /// SchoolsRepository.
        /// </summary>
        private IRepository<Schools> schoolsRepository;

        /// <summary>
        /// OwnersRepository.
        /// </summary>
        private IRepository<Owners> ownersRepository;

        /// <summary>
        /// TeacherRepository.
        /// </summary>
        private IRepository<Teachers> teachersRepository;

        /// <summary>
        /// ConnectionsRepository.
        /// </summary>
        private IRepository<OwnerSchoolConnector> connectionsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainLogic"/> class.
        /// 1. constructor that only needs schoolsRepository so this class is reusable.
        /// </summary>
        /// <param name="schoolsRepository">The SchoolRepository.</param>
        public MainLogic(IRepository<Schools> schoolsRepository)
        {
            this.schoolsRepository = schoolsRepository;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainLogic"/> class.
        /// 2. constructor that only needs ownersRepository so this class is reusable.
        /// </summary>
        /// <param name="ownersRepository">The OwnersRepository.</param>
        public MainLogic(IRepository<Owners> ownersRepository)
        {
            this.ownersRepository = ownersRepository;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainLogic"/> class.
        /// 3. constructor that only needs teachersRepository so this class is reusable.
        /// </summary>
        /// <param name="teachersRepository">The TeachersRepository.</param>
        public MainLogic(IRepository<Teachers> teachersRepository)
        {
            this.teachersRepository = teachersRepository;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainLogic"/> class.
        /// 4. constructor that only needs connectionsRepository so this class is reusable.
        /// </summary>
        /// <param name="connectionsRepository">The ConnectionsRepository.</param>
        public MainLogic(IRepository<OwnerSchoolConnector> connectionsRepository)
        {
            this.connectionsRepository = connectionsRepository;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainLogic"/> class.
        /// 5. constructor that needs all of the repository so this class is reusable.
        /// </summary>
        /// <param name="schoolsRepository">The SchoolRepository.</param>
        /// <param name="ownersRepository">The OwnersRepository.</param>
        /// <param name="teachersRepository">The TeachersRepository.</param>
        /// <param name="connectionsRepository">The ConnectionsRepository.</param>
        public MainLogic(IRepository<Schools> schoolsRepository, IRepository<Owners> ownersRepository, IRepository<Teachers> teachersRepository, IRepository<OwnerSchoolConnector> connectionsRepository)
        {
            this.schoolsRepository = schoolsRepository;
            this.ownersRepository = ownersRepository;
            this.teachersRepository = teachersRepository;
            this.connectionsRepository = connectionsRepository;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainLogic"/> class.
        /// 6. constructor that need none of the repository so this class is reusable.
        /// </summary>
        public MainLogic()
        {
            this.schoolsRepository = new SchoolRepository();
            this.ownersRepository = new OwnerRepository();
            this.teachersRepository = new TeacherRepository();
            this.connectionsRepository = new ConnectionRepository();
        }

        // Teachers CRUD

        /// <summary>
        /// Calls the Create() method of TeacherRepsitory.
        /// </summary>
        /// <param name="obj">Teachers Type entity that we want to create.</param>
        public void CreateTeachers(Teachers obj)
        {
            this.teachersRepository.Create(obj);
        }

        /// <summary>
        /// Calls the Delete() method of TeacherRepsitory.
        /// </summary>
        /// <param name="id">The ID of the entity that we want to delete.</param>
        public void DeleteTeachers(int id)
        {
            this.teachersRepository.Delete(id);
        }

        /// <summary>
        /// Calls the Delete() method of TeacherRepsitory.
        /// </summary>
        /// <param name="obj">The entity that we want to delete.</param>
        public void DeleteTeachers(Teachers obj)
        {
            this.teachersRepository.Delete(obj);
        }

        /// <summary>
        /// Calls the ReadAll() method of TeacherRepository.
        /// </summary>
        /// <returns>All data from the database as queryable.</returns>
        public IEnumerable<Teachers> ReadAllTeachers()
        {
            return this.teachersRepository.ReadAll();
        }

        /// <summary>
        /// Calls the Read() method of TeacherRepository.
        /// </summary>
        /// <param name="id">The records id that we're looking for.</param>
        /// <returns>The Type Teachers data that we're searching by id.</returns>
        public Teachers ReadTeachers(int id)
        {
            return this.teachersRepository.Read(id);
        }

        /// <summary>
        /// Calls the Update() method of TeacherRepsitory.
        /// </summary>
        /// <param name="obj">Teachers Type entity that we want to update.</param>
        public void UpdateTeachers(Teachers obj)
        {
            this.teachersRepository.Update(obj);
        }

        // Owners CRUD

        /// <summary>
        /// Calls the Create() method of OwnerRepository.
        /// </summary>
        /// <param name="obj">Owners Type entity that we want to create.</param>
        public void CreateOwners(Owners obj)
        {
            this.ownersRepository.Create(obj);
        }

        /// <summary>
        /// Calls the Delete() method of OwnerRepository.
        /// </summary>
        /// <param name="id">The ID of the entity that we want to delete.</param>
        public void DeleteOwners(int id)
        {
            this.ownersRepository.Delete(id);
        }

        /// <summary>
        /// Calls the Delete() method of OwnerRepository.
        /// </summary>
        /// <param name="obj">The entity that we want to delete.</param>
        public void DeleteOwners(Owners obj)
        {
            this.ownersRepository.Delete(obj);
        }

        /// <summary>
        /// Calls the ReadAll() method of OwnerRepository.
        /// </summary>
        /// <returns>All data from the database as queryable.</returns>
        public IEnumerable<Owners> ReadAllOwners()
        {
            return this.ownersRepository.ReadAll();
        }

        /// <summary>
        /// Calls the Read() method of OwnerRepository.
        /// </summary>
        /// <param name="id">The records id that we're looking for.</param>
        /// <returns>The Type Owners data that we're searching by id.</returns>
        public Owners ReadOwners(int id)
        {
            return this.ownersRepository.Read(id);
        }

        /// <summary>
        /// Calls the Update() method of OwnerRepository.
        /// </summary>
        /// <param name="obj">Owners Type entity that we want to update.</param>
        public void UpdateOwners(Owners obj)
        {
            this.ownersRepository.Update(obj);
        }

        // Schools CRUD

        /// <summary>
        /// Calls the Create() method of SchoolRepository.
        /// </summary>
        /// <param name="obj">Schools Type entity that we want to create.</param>
        public void CreateSchools(Schools obj)
        {
            this.schoolsRepository.Create(obj);
        }

        /// <summary>
        /// Calls the Delete() method of SchoolRepsitory.
        /// </summary>
        /// <param name="id">The ID of the entity that we want to delete.</param>
        public void DeleteSchools(int id)
        {
            this.schoolsRepository.Delete(id);
        }

        /// <summary>
        /// Calls the Delete() method of SchoolRepsitory.
        /// </summary>
        /// <param name="obj">The entity that we want to delete.</param>
        public void DeleteSchools(Schools obj)
        {
            this.schoolsRepository.Delete(obj);
        }

        /// <summary>
        /// Calls the ReadAll() method of SchoolRepository.
        /// </summary>
        /// <returns>All data from the database as queryable.</returns>
        public IEnumerable<Schools> ReadAllSchools()
        {
            return this.schoolsRepository.ReadAll();
        }

        /// <summary>
        /// Calls the Read() method of SchoolRepository.
        /// </summary>
        /// <param name="id">The records id that we're looking for.</param>
        /// <returns>The Type Schools data that we're searching by id.</returns>
        public Schools ReadSchools(int id)
        {
            return this.schoolsRepository.Read(id);
        }

        /// <summary>
        /// Calls the Update() method of SchoolRepository.
        /// </summary>
        /// <param name="obj">Schools Type entity that we want to update.</param>
        public void UpdateSchools(Schools obj)
        {
            this.schoolsRepository.Update(obj);
        }

        // Connection CRUD

        /// <summary>
        /// Calls the Create() method of ConnectionRepository.
        /// </summary>
        /// <param name="obj">OwnerSchoolConnector Type entity that we want to create.</param>
        public void CreateConnection(OwnerSchoolConnector obj)
        {
            this.connectionsRepository.Create(obj);
        }

        /// <summary>
        /// Calls the Delete() method of ConnectionRepsitory.
        /// </summary>
        /// <param name="id">The ID of the entity that we want to delete.</param>
        public void DeleteConnection(int id)
        {
            this.connectionsRepository.Delete(id);
        }

        /// <summary>
        /// Calls the Delete() method of ConnectionRepsitory.
        /// </summary>
        /// <param name="obj">The entity that we want to delete.</param>
        public void DeleteConnection(OwnerSchoolConnector obj)
        {
            this.connectionsRepository.Delete(obj);
        }

        /// <summary>
        /// Calls the ReadAll() method of ConnectionRepository.
        /// </summary>
        /// <returns>All data from the database as queryable.</returns>
        public IEnumerable<OwnerSchoolConnector> ReadAllConnection()
        {
            return this.connectionsRepository.ReadAll();
        }

        /// <summary>
        /// Calls the Read() method of ConnectionRepository.
        /// </summary>
        /// <param name="id">The records id that we're looking for.</param>
        /// <returns>The Type Schools data that we're searching by id.</returns>
        public OwnerSchoolConnector ReadConnection(int id)
        {
            return this.connectionsRepository.Read(id);
        }

        /// <summary>
        /// Calls the Update() method of Connection Repository.
        /// </summary>
        /// <param name="obj">Connection Type entity that we want to update.</param>
        public void UpdateConnection(OwnerSchoolConnector obj)
        {
            this.connectionsRepository.Update(obj);
        }

        // Not CRUD

        /// <summary>
        /// Gives us back the owners who are living in the same city as one of their schools in.
        /// </summary>
        /// <returns>The owners who are living in the same city as one of their schools in.</returns>
        public IEnumerable<Owners> OwnerLivesInCityWhereSchoolIs()
        {
            var ownerTable = this.ownersRepository.ReadAll();
            var connectionTable = this.connectionsRepository.ReadAll();
            var schoolTable = this.schoolsRepository.ReadAll();

            var returnList = from x in ownerTable
                             join y in connectionTable on x.Owner_Id equals y.Owner_Id
                             join z in schoolTable on y.School_Id equals z.School_Id
                             where x.City == z.City
                             select x;
            return returnList;
        }

        /// <summary>
        /// Gives us back the owner who applies the most teachers.
        /// </summary>
        /// <returns> The owner who applies the most teachers.</returns>
        public Owners OwnerWithMostTeachers()
        {
            var teacherTable = this.teachersRepository.ReadAll();
            var schoolTable = this.schoolsRepository.ReadAll();
            var connectionTable = this.connectionsRepository.ReadAll();
            var ownerTable = this.ownersRepository.ReadAll();

            var joinTemp1 = from x in ownerTable
                           join y in connectionTable on x.Owner_Id equals y.Owner_Id
                           join z in teacherTable on y.School_Id equals z.School_Id
                           select new
                            {
                               Owner_Id = x.Owner_Id,
                               Teacher = z.Teacher_Id,
                            };
            var joinTemp2 = from x in joinTemp1
                            group x by x.Owner_Id into z
                            select new
                            {
                                Owner_Id = z.Key,
                                NumberOfTeacher = z.Count(t =>t.Teacher > 0),
                            };
            var joinTemp3 = from x in joinTemp2
                            orderby x.NumberOfTeacher descending
                            select x;

            var returnOwner = ownerTable.Where(t => t.Owner_Id == joinTemp3.ElementAt(0).Owner_Id).FirstOrDefault();
            return returnOwner;
        }

        /// <summary>
        /// Gives us back the teachers who are working in Hungary.
        /// </summary>
        /// <returns>The teachers who are working in Hungary.</returns>
        public IEnumerable<Teachers> HungarianTeachers()
        {
            var teacherTable = this.teachersRepository.ReadAll();
            var schoolTable = this.schoolsRepository.ReadAll();
            var query2 = from x in teacherTable
                         join y in schoolTable on x.School_Id equals y.School_Id
                         where y.Country == "Hungary"
                         select x;
            return query2;
        }
    }
}
