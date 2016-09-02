using System.Collections.Generic;
using AspnetReviewGeral.Domain;
using AspnetReviewGeral.Infraestruture.Repositories.Interfaces;

namespace AspnetReviewGeral.Infraestruture.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public override async void Add(User user)
        {
            base.Add(user);
            await SaveChangesAsync();
        }

        public override async void Update(User user)
        {
            base.Update(user);
            await SaveChangesAsync();
        }

        public async void Remove(int userId)
        {
            if (base.Remove(userId))
            {
                await SaveChangesAsync();
            }
        }

        public async void RemoveRange(IList<User> users)
        {
            if (base.RemoveRange(users))
            {
                await SaveChangesAsync();
            }
        }

    }
}
