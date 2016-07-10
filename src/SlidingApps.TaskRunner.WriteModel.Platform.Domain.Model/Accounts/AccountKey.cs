
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts
{
    public class AccountKey 
        : IBusinessKey
    {
        public AccountKey(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public static AccountKey Empty
        {
            get { return new AccountKey(string.Empty); }
        }
    }
}
