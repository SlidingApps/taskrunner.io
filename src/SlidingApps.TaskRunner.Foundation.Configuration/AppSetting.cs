
using System;

namespace SlidingApps.TaskRunner.Foundation.Configuration
{
    public static class AppSetting
    {
        //<add key = "site.address" value="localhost" />
        //<add key = "site.port" value="8080" />

        public const string SITE_BASE_URI_TEMPLATE = "http://{0}:{1}";

        public const string SITE_ADDRESS = "site.address";

        public const string SITE_PORT = "site.port";


        //<add key = "host.address" value="localhost" />
        //<add key = "host.port" value="8081" />

        private const string HOST_BASE_URI_TEMPLATE = "http://{0}:{1}";

        public const string HOST_ADDRESS = "host.address";

        public const string HOST_PORT = "host.port";


        //<add key = "hal.urlBase" value="http://dev.SlidingApps.TaskRunner.io/api" />

        public const string HAL_URL_BASE = "hal.urlBase";


        //<add key = "dapper.provider" value="MySql.Data.MySqlClient" />
        //<add key = "dapper.connectionstring" value="Server=xxx;Database=xxx;Uid=xxx;Pwd=xxx;" />

        public const string DAPPER_DEFAULT_PROVIDER = "dapper.default.provider";

        public const string DAPPER_DEFAULT_CONNECTIONSTRING = "dapper.default.connectionstring";

        public const string DAPPER_SCHEMA_REDIRECT_TEMPLATE = "dapper.schema.{0}.redirect";

        public const string DAPPER_SCHEMA_PROVIDER_TEMPLATE = "dapper.schema.{0}.provider";

        public const string DAPPER_SCHEMA_CONNECTIONSTRING_TEMPLATE = "dapper.schema.{0}.connectionstring";


        //<add key = "nhibernate.dialect" value="MySql" />
        //<add key = "nhibernate.connectionstring" value="Server=xxx;Database=HomeAutomation_DEV;Uid=xxx;Pwd=xxx;" />
        //<add key = "nhibernate.mappingAssembly" value="SlidingApps.TaskRunner.Domain.ReadModel" />

        public const string NHIBERNATE_DIALECT = "nhibernate.dialect";

        public const string NHIBERNATE_CONNECTIONSTRING = "nhibernate.connectionstring";

        public const string NHIBERNATE_MAPPING_ASSEMBLY = "nhibernate.mappingAssembly";

        public const string NHIBERNATE_SCHEMA = "nhibernate.schema";


        //<add key = "rabbitmq.address" value="localhost" />
        //<add key = "rabbitmq.virtualHost" value="xxx" />
        //<add key = "rabbitmq.exchange.command" value="Command" />
        //<add key = "rabbitmq.exchange.domainEvent" value="DomainEvent" />
        //<add key = "rabbitmq.queue.command" value="Command" />
        //<add key = "rabbitmq.user" value="xxx" />
        //<add key = "rabbitmq.password" value="xxx" />
        //<add key = "rabbitmq.durable" value="true" />

        public const string RABBITMQ_ADDRESS = "rabbitmq.address";

        public const string RABBITMQ_VIRTUAL_HOST = "rabbitmq.virtualHost";

        public const string RABBITMQ_EXCHANGE_COMMAND = "rabbitmq.exchange.command";

        public const string RABBITMQ_EXCHANGE_EVENT = "rabbitmq.exchange.domainEvent";

        public const string RABBITMQ_QUEUE_COMMAND = "rabbitmq.queue.command";

        public const string RABBITMQ_USER = "rabbitmq.user";

        public const string RABBITMQ_PASSWORD = "rabbitmq.password";

        public const string RABBITMQ_DURABLE_QUEUE = "rabbitmq.durable";

        //<add key = "service.xxx.url" value="http://localhost:8091" />
        public const string SERVICE_URL_TEMPLATE = "service.{0}.url";


        //<add key = "service.mail.domain" value="taskrunner.io"/>
        public const string MAIL_SERVICE_DOMAIN = "service.mail.domain";

        //<add key = "service.mail.noReply" value="TaskRunner &lt;no-reply@taskrunner.io&gt;"/>
        public const string MAIL_SERVICE_NO_REPLY_ADDRESS = "service.mail.noReply";

        //<add key = "service.mail.sandboxAddress" value="devy@somedomain.com"/>
        public const string MAIL_SERVICE_SANDBOX_ADDRESS = "service.mail.sandboxAddress";
    }
}
