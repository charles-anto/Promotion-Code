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

            if (orders.Any(x => x.SkuCode.ToUpper() == "A"))
            {
                var groupBySkuIdOrder = orders.FirstOrDefault(x => x.SkuCode.ToUpper() == "A");
                totalAmount += PromotionSingle(groupBySkuIdOrder.Qty
                                            , groupBySkuIdOrder.UnitPrice
                                            , groupBySkuIdOrder.DiscountPercentage
                                            , groupBySkuIdOrder.ProductMinCountPromotion);
            }

            //SKU B Calculation
            if (orders.Any(x => x.SkuCode.ToUpper() == "B"))
            {
                var groupBySkuIdOrder = orders.FirstOrDefault(x => x.SkuCode.ToUpper() == "B");
                totalAmount += PromotionSingle(groupBySkuIdOrder.Qty
                                            , groupBySkuIdOrder.UnitPrice
                                            , groupBySkuIdOrder.DiscountPercentage
                                            , groupBySkuIdOrder.ProductMinCountPromotion);
            }

            //SKU C / D Calculation
            var groupBySkuOrders = orders.Where(x => x.SkuCode.ToUpper() == "C" || x.SkuCode.ToUpper() == "D");

            if (groupBySkuOrders?.Count() > 0)
            {
                totalAmount += PromotionCombo(groupBySkuOrders, "C", "D");
            }

            return totalAmount;
        }

        public double PromotionCombo(IEnumerable<Order> orders, string skuId1, string skuId2)
        {
            var totalAmount = 0D;
            var noOfItems1 = orders.Where(x => x.SkuCode.ToUpper() == skuId1).Count();
            var noOfItems2 = orders.Where(x => x.SkuCode.ToUpper() == skuId2).Count();

            if (noOfItems1 == 0 || noOfItems2 == 0)
            {
                if (noOfItems1 > 0)
                {
                    double unitPrice = orders.Where(x => x.SkuCode.ToUpper() == skuId1).FirstOrDefault().UnitPrice;

                    totalAmount = unitPrice * noOfItems1;
                }
                else
                {
                    double unitPrice = orders.Where(x => x.SkuCode.ToUpper() == skuId2).FirstOrDefault().UnitPrice;

                    totalAmount = unitPrice * noOfItems2;
                }

                return totalAmount;
            }

            if (noOfItems1 == noOfItems2)
            {
                var productDTotal = noOfItems1 * orders.FirstOrDefault(x => x.SkuCode.ToUpper() == skuId2).UnitPrice;
                var productCDiscount = ((noOfItems1 * orders.FirstOrDefault(x => x.SkuCode.ToUpper() == skuId1).UnitPrice)
                                        * orders.FirstOrDefault().DiscountPercentage) / 100;

                totalAmount = ((noOfItems1 * orders.FirstOrDefault(x => x.SkuCode.ToUpper() == skuId1).UnitPrice)
                                       - productCDiscount) + productDTotal;

            }
            else if (noOfItems1 != noOfItems2)
            {
                int extraProduct;

                if (noOfItems1 > noOfItems2)
                {
                    extraProduct = noOfItems1 - noOfItems2;

                    var unitPrice = extraProduct * orders.FirstOrDefault(x => x.SkuCode.ToUpper() == skuId1).UnitPrice;

                    var productDTotal = noOfItems2 * orders.FirstOrDefault(x => x.SkuCode.ToUpper() == skuId2).UnitPrice;
                    var productCDiscount = ((noOfItems2 * orders.FirstOrDefault(x => x.SkuCode.ToUpper() == skuId1).UnitPrice)
                                            * orders.FirstOrDefault().DiscountPercentage) / 100;

                    totalAmount = ((noOfItems2 * orders.FirstOrDefault(x => x.SkuCode.ToUpper() == skuId1).UnitPrice)
                                           - productCDiscount) + productDTotal + unitPrice;

                }
                else
                {
                    extraProduct = noOfItems2 - noOfItems1;
                    var unitPrice = extraProduct * orders.FirstOrDefault(x => x.SkuCode.ToUpper() == skuId2).UnitPrice;

                    var productDTotal = noOfItems2 * orders.FirstOrDefault(x => x.SkuCode.ToUpper() == skuId2).UnitPrice;
                    var productCDiscount = ((noOfItems2 * orders.FirstOrDefault(x => x.SkuCode.ToUpper() == skuId1).UnitPrice)
                                            * orders.FirstOrDefault().DiscountPercentage) / 100;

                    totalAmount = ((noOfItems2 * orders.FirstOrDefault(x => x.SkuCode.ToUpper() == skuId1).UnitPrice)
                                           - productCDiscount) + productDTotal + unitPrice;
                }

            }

            return totalAmount;

        }

        private double PromotionSingle(int qty, double unitPrice, int discount, int productMinCountPromotion)
        {
            int promotionCount = qty / productMinCountPromotion;
            int nonPromotionItems = qty % productMinCountPromotion;

            double promotionAmount = promotionCount * ((unitPrice * productMinCountPromotion) - Math.Round(((unitPrice * productMinCountPromotion) * discount/100))) ;

            double nonpromotionAmount = nonPromotionItems * unitPrice;

            return promotionAmount + nonpromotionAmount;
        }
    }
}
