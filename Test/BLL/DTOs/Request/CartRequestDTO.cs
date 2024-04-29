using System.ComponentModel.DataAnnotations;

namespace Test.BLL.DTOs.Request
{
    public class CartRequestDTO
    {
        public int CustomerId { get; set; }
        public int CakeId { get; set; }

        public int Quantity { get; set; }
    }
}
