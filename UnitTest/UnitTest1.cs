using System.Collections.Generic;
using PromotionApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Scenario A Testing
        /// </summary>
        [TestMethod]
        public void ScenarioATesting()
        {
            var orders = new List<Order>();
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
          
            Assert.IsNotNUll(expected);

        }

        /// <summary>
        /// Scenario C Testing
        /// </summary>
        [TestMethod]
        public void ScenarioCTesting()
        {
            var orders = new List<Order>();
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
           
            Assert.IsTrue();
        }
    }
}
