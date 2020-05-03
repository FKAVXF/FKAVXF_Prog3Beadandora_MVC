// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLogiscool.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that contains the required methods for the repository classes.
    /// </summary>
    /// <typeparam name="T">Generic Type.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gives back all the data from the database.
        /// </summary>
        /// <returns>All data from database.</returns>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// Gives back the entity by id from the database.
        /// </summary>
        /// <param name="id">The records id that we're looking for.</param>
        /// <returns>The Type T data that we're searching by id.</returns>
        T Read(int id);

        /// <summary>
        /// Creates an entity in the database.
        /// </summary>
        /// <param name="obj">Type T object that we want to create in the database.</param>
        void Create(T obj);

        /// <summary>
        /// Deletes an entity in the database.
        /// </summary>
        /// <param name="obj">The entity that we want to delete.</param>
        void Delete(T obj);

        /// <summary>
        /// Deletes an entity in the database.
        /// </summary>
        /// <param name="id">The ID of the entity that we want to delete.</param>
        void Delete(int id);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="obj">The entity that we want to update.</param>
        void Update(T obj);

    }
}
