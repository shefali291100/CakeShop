using System;
using System.Collections.Generic;

namespace Test.DAL.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public double TotalAmount { get; set; }
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderStatus { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual Customer User { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
