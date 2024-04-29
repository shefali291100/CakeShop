using System.ComponentModel.DataAnnotations;

namespace Test.BLL.DTOs.Request
{
    public class AddressRequestDTO
    {
        public int CustomerId { get; set; }

        [StringLength(100)]
        public string City { get; set; } = null!;

        [StringLength(50)]
        public string State { get; set; } = null!;

        [StringLength(6)]
        public string Pincode { get; set; } = null!;

        [StringLength(300)]
        public string StreetAddress { get; set; } = null!;

        [StringLength(50)]
        public string Landmark { get; set; } = null!;
    }
}
