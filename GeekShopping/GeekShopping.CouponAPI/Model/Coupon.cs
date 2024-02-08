using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeekShopping.CouponAPI.Model.Base;

namespace GeekShopping.CouponAPI.Model
{
    [Table("coupon")]
    public class Coupon : BaseEntity
    {
        [Column("coupon_code")]
        [Required]
        [StringLength(30)]
        public string CouponCode { get; set; }

        [Column(name: "discount_amount", TypeName = "decimal(18, 2)")]
        [Required]
        public decimal DiscountAmount { get; set; }
    }
}
