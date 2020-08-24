using System.Collections.Generic;
using PromotionApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /*
        Active Promotions
        *****************
        3 of A's for 130
        2 of B's for 45
        1 Of C & 1 of D for 30
        */

        /// <summary>
        /// Scenario A Testing
        /// </summary>
        [TestMethod]
        public void ScenarioATesting()
        {
            var orders = new List<Order>();

            var order = new Order
            {
                Id = 1,
                OrderId = 1,
                SkuCode = "A",
                Qty = 1,
                DiscountPercentage = Constant.ProductADiscount,
                ProductMinCountPromotion = Constant.ProductMinCountPromotionForA,
                PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                UnitPrice = Constant.ProductAPrice
            };

            orders.Add(order);

            order = new Order
            {
                Id = 1,
                OrderId = 1,
                SkuCode = "B",
                Qty = 1,
                DiscountPercentage = Constant.ProductBDiscount,
                ProductMinCountPromotion = Constant.ProductMinCountPromotionForB,
                PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                UnitPrice = Constant.ProductBPrice
            };

            orders.Add(order);

            order = new Order
            {
                Id = 1,
                OrderId = 1,
                SkuCode = "C",
                Qty = 1,
                DiscountPercentage = Constant.ProductCDDiscount,
                ProductMinCountPromotion = Constant.ProductMinCountPromotionForCD,
                PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                UnitPrice = Constant.ProductCPrice
            };

            orders.Add(order);

            var promotionEngine = new PromotionEngine();

            var expected = promotionEngine.CalculatePromotion(orders);
            var actual = 100D;
            Assert.AreEqual(actual, expected);



        }

        /// <summary>
        /// Scenario B Testing
        /// </summary>
        [TestMethod]
        public void ScenarioBTesting()
        {
            var orders = new List<Order>();


            var order = new Order
            {
                Id = 1,
                OrderId = 1,
                SkuCode = "A",
                Qty = 5,
                DiscountPercentage = Constant.ProductADiscount,
                ProductMinCountPromotion = Constant.ProductMinCountPromotionForA,
                PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                UnitPrice = Constant.ProductAPrice
            };

            orders.Add(order);

            order = new Order
            {
                Id = 1,
                OrderId = 1,
                SkuCode = "B",
                Qty = 5,
                DiscountPercentage = Constant.ProductBDiscount,
                ProductMinCountPromotion = Constant.ProductMinCountPromotionForB,
                PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                UnitPrice = Constant.ProductBPrice
            };

            orders.Add(order);

            order = new Order
            {
                Id = 1,
                OrderId = 1,
                SkuCode = "C",
                Qty = 1,
                DiscountPercentage = Constant.ProductCDDiscount,
                ProductMinCountPromotion = Constant.ProductMinCountPromotionForCD,
                PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                UnitPrice = Constant.ProductCPrice
            };

            orders.Add(order);

            var promotionEngine = new PromotionEngine();
            var expected = promotionEngine.CalculatePromotion(orders);
            var actual = 370D;
            Assert.AreEqual(actual, expected);

        }

        /// <summary>
        /// Scenario C Testing
        /// </summary>
        [TestMethod]
        public void ScenarioCTesting()
        {
            var orders = new List<Order>();

            var order = new Order
            {
                Id = 1,
                OrderId = 1,
                SkuCode = "A",
                Qty = 3,
                DiscountPercentage = Constant.ProductADiscount,
                ProductMinCountPromotion = Constant.ProductMinCountPromotionForA,
                PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                UnitPrice = Constant.ProductAPrice
            };

            orders.Add(order);

            order = new Order
            {
                Id = 1,
                OrderId = 1,
                SkuCode = "B",
                Qty = 5,
                DiscountPercentage = Constant.ProductBDiscount,
                ProductMinCountPromotion = Constant.ProductMinCountPromotionForB,
                PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                UnitPrice = Constant.ProductBPrice
            };

            orders.Add(order);

            order = new Order
            {
                Id = 1,
                OrderId = 1,
                SkuCode = "C",
                Qty = 1,
                DiscountPercentage = Constant.ProductCDDiscount,
                ProductMinCountPromotion = Constant.ProductMinCountPromotionForCD,
                PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                UnitPrice = Constant.ProductCPrice
            };

            orders.Add(order);

            order = new Order
            {
                Id = 1,
                OrderId = 1,
                SkuCode = "D",
                Qty = 1,
                DiscountPercentage = Constant.ProductCDDiscount,
                ProductMinCountPromotion = Constant.ProductMinCountPromotionForCD,
                PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                UnitPrice = Constant.ProductDPrice
            };

            orders.Add(order);

            var promotionEngine = new PromotionEngine();
            var expected = promotionEngine.CalculatePromotion(orders);
            var actual = 280D;
            Assert.AreEqual(actual, expected);
        }
    }
}
