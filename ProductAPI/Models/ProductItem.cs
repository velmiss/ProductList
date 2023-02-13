using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class ProductItem
    {
        /*
        20. The ‘thing’ is Product. (The database can be ‘primed’ when deployed.)
        The information shall be: name (string, may not be empty), type (one string, may not be empty),
        AmountInStock (int, not settable to negative numbers ), distributor (string, may be empty).
        */
    
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public int AmountInStock { get; set; }
        [Required]
        public string Distributor { get; set; }



    }
}
