using System.ComponentModel.DataAnnotations;

namespace Test.BLL.DTOs.Request
{
    public class OrderDetailRequestDTO
    {
        public int OrderId { get; set; }
        public int CakeId { get; set; }
        public int Quantity { get; set; }

        [Range(1, 1000)]
        public double Price { get; set; }
    }
}
