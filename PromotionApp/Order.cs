using static PromotionApp.EnumHelper;

namespace PromotionApp
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { get; set; }
        public string SkuCode { get; set; }
        public int DiscountPercentage { get; set; }
        public int ProductMinCountPromotion { get; set; }
        public PromotionPriceTypeEnum PromotionPriceTypeEnum { get; set; }

    }
}
