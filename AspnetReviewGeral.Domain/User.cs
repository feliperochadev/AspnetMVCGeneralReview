using System;
using System.Collections.Generic;

namespace AspnetReviewGeral.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string ScreenName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string EmailAddress { get; set; }
        public string Bio { get; set; }
        public IList<Nat> Nats { get; set; }
        public IList<User> Users { get; set; } 
    }
}
