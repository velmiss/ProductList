using System.ComponentModel.DataAnnotations;

namespace ProductDTOClass
{
    public class ProductDTO
    {

        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        
        [Range(0, int.MaxValue)]
        public int AmountInStock { get; set; }
        [Required]
        public string Distributor { get; set; }
    }
}