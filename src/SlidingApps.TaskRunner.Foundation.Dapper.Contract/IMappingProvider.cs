
using System;
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.Foundation.Dapper
{
    public interface IMappingProvider
    {
        TableMapping GetMapping<TEntity>();

        void BuildMapping();
    }
}
