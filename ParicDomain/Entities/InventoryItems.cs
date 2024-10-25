using System.ComponentModel.DataAnnotations;

namespace ParicDomain.Entities
{
	public class InventoryItems
	{
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        [MinLength(50)]
		public string Description { get; set; } = default!;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal TotalPrice { get; set; }
    }
}
