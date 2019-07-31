using System;
using Digiturk.Core;

namespace Digiturk.Data.Extensions
{
    public static class EntityExtensions
    {
        private static bool IsProxy(this BaseEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var type = entity.GetType();
            return type.BaseType != null && type.BaseType.BaseType != null && type.BaseType.BaseType == typeof(BaseEntity);
        }

        public static Type GetUnproxiedEntityType(this BaseEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Type type = null;

            if (entity.IsProxy())
                type = entity.GetType().BaseType;
            else
                type = entity.GetType();

            if (type == null)
                throw new Exception("Original entity type cannot be loaded");

            return type;
        }
    }
}
