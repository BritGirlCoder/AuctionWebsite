using AuctionWebsite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AuctionWebsite.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        /// <summary>
        /// Generic query method
        /// </summary>
        //Return type is an IQueryable, where T is a class (e.g. Movie or Book)
        public IQueryable<T> Query<T>() where T : class
        {
            return _db.Set<T>().AsQueryable();
        }


        /// <summary>
        /// Non Generic query method
        /// Use model type name instead of model type
        /// </summary>
        public IQueryable Query(string entityTypeName)
        {
            var entityType = Type.GetType(entityTypeName);
            return _db.Set(entityType).AsQueryable();
        }

        /// <summary>
        /// Find row by id
        /// </summary>

        public T Find<T>(params object[] keyValues) where T : class
        {
            return _db.Set<T>().Find(keyValues);
        }

        /// <summary>
        /// Add new entity
        /// </summary>
        public void Add<T>(T entityToCreate) where T : class
        {
            _db.Set<T>().Add(entityToCreate);
        }

        public void Delete<T>(params object[] keyValues) where T : class
        {
            var entity = this.Find<T>(keyValues);
            _db.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Save changes and throw validation exceptions
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException dbVal)
            {
                var firstError = dbVal.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                throw new ValidationException(firstError);
            }
        }

        /// <summary>
        /// Execute stored procedures and dynamic sql
        /// </summary>
        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
        {
            return this._db.Database.SqlQuery<T>(sql, parameters);
        }
        public void Dispose()
        {
            _db.Dispose();
        }

    }

    /// <summary>
    /// This class promotes the Include() method from the entity framework so it
    /// can be used at a higher layer. You might not want to reference in the Entity Framework
    /// in your presentation layer.
    /// </summary>
    public static class GenericRepositoryExtensions
    {
        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> queryable, Expression<Func<T, TProperty>> relatedEntity) where T : class
        {
            return System.Data.Entity.QueryableExtensions.Include<T, TProperty>(queryable, relatedEntity);
        }
    }
    public interface IGenericRepository : IDisposable
    {
        System.Linq.IQueryable<T> Query<T>() where T : class;
        System.Linq.IQueryable Query(string entityTypeName);
        void Add<T>(T entityToCreate) where T : class;
        T Find<T>(params object[] keyValues) where T : class;
        void Delete<T>(params object[] keyValues) where T : class;
        void SaveChanges();
        System.Collections.Generic.IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters);
    }
}