using System.Collections.Generic;
using AspnetReviewGeral.Domain;

namespace AspnetReviewGeral.Infraestruture.Repositories.Interfaces
{
    interface INatRepository
    {
        void Add(Nat nat);
        void Update(Nat nat);
        void Remove(int natId);
        void RemoveRange(IList<Nat> nats);
    }
}
