
using SlidingApps.TaskRunner.Foundation.Configuration;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain
{
    public static class Constant
    {
        public static readonly string PASSWORD_ENCRYPTION_KEY = ApplicationConfiguration.Store["encryption.password.key"];

        public static readonly string PASSWORD_ENCRYPTION_INIT_VECTOR = ApplicationConfiguration.Store["encryption.password.initvector"];

        public const string PASSWORD_SALTING_TEMPLATE = "{1}{0}{1}";

        public static readonly DateTime DEFAULT_START_DATE = new DateTime(1900, 01, 01);

        public static readonly DateTime DEFAULT_END_DATE = new DateTime(9999, 01, 01);
    }
}
