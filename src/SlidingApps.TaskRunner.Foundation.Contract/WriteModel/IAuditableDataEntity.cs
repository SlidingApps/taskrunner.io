
using System;

namespace SlidingApps.TaskRunner.Foundation.WriteModel
{
    public interface IAuditableDataEntity
    {
        string _Modifier { get; set; }

        DateTime _Timestamp { get; set; }

        int _Version { get; set; }
    }
}