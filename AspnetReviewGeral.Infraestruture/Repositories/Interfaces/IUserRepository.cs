using System.Collections.Generic;
using AspnetReviewGeral.Domain;

namespace AspnetReviewGeral.Infraestruture.Repositories.Interfaces
{
    interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        void Remove(int userId);
        void RemoveRange(IEnumerable<User> users);

    }
}
