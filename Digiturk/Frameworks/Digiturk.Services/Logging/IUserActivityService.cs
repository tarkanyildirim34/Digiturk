using Digiturk.Core;
using Digiturk.Core.Domain.Logging;
using Digiturk.Core.Domain.Catalog;
using System;
using System.Collections.Generic;

namespace App.Services.Logging
{
    public interface IUserActivityService
    {
        void InsertActivityType(ActivityLogType activityLogType);

        void UpdateActivityType(ActivityLogType activityLogType);

        void DeleteActivityType(ActivityLogType activityLogType);

        IList<ActivityLogType> GetAllActivityTypes();

        ActivityLogType GetActivityTypeById(int activityLogTypeId);

        ActivityLog InsertActivity(User user, string systemKeyword, string comment, BaseEntity entity = null);

        void DeleteActivity(ActivityLog activityLog);

        IPagedList<ActivityLog> GetAllActivities(DateTime? createdOnFrom = null, DateTime? createdOnTo = null,
            int? userId = null, int? activityLogTypeId = null, string ipAddress = null, string entityName = null, int? entityId = null,
            int pageIndex = 0, int pageSize = int.MaxValue);

        ActivityLog GetActivityById(int activityLogId);

        void ClearAllActivities();
    }
}