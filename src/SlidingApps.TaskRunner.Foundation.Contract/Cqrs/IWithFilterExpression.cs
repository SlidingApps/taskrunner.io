
using SlidingApps.TaskRunner.Foundation.WriteModel;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    public interface IWithFilterExpression<TDataEntity>
        where TDataEntity: IDataEntity
    {
        [JsonIgnore]
        Expression<Func<TDataEntity, bool>> FilterExpression { get; }
    }
}
