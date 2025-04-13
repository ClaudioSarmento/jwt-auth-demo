using JwtApi.Model;
using JwtApi.Repositories.Interfaces;
using Raven.Client.Documents;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace JwtApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDocumentStore _documentStore;
        public UserRepository(IDocumentStore documentStore) 
        {
            _documentStore = documentStore;
        }
        public void Add(User user)
        {
            using var documentSession = _documentStore.OpenSession();
            documentSession.Store(user);
            documentSession.SaveChanges();
        }

        public User? GetByUserName(string userName)
        {
            using var documentSession = _documentStore.OpenSession();
            var user = documentSession.Query<User>()
                .FirstOrDefault(c => c.UserName == userName);
            return user;
        }
    }
}
