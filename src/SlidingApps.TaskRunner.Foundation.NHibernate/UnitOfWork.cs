
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Transaction;
using NHibernate;
using System;
using System.Transactions;

namespace SlidingApps.TaskRunner.Foundation.NHibernate
{
    public sealed class UnitOfWork
        : IUnitOfWork
    {
        private readonly ISession session;

        /// <summary>
        /// TRUE if the object is disposed, FALSE otherwise.
        /// </summary>
        private bool isDisposed = false;

        public UnitOfWork(ISession session)
        {
			this.session = session;
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~UnitOfWork()
        {
            this.Dispose(false);
        }

        public void Start(Action action, string correlationId, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            Argument.InstanceIsRequired(action, "action");

            System.Data.IsolationLevel _isolationLevel = System.Data.IsolationLevel.Unspecified;
            switch (isolationLevel)
            {
                case IsolationLevel.Serializable:
                    _isolationLevel = System.Data.IsolationLevel.Serializable;
                    break;
                case IsolationLevel.RepeatableRead:
                    _isolationLevel = System.Data.IsolationLevel.RepeatableRead;
                    break;
                case IsolationLevel.ReadCommitted:
                    _isolationLevel = System.Data.IsolationLevel.ReadCommitted;
                    break;
                case IsolationLevel.ReadUncommitted:
                    _isolationLevel = System.Data.IsolationLevel.ReadUncommitted;
                    break;
                case IsolationLevel.Snapshot:
                    _isolationLevel = System.Data.IsolationLevel.Snapshot;
                    break;
                case IsolationLevel.Chaos:
                    _isolationLevel = System.Data.IsolationLevel.Chaos;
                    break;
            }

            correlationId = string.IsNullOrEmpty(correlationId) ? "__UNSPECIFIED__" : correlationId;

            Logger.Log.InfoFormat(Logger.CORRELATED_MESSAGE, correlationId, "starting transaction");
            using (var transaction = session.BeginTransaction(_isolationLevel))
            {
                Logger.Log.InfoFormat(Logger.CORRELATED_MESSAGE, correlationId, "transaction started");

                Logger.Log.InfoFormat(Logger.CORRELATED_MESSAGE, correlationId, "invoking action");
                action.Invoke();

                Logger.Log.DebugFormat(Logger.CORRELATED_MESSAGE, correlationId, "action invoked");

                Logger.Log.InfoFormat(Logger.CORRELATED_MESSAGE, correlationId, "completing transaction");
                transaction.Commit();

                Logger.Log.DebugFormat(Logger.CORRELATED_MESSAGE, correlationId, "completed transaction");
            }
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region - Private & protected methods -

        /// <summary>
        /// Disposes managed and unmanaged resources.
        /// </summary>
        /// <param name="isDisposing">Flag indicating how this protected method was called. 
        /// TRUE means via Dispose(), FALSE means via the destructor.
        /// Only in case of a call through the Dispose() method should managed resources be freed.</param>
        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Free managed resources here
            }

            if (!this.isDisposed)
            {

            }

            this.isDisposed = true;
        }

        #endregion
    }
}
