﻿
using SlidingApps.TaskRunner.Foundation.Configuration;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Domain
{
    public static class Metadata
    {
        public static string SCHEMA_NAME = ApplicationConfiguration.Store[AppSetting.NHIBERNATE_SCHEMA] ?? string.Empty;
    }
}
