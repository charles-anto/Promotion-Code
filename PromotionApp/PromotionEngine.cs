using System.Collections.Generic;
using System.Linq;

namespace PromotionApp
{
    public class PromotionEngine
    {
        public double CalculatePromotion(List<Order> orders)
        {
            double totalAmount = 0D;

            //SKU A Calculation
            var groupBySkus = orders.Where(x => x.SkuCode.ToUpper() == "A");

            if (groupBySkus?.Count() > 0)
            {
                totalAmount = PromotionSingle(groupBySkus.FirstOrDefault().Qty, groupBySkus.First().UnitPrice, groupBySkus.First().DiscountPercentage
                    , groupBySkus.First().ProductMinCountPromotion);
            }

            //SKU B Calculation
            groupBySkus = orders.Where(x => x.SkuCode.ToUpper() == "B");

            if (groupBySkus?.Count() > 0)
            {
                totalAmount += PromotionSingle(groupBySkus.FirstOrDefault().Qty, groupBySkus.First().UnitPrice, groupBySkus.First().DiscountPercentage
                , groupBySkus.First().ProductMinCountPromotion);
            }

            //SKU C Calculation
            groupBySkus = orders.Where(x => x.SkuCode.ToUpper() == "C" || x.SkuCode.ToUpper() == "D");

            if (groupBySkus?.Count() > 0)
            {
                totalAmount += PromotionCombo(groupBySkus, "C", "D");
            }

            return totalAmount;
        }



        public double PromotionSingle(int NoOfItems, double ItemPrice, int discount, int ProductMinCountPromotion)
        {
            double promotionAmount = 0;
            double NonpromotionAmount = 0;
            int PromotionCount;
            int NonPromotionItems;

            PromotionCount = NoOfItems / ProductMinCountPromotion;
            NonPromotionItems = NoOfItems % ProductMinCountPromotion;

            promotionAmount = PromotionCount * (ItemPrice * (ProductMinCountPromotion - 1) + (ItemPrice - (ItemPrice * discount / 100)));

            NonpromotionAmount = NonPromotionItems * ItemPrice;

            return promotionAmount + NonpromotionAmount;
        }

        public double PromotionCombo(IEnumerable<Order> orders, string skuId1, string skuId2)
        {
            var totalAmount = 0D;
            var noOfItems1 = orders.Where(x => x.SkuCode.ToUpper() == skuId1).Count();
            var noOfItems2 = orders.Where(x => x.SkuCode.ToUpper() == skuId2).Count();

            if (noOfItems1 == 0 || noOfItems2 == 0)
            {
                double unitPrice;
                if (noOfItems1 > 0)
                {
                    unitPrice = orders.Where(x => x.SkuCode.ToUpper() == skuId1).FirstOrDefault().UnitPrice;

                    totalAmount = unitPrice * noOfItems1;
                }
                else
                {
                    unitPrice = orders.Where(x => x.SkuCode.ToUpper() == skuId2).FirstOrDefault().UnitPrice;

                    totalAmount = unitPrice * noOfItems2;
                }

                return totalAmount;
            }

            if (noOfItems1 == noOfItems2)
            {
                var productDTotal = noOfItems1 * orders.Where(x => x.SkuCode.ToUpper() == skuId2).FirstOrDefault().UnitPrice;
                var productCDiscount = ((noOfItems1 * orders.Where(x => x.SkuCode.ToUpper() == skuId1).FirstOrDefault().UnitPrice)
                                        * orders.FirstOrDefault().DiscountPercentage) / 100;

                totalAmount = ((noOfItems1 * orders.Where(x => x.SkuCode.ToUpper() == skuId1).FirstOrDefault().UnitPrice)
                                       - productCDiscount) + productDTotal;

            }
            else if (noOfItems1 != noOfItems2)
            {
                int extraProduct;

                if (noOfItems1 > noOfItems2)
                {
                    extraProduct = noOfItems1 - noOfItems2;

                    var unitPrice = extraProduct * orders.Where(x => x.SkuCode.ToUpper() == skuId1).FirstOrDefault().UnitPrice;

                    var productDTotal = noOfItems2 * orders.Where(x => x.SkuCode.ToUpper() == skuId2).FirstOrDefault().UnitPrice;
                    var productCDiscount = ((noOfItems2 * orders.Where(x => x.SkuCode.ToUpper() == skuId1).FirstOrDefault().UnitPrice)
                                            * orders.FirstOrDefault().DiscountPercentage) / 100;

                    totalAmount = ((noOfItems2 * orders.Where(x => x.SkuCode.ToUpper() == skuId1).FirstOrDefault().UnitPrice)
                                           - productCDiscount) + productDTotal + unitPrice;

                }
                else
                {
                    extraProduct = noOfItems2 - noOfItems1;
                    var unitPrice = extraProduct * orders.Where(x => x.SkuCode.ToUpper() == skuId2).FirstOrDefault().UnitPrice;

                    var productDTotal = noOfItems2 * orders.Where(x => x.SkuCode.ToUpper() == skuId2).FirstOrDefault().UnitPrice;
                    var productCDiscount = ((noOfItems2 * orders.Where(x => x.SkuCode.ToUpper() == skuId1).FirstOrDefault().UnitPrice)
                                            * orders.FirstOrDefault().DiscountPercentage) / 100;

                    totalAmount = ((noOfItems2 * orders.Where(x => x.SkuCode.ToUpper() == skuId1).FirstOrDefault().UnitPrice)
                                           - productCDiscount) + productDTotal + unitPrice;
                }



            }

            return totalAmount;

        }

    }
}
