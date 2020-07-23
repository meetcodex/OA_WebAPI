using Microsoft.EntityFrameworkCore;
using OA_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA_Repository
{
    /// <summary>
    /// Represents the Entity Framework repository
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region Field
        private readonly ApplicationContext _context;
        private readonly DbSet<T> entities;
        #endregion

        #region Ctor
        public Repository(ApplicationContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }
        #endregion

        #region Utilities

        /// <summary>
        /// Rollback of entity changes and return full error message
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>Error message</returns>
        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            //rollback entity changes
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException)
                    {
                        // ignored
                    }
                });
            }

            try
            {
                _context.SaveChanges();
                return exception.ToString();
            }
            catch (Exception ex)
            {
                //if after the rollback of changes the context is still not saving,
                //return the full text of the exception that occurred when saving
                return ex.ToString();
            }
        }

        #endregion


        #region Method

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                entities.Add(entity);
                _context.SaveChanges();
            }
            catch(DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
             
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
            
        }

        /// <summary>
        /// Get entity by Id
        /// </summary>
        /// <param name="Id">Identity</param>
        public T Get(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException("Id is 0 or null");
            try
            {
                return entities.FirstOrDefault(x => x.Id == Id);
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
            
        }

        /// <summary>
        /// Get All entity
        /// </summary>
        public IEnumerable<T> GetAll()
        {
            try
            {
                return entities.AsEnumerable();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }   
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                entities.Update(entity);
                _context.SaveChanges();
            }
            catch(DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }

        }

        #endregion
    }
}
