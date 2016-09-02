﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspnetReviewGeral.Domain;
using AspnetReviewGeral.Infraestruture.Repositories.Interfaces;

namespace AspnetReviewGeral.Infraestruture.Repositories
{
    public class NatRepository : RepositoryBase<Nat>, INatRepository
    {
        public override async void Add(Nat nat)
        {
            base.Add(nat);
            await SaveChangesAsync();
        }

        public override async void Update(Nat nat)
        {
            base.Update(nat);
            await SaveChangesAsync();
        }

        public async void Remove(int natId)
        {
            if (base.Remove(natId))
            {
                await SaveChangesAsync();
            }
        }

        public async void RemoveRange(IEnumerable<Nat> nats)
        {
            if (base.RemoveRange(nats))
            {
                await SaveChangesAsync();
            }
        }
    }
}
