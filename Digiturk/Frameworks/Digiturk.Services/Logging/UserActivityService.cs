using Digiturk.Core;
using Digiturk.Core.Data;
using Digiturk.Core.Domain.Logging;
using Digiturk.Core.Domain.Catalog;
using Digiturk.Data;
using Digiturk.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Services.Logging
{
    public class UserActivityService : IUserActivityService
    {

        #region Fields

        private readonly IRepository<ActivityLog> _activityLogRepository;
        private readonly IRepository<ActivityLogType> _activityLogTypeRepository;
        private readonly IDbContext _dbContext;

        #endregion

        #region Ctor

        public UserActivityService(IRepository<ActivityLog> activityLogRepository,
            IRepository<ActivityLogType> activityLogTypeRepository,
            IDbContext dbContext)
        {
            _activityLogRepository = activityLogRepository;
            _activityLogTypeRepository = activityLogTypeRepository;
            _dbContext = dbContext;
        }

        #endregion

        #region Nested classes

        [Serializable]
        public class ActivityLogTypeForCaching
        {
            public int Id { get; set; }
            public string SystemKeyword { get; set; }
            public string Name { get; set; }
            public bool Enabled { get; set; }
        }

        #endregion

        #region Methods

        public void InsertActivityType(ActivityLogType activityLogType)
        {
            if (activityLogType == null)
                throw new ArgumentNullException(nameof(activityLogType));

            _activityLogTypeRepository.Insert(activityLogType);
        }

        public void UpdateActivityType(ActivityLogType activityLogType)
        {
            if (activityLogType == null)
                throw new ArgumentNullException(nameof(activityLogType));

            _activityLogTypeRepository.Update(activityLogType);
        }

        public void DeleteActivityType(ActivityLogType activityLogType)
        {
            if (activityLogType == null)
                throw new ArgumentNullException(nameof(activityLogType));

            _activityLogTypeRepository.Delete(activityLogType);
        }

        public IList<ActivityLogType> GetAllActivityTypes()
        {
            var query = from alt in _activityLogTypeRepository.Table
                        orderby alt.Name
                        select alt;
            var activityLogTypes = query.ToList();
            return activityLogTypes;
        }

        public ActivityLogType GetActivityTypeById(int activityLogTypeId)
        {
            if (activityLogTypeId == 0)
                return null;

            return _activityLogTypeRepository.GetById(activityLogTypeId);
        }

        public ActivityLog InsertActivity(User user, string systemKeyword, string comment, BaseEntity entity = null)
        {
            if (user == null)
                return null;

            var activityLogType = GetAllActivityTypes().FirstOrDefault(type => type.SystemKeyword.Equals(systemKeyword));
            if (!activityLogType?.Enabled ?? true)
                return null;

            var logItem = new ActivityLog
            {
                ActivityLogTypeId = activityLogType.Id,
                EntityId = entity?.Id,
                EntityName = entity?.GetUnproxiedEntityType().Name,
                UserId = user.Id,
                Comment = CommonHelper.EnsureMaximumLength(comment ?? string.Empty, 4000),
                CreatedOnUtc = DateTime.UtcNow,
                IpAddress = "get ip address"
            };
            _activityLogRepository.Insert(logItem);

            return logItem;
        }

        public void DeleteActivity(ActivityLog activityLog)
        {
            if (activityLog == null)
                throw new ArgumentNullException(nameof(activityLog));

            _activityLogRepository.Delete(activityLog);
        }

        public IPagedList<ActivityLog> GetAllActivities(DateTime? createdOnFrom = null, DateTime? createdOnTo = null,
            int? userId = null, int? activityLogTypeId = null, string ipAddress = null, string entityName = null, int? entityId = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _activityLogRepository.Table;

            if (!string.IsNullOrEmpty(ipAddress))
                query = query.Where(logItem => logItem.IpAddress.Contains(ipAddress));

            if (createdOnFrom.HasValue)
                query = query.Where(logItem => createdOnFrom.Value <= logItem.CreatedOnUtc);
            if (createdOnTo.HasValue)
                query = query.Where(logItem => createdOnTo.Value >= logItem.CreatedOnUtc);

            if (activityLogTypeId.HasValue && activityLogTypeId.Value > 0)
                query = query.Where(logItem => activityLogTypeId == logItem.ActivityLogTypeId);

            if (userId.HasValue && userId.Value > 0)
                query = query.Where(logItem => userId.Value == logItem.UserId);

            if (!string.IsNullOrEmpty(entityName))
                query = query.Where(logItem => logItem.EntityName.Equals(entityName));
            if (entityId.HasValue && entityId.Value > 0)
                query = query.Where(logItem => entityId.Value == logItem.EntityId);

            query = query.OrderByDescending(logItem => logItem.CreatedOnUtc).ThenBy(logItem => logItem.Id);

            return new PagedList<ActivityLog>(query, pageIndex, pageSize);
        }

        public ActivityLog GetActivityById(int activityLogId)
        {
            if (activityLogId == 0)
                return null;

            return _activityLogRepository.GetById(activityLogId);
        }

        public void ClearAllActivities()
        {
            var activityLogTableName = _dbContext.GetTableName<ActivityLog>();
            _dbContext.ExecuteSqlCommand($"TRUNCATE TABLE [{activityLogTableName}]");

        }

        #endregion
    }
}