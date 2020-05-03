// <copyright file="TeacherRepository.cs" company="PlaceholderCompany">
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
    /// The repository of the Teachers.
    /// </summary>
    public class TeacherRepository : IRepository<Teachers>
    {
        /// <summary>
        /// Declaring the Business Logic.
        /// </summary>
        private MyLogiscoolDatabaseEntities db = new MyLogiscoolDatabaseEntities();

        /// <summary>
        /// Creates an entity in Teachers.
        /// </summary>
        /// <param name="obj">Schools Type entity that we want to create.</param>
        public void Create(Teachers obj)
        {
            this.db.Teachers.Add(obj);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Deletes an entity in Teachers.
        /// </summary>
        /// <param name="id">The ID of the entity that we want to delete.</param>
        public void Delete(int id)
        {
            this.db.Teachers.Remove(this.Read(id));
            this.db.SaveChanges();
        }

        /// <summary>
        /// Deletes an entity in Teachers.
        /// </summary>
        /// <param name="obj">The entity that we want to delete.</param>
        public void Delete(Teachers obj)
        {
            this.db.Teachers.Remove(obj);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Gives back the entity by id from the database.
        /// </summary>
        /// <param name="id">The id of the entity that we are interested in.</param>
        /// <returns>The entity that we are interested in.</returns>
        public Teachers Read(int id)
        {
            return this.db.Teachers.First(t => t.Teacher_Id == id);
        }

        /// <summary>
        /// Gives back all data from the database.
        /// </summary>
        /// <returns>All data from the database as queryable.</returns>
        public IEnumerable<Teachers> ReadAll()
        {
            return this.db.Teachers.AsQueryable();
        }

        /// <summary>
        /// Updates the given entity.
        /// </summary>
        /// <param name="obj">The entity that we want to update.</param>
        public void Update(Teachers obj)
        {
            var toUpdate = this.db.Teachers.First(t => t.Teacher_Id == obj.Teacher_Id);
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
