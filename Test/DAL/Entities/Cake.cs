using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.DAL.Entities
{
    public partial class Cake
    {
        public Cake()
        {
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;

        [StringLength(300)]
        public string? ImageURL { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
