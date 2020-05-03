// <copyright file="OwnerRepository.cs" company="PlaceholderCompany">
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
    /// The repository of the Owners.
    /// </summary>
    public class OwnerRepository : IRepository<Owners>
    {
        /// <summary>
        /// Declaring the Business Logic.
        /// </summary>
        private MyLogiscoolDatabaseEntities db = new MyLogiscoolDatabaseEntities();

        /// <summary>
        /// Creates an entity in Owners.
        /// </summary>
        /// <param name="obj">Owners Type entity that we want to create.</param>
        public void Create(Owners obj)
        {
            this.db.Owners.Add(obj);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Deletes an entity in Owners.
        /// </summary>
        /// <param name="id">The ID of the entity that we want to delete.</param>
        public void Delete(int id)
        {
            this.db.Owners.Remove(this.Read(id));
            this.db.SaveChanges();
        }

        /// <summary>
        /// Deletes an entity in Owners.
        /// </summary>
        /// <param name="obj">The entity that we want to delete.</param>
        public void Delete(Owners obj)
        {
            this.db.Owners.Remove(obj);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Gives back the entity by id from the database.
        /// </summary>
        /// <param name="id">The id of the entity that we are interested in.</param>
        /// <returns>The entity that we are interested in.</returns>
        public Owners Read(int id)
        {
            return this.db.Owners.First(t => t.Owner_Id == id);
        }

        /// <summary>
        /// Gives back all data from the database.
        /// </summary>
        /// <returns> All data from the database as queryable.</returns>
        public IEnumerable<Owners> ReadAll()
        {
            return this.db.Owners.AsQueryable();
        }

        /// <summary>
        /// Updates the given entity.
        /// </summary>
        /// <param name="obj">The entity that we want to update.</param>
        public void Update(Owners obj)
        {
            var toUpdate = this.db.Owners.First(t => t.Owner_Id == obj.Owner_Id);
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
