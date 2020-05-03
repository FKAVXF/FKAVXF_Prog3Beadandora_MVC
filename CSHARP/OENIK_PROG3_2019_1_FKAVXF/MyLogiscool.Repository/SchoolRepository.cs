// <copyright file="SchoolRepository.cs" company="PlaceholderCompany">
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
    /// The repository of the Schools.
    /// </summary>
    public class SchoolRepository : IRepository<Schools>
    {
        /// <summary>
        /// Declaring the Business Logic.
        /// </summary>
        private MyLogiscoolDatabaseEntities db = new MyLogiscoolDatabaseEntities();

        /// <summary>
        /// Creates an entity in Schools.
        /// </summary>
        /// <param name="obj">Schools Type entity that we want to create.</param>
        public void Create(Schools obj)
        {
            this.db.Schools.Add(obj);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Deletes an entity in Schools.
        /// </summary>
        /// <param name="id">The ID of the entity that we want to delete.</param>
        public void Delete(int id)
        {
            this.db.Schools.Remove(this.Read(id));
            this.db.SaveChanges();
        }

        /// <summary>
        /// Deletes an entity in Owners.
        /// </summary>
        /// <param name="obj">The entity that we want to delete.</param>
        public void Delete(Schools obj)
        {
            this.db.Schools.Remove(obj);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Gives back the entity by id from the database.
        /// </summary>
        /// <param name="id">The id of the entity that we are interested in.</param>
        /// <returns>The entity that we are interested in.</returns>
        public Schools Read(int id)
        {
            return this.db.Schools.First(t => t.School_Id == id);
        }

        /// <summary>
        /// Gives back all data from the database.
        /// </summary>
        /// <returns>All data from the database as queryable.</returns>
        public IEnumerable<Schools> ReadAll()
        {
            return this.db.Schools.AsQueryable();
        }

        /// <summary>
        /// Updates the given entity.
        /// </summary>
        /// <param name="obj">The entity that we want to update.</param>
        public void Update(Schools obj)
        {
            var toUpdate = this.db.Owners.First(t => t.Owner_Id == obj.School_Id);
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
