﻿
using Newtonsoft.Json;
using SlidingApps.TaskRunner.Foundation.ReadModel;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Tenants.Representations
{
    public sealed class Tenant
        : DataRepresentation
    {
        private const string SELF_LINK_TEMPLATE = "/tenants/{tenantId}";

        private Tenant()
        {
            this.templates.Add(new SelfLinkTemplate(Tenant.SELF_LINK_TEMPLATE));
        }

        [JsonIgnore]
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
