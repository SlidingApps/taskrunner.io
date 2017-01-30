
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons
{
    public class PersonKey 
        : IBusinessKey
    {
        public PersonKey(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public static PersonKey Empty
        {
            get { return new PersonKey(string.Empty); }
        }
    }
}
