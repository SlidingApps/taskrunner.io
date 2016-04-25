﻿
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Authorization.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Authorization.Queries
{
    public class AccountValidityQuery
        : IQuery<AccountValidity>
    {
        public AccountValidityQuery(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
