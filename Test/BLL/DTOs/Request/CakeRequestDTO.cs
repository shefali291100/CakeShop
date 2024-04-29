using System.ComponentModel.DataAnnotations;

namespace Test.BLL.DTOs.Request
{
    public class CakeRequestDTO
    {
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Range(1, double.MaxValue)]
        public double Price { get; set; }

        [StringLength(2000)]
        public string Description { get; set; } = null!;

        public string? ImageURL { get; set; }
    }
}
