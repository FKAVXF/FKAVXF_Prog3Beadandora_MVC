// <copyright file="ILogic.cs" company="PlaceholderCompany">
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
    /// Interface that contains the required methods for the Business Logic class.
    /// </summary>
    public interface ILogic
    {
        // Schools CRUD

        /// <summary>
        /// Calls the ReadAll() method of SchoolRepository.
        /// </summary>
        /// <returns>All data from the database as queryable.</returns>
        IEnumerable<Schools> ReadAllSchools();

        /// <summary>
        /// Calls the Delete() method of SchoolRepsitory.
        /// </summary>
        /// <param name="obj">The entity that we want to delete.</param>
        void DeleteSchools(Schools obj);

        /// <summary>
        /// Calls the Delete() method of SchoolRepsitory.
        /// </summary>
        /// <param name="id">The ID of the entity that we want to delete.</param>
        void DeleteSchools(int id);

        /// <summary>
        /// Calls the Create() method of SchoolRepository.
        /// </summary>
        /// <param name="obj">Schools Type entity that we want to create.</param>
        void CreateSchools(Schools obj);

        /// <summary>
        /// Calls the Update() method of SchoolRepository.
        /// </summary>
        /// <param name="obj">Schools Type entity that we want to update.</param>
        void UpdateSchools(Schools obj);

        /// <summary>
        /// Calls the Read() method of SchoolRepository.
        /// </summary>
        /// <param name="id">The records id that we're looking for.</param>
        /// <returns>The Type Schools data that we're searching by id.</returns>
        Schools ReadSchools(int id);

        // Owners CRUD

        /// <summary>
        /// Calls the ReadAll() method of OwnerRepository.
        /// </summary>
        /// <returns>All data from the database as queryable.</returns>
        IEnumerable<Owners> ReadAllOwners();

        /// <summary>
        /// Calls the Delete() method of OwnerRepository.
        /// </summary>
        /// <param name="obj">The entity that we want to delete.</param>
        void DeleteOwners(Owners obj);

        /// <summary>
        /// Calls the Delete() method of OwnerRepository.
        /// </summary>
        /// <param name="id">The ID of the entity that we want to delete.</param>
        void DeleteOwners(int id);

        /// <summary>
        /// Calls the Create() method of OwnerRepository.
        /// </summary>
        /// <param name="obj">Owners Type entity that we want to create.</param>
        void CreateOwners(Owners obj);

        /// <summary>
        /// Calls the Update() method of OwnerRepository.
        /// </summary>
        /// <param name="obj">Owners Type entity that we want to update.</param>
        void UpdateOwners(Owners obj);

        /// <summary>
        /// Calls the Read() method of OwnerRepository.
        /// </summary>
        /// <param name="id">The records id that we're looking for.</param>
        /// <returns>The Type Owners data that we're searching by id.</returns>
        Owners ReadOwners(int id);

        // Teachers CRUD

        /// <summary>
        /// Calls the ReadAll() method of TeacherRepository.
        /// </summary>
        /// <returns>All data from the database as queryable.</returns>
        IEnumerable<Teachers> ReadAllTeachers();

        /// <summary>
        /// Calls the Delete() method of TeacherRepsitory.
        /// </summary>
        /// <param name="obj">The entity that we want to delete.</param>
        void DeleteTeachers(Teachers obj);

        /// <summary>
        /// Calls the Delete() method of TeacherRepsitory.
        /// </summary>
        /// <param name="id">The ID of the entity that we want to delete.</param>
        void DeleteTeachers(int id);

        /// <summary>
        /// Calls the Create() method of TeacherRepsitory.
        /// </summary>
        /// <param name="obj">Teachers Type entity that we want to create.</param>
        void CreateTeachers(Teachers obj);

        /// <summary>
        /// Calls the Update() method of TeacherRepsitory.
        /// </summary>
        /// <param name="obj">Teachers Type entity that we want to update.</param>
        void UpdateTeachers(Teachers obj);

        /// <summary>
        /// Calls the Read() method of TeacherRepository.
        /// </summary>
        /// <param name="id">The records id that we're looking for.</param>
        /// <returns>The Type Teachers data that we're searching by id.</returns>
        Teachers ReadTeachers(int id);

        // Not CRUD

        /// <summary>
        /// Gives us back the owner who applies the most teachers.
        /// </summary>
        /// <returns> The owner who applies the most teachers.</returns>
        Owners OwnerWithMostTeachers();

        /// <summary>
        /// Gives us back the owners who are living in the same city as one of their schools in.
        /// </summary>
        /// <returns>The owners who are living in the same city as one of their schools in.</returns>
        IEnumerable<Owners> OwnerLivesInCityWhereSchoolIs();

        /// <summary>
        /// Gives us back the teachers who are working in Hungary.
        /// </summary>
        /// <returns>The teachers who are working in Hungary.</returns>
        IEnumerable<Teachers> HungarianTeachers();
    }
}
