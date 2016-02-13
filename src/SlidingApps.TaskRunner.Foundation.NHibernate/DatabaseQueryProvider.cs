
using SlidingApps.TaskRunner.Foundation.NHibernate.Contract;
using NHibernate;

namespace SlidingApps.TaskRunner.Foundation.NHibernate
{
    /// <summary>
    /// NHibernate specific implementation of <see cref="QueryProvider{TSession}"/>.
    /// </summary>
    public sealed class DatabaseQueryProvider
        : QueryProvider<ISession>
    {
        public DatabaseQueryProvider(ISession session) 
            : base(session) { }
    }
}
