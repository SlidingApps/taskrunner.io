
using Autofac;
using MassTransit;

namespace SlidingApps.TaskRunner.Api.CommandBus.Host
{
    internal sealed class MassTransitConfig
    {
        internal static IBusControl Configure(IContainer container)
        {
            IBusControl busControl = container.Resolve<IBusControl>();
            return busControl;
        }
    }
}
