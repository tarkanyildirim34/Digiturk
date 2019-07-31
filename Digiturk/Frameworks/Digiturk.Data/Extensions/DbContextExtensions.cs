using Digiturk.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Digiturk.Data.Extensions
{
    public static class DbContextExtensions
    {
        #region Fields

        private static string databaseName;
        private static readonly ConcurrentDictionary<string, string> tableNames = new ConcurrentDictionary<string, string>();

        #endregion

        public static string GetTableName<TEntity>(this IDbContext context) where TEntity : BaseEntity
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            //try to get the EF database context
            if (!(context is DbContext dbContext))
                throw new InvalidOperationException("Context does not support operation");

            var entityTypeFullName = typeof(TEntity).FullName;
            if (!tableNames.ContainsKey(entityTypeFullName))
            {
                //get entity type
                var entityType = dbContext.Model.FindRuntimeEntityType(typeof(TEntity));

                //get the name of the table to which the entity type is mapped
                tableNames.TryAdd(entityTypeFullName, entityType.Relational().TableName);
            }

            tableNames.TryGetValue(entityTypeFullName, out var tableName);

            return tableName;
        }
    }
}
