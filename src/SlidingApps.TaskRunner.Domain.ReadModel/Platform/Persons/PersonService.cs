
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Queries;
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Dapper;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Persons
{
    public class PersonService : 
        IQueryHandler<PersonCollectionQuery, PersonCollection>,
        IQueryHandler<PersonQuery, Person>
    {
        private readonly IQueryProvider queryProvider;

        public PersonService(IQueryProvider queryProvider)
        {
            this.queryProvider = queryProvider;
        }

        public PersonCollection Handle(PersonCollectionQuery query)
        {
            var _query = this.queryProvider.From<Person>().By(x => x.OrganizationId).EqualTo(query.OrganizationId);

            // Add 'like' criterium.
            if (!string.IsNullOrEmpty(query.Name))
            {
                _query.By(x => x.DisplayName).Like(query.Name);
            }

            _query.OrderBy(x => x.DisplayName).Limit(query.Page, query.PageSize);

            var persons = _query.ToList();
            var collection = new PersonCollection(persons, query.Page, query.PageSize);

            return collection;
        }

        public Person Handle(PersonQuery query)
        {
            var person =
                this.queryProvider.From<Person>()
                    .By(x => x.OrganizationId).EqualTo(query.OrganizationId)
                    .By(x => x.Id).EqualTo(query.PersonId)
                    .SingleOrDefault();

            return person;
        }
    }
}
