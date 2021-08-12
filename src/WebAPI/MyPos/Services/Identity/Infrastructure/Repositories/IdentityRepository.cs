using Identity.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Infrastructure.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly IdentityContext _identityContext;

        public IdentityRepository(IdentityContext identityContext)
        {
            _identityContext = identityContext;
        }

        public async Task<Credentials> GetUserAsync(string userName)
        {
            return _identityContext.Credentials.FirstOrDefault(x => x.UserName.Trim() == userName.Trim());
        }

        public async Task PersistUserAsync(Credentials user)
        {
            _identityContext.Credentials.Add(user);
            await _identityContext.SaveChangesAsync();
        }
    }

    public interface IIdentityRepository
    {
        Task<Credentials> GetUserAsync(string userName);

        Task PersistUserAsync(Credentials user);
    }
}