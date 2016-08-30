using System;

namespace AspnetReviewGeral.Domain
{
    public class Nat
    {
        public Guid Id { get; set; }
        public string NatText { get; set; }
        public DateTime DateCreated { get; set; }
        public User User { get; set; }
    }
}
