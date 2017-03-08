
using ImpromptuInterface;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Dapper;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Queries;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Representations;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons
{
    public class PersonService : 
        IQueryHandler<PersonCollectionQuery, PersonCollection>,
        IQueryHandler<PersonQuery, Person>,
        IQueryHandler<LinkDecryptionQuery, DecryptedLink>
    {
        private readonly IQueryProvider queryProvider;

        public PersonService(IQueryProvider queryProvider)
        {
            this.queryProvider = queryProvider;
        }

        public PersonCollection Handle(PersonCollectionQuery query)
        {
            var _query = this.queryProvider.From<Person>();

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
            var personCriteria = this.queryProvider.From<Person>().By(x => x.EmailAddress).EqualTo(query.Username);
            var userCriteria = this.queryProvider.From<Person>().By(x => x.UserName).EqualTo(query.Username);

            var person =
                this.queryProvider.From<Person>()
                    .Or(personCriteria, userCriteria)
                    .SingleOrDefault<Person>();

            return person;
        }

        public DecryptedLink Handle(LinkDecryptionQuery query)
        {
            var decoded =
                query.Link
                .FromBase58()
                .FromBytes()
                .Decrypt(EncryptionConfiguration.SymmetricKey, EncryptionConfiguration.SymmetricInitVector)
                .FromJson<object>()
                .ActLike<IAuthorizationLink>();

            var account =
                this.queryProvider.From<PersonProfile>()
                    .By(x => x.Link).EqualTo(decoded.link)
                    .SingleOrDefault();

            if (account == null)
            {
                throw new NotAuthorizedException("Invalid or expired link");
            }
            else if(account != null && account.Status.ToEnum<EntityStatus>() != EntityStatus.CONFIRMED)
            {
                throw new UnconfirmedAccountException("Unconfirmed account");
            }

            return new DecryptedLink(decoded.username, decoded.link);
        }
    }
}
