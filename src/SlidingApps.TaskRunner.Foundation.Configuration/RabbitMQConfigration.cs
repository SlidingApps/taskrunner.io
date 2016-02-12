
using System;

namespace SlidingApps.TaskRunner.Foundation.Configuration
{
    public class RabbitMQConfigration
    {
        public const string DEFAULT_VIRTUAL_HOST_URI_FORMAT = "rabbitmq://{0}/{1}";

        public const string DEFAULT_EXCHANGE_URI_FORMAT = "rabbitmq://{0}/{1}/{2}";

        private readonly IApplicationConfigurationStore configuration;

        public RabbitMQConfigration(IApplicationConfigurationStore configuration)
        {
            this.configuration = configuration;
        }

        public Uri VirtualHostUri
        {
            get
            {
                string address = this.configuration[AppSetting.RABBITMQ_ADDRESS];
                string virtualHost = this.configuration[AppSetting.RABBITMQ_VIRTUAL_HOST];

                return new Uri(string.Format(RabbitMQConfigration.DEFAULT_VIRTUAL_HOST_URI_FORMAT, address, virtualHost));
            }
        }

        public Uri CommandExchangeUri
        {
            get
            {
                string address = this.configuration[AppSetting.RABBITMQ_ADDRESS];
                string virtualHost = this.configuration[AppSetting.RABBITMQ_VIRTUAL_HOST];
                string exchange = this.configuration[AppSetting.RABBITMQ_EXCHANGE_COMMAND];

                return new Uri(string.Format(RabbitMQConfigration.DEFAULT_EXCHANGE_URI_FORMAT, address, virtualHost, exchange));
            }
        }

        public Uri EventExchangeUri
        {
            get
            {
                string address = this.configuration[AppSetting.RABBITMQ_ADDRESS];
                string virtualHost = this.configuration[AppSetting.RABBITMQ_VIRTUAL_HOST];
                string exchange = this.configuration[AppSetting.RABBITMQ_EXCHANGE_EVENT];

                return new Uri(string.Format(RabbitMQConfigration.DEFAULT_EXCHANGE_URI_FORMAT, address, virtualHost, exchange));
            }
        }
    }
}
