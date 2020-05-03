// <copyright file="ConnectionRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLogiscool.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MyLogiscool.Data;

    /// <summary>
    /// The repository of the Connections.
    /// </summary>
    public class ConnectionRepository : IRepository<OwnerSchoolConnector>
    {
        /// <summary>
        /// Declaring the Business Logic.
        /// </summary>
        private MyLogiscoolDatabaseEntities db = new MyLogiscoolDatabaseEntities();
        /// <summary>
        /// Creates an entity in Connections.
        /// </summary>
        /// <param name="obj">Connection Type entity that we want to create.</param>
        public void Create(OwnerSchoolConnector obj)
        {
            this.db.OwnerSchoolConnector.Add(obj);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Deletes an entity in Connections.
        /// </summary>
        /// <param name="id">The ID of the entity that we want to delete.</param>
        public void Delete(int id)
        {
            this.db.OwnerSchoolConnector.Remove(this.Read(id));
            this.db.SaveChanges();
        }

        /// <summary>
        /// Deletes an entity in Connections.
        /// </summary>
        /// <param name="obj">The entity that we want to delete.</param>
        public void Delete(OwnerSchoolConnector obj)
        {
            this.db.OwnerSchoolConnector.Remove(obj);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Gives back the entity by id from the database.
        /// </summary>
        /// <param name="id">The id of the entity that we are interested in.</param>
        /// <returns>The entity that we are interested in.</returns>
        public OwnerSchoolConnector Read(int id)
        {
            return this.db.OwnerSchoolConnector.First(t => t.Connection_Id == id);
        }

        /// <summary>
        /// Gives back all data from the database.
        /// </summary>
        /// <returns>All data from the database as queryable.</returns>
        public IEnumerable<OwnerSchoolConnector> ReadAll()
        {
            return this.db.OwnerSchoolConnector.AsQueryable();
        }

        /// <summary>
        /// Updates the given entity.
        /// </summary>
        /// <param name="obj">The entity that we want to update.</param>
        public void Update(OwnerSchoolConnector obj)
        {
            var toUpdate = this.db.OwnerSchoolConnector.First(t => t.Connection_Id == obj.Owner_Id);
            if (toUpdate != null)
            {
                this.db.Entry(toUpdate).CurrentValues.SetValues(obj);
                this.db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not found.");
            }
        }
    }
}
