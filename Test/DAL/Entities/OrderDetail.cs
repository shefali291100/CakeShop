using System;
using System.Collections.Generic;

namespace Test.DAL.Entities
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CakeId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public virtual Cake Cake { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
