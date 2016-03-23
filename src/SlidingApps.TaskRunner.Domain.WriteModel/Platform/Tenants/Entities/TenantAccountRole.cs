﻿
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Entities
{
    public class TenantAccountRole
        : AuditableDataEntity<Guid>
    {
        public TenantAccountRole()
        : base() { }

        public TenantAccountRole(Guid id)
        : base(id) { }

        public virtual bool IsOwner { get; set; }

        public virtual bool IsAdmin { get; set; }

        public virtual bool IsMember { get; set; }

        public virtual bool IsFollower { get; set; }

        public virtual DateTime ValidFrom { get; set; }

        public virtual TenantAccount TenantAccount { get; set; }
    }
}
