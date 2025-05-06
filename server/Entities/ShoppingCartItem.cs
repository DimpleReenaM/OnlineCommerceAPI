using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace server.Entities
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public int CreatedBy { get; set; }
        //public int ModifiedBy { get; set; }
        //public bool IsDeleted { get; set; }
        [JsonIgnore]
        public  ShoppingCart ShoppingCart { get; set; }
        public  Product Product { get; set; }

        public decimal TotalPriceAfterDiscount
        {
            get
            {
                return Product.NewPrice * Quantity;
            }
        }

        public decimal TotalDiscount
        {
            get
            {
                return (Product.OriginalPrice-Product.NewPrice) * Quantity;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return Product.OriginalPrice * Quantity;
            }
        }
    }
}
