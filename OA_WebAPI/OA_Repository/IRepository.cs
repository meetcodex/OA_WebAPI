using OA_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Repository
{
    /// <summary>
    /// Represents an entity repository
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets all entity
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets entity by Id
        /// <param name="Id">entity identifier</param>
        /// </summary>
        T Get(int Id);

        /// <summary>
        /// Add entity
        /// <param name="entity">Entity</param>
        /// </summary>
        void Add(T entity);

        /// <summary>
        /// Update entity
        /// <param name="entity">Entity</param>
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Delete entity
        /// <param name="entity">Entity</param>
        /// </summary>
        void Delete(T entity);

    }
}
