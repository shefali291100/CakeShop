using System;
using System.Collections.Generic;

namespace Test.DAL.Entities
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CakeId { get; set; }
        public int Quantity { get; set; }

        public virtual Cake Cake { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}
