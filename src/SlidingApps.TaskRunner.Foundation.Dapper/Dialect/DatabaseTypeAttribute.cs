
using System;

namespace SlidingApps.TaskRunner.Foundation.Dapper.Dialect
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class DatabaseTypeAttribute
        : Attribute
    {
        public DatabaseTypeAttribute(string databaseType)
        {
            this.DatabaseType = databaseType;
        }

        public string DatabaseType { get; set; }
    }
}
