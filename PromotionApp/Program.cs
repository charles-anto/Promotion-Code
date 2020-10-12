using System;
using System.Collections.Generic;

namespace PromotionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var orders = new List<Order>();
                var order = default(Order);

                Console.WriteLine("Enter Product A Qty: ");
                int.TryParse(Console.ReadLine(), out int qtyA);
                //var qtyA = TryParse Convert.ToInt32(Console.ReadLine());
                if (qtyA > 0)
                {
                    order = new Order
                    {
                        Id = 1,
                        OrderId = 1,
                        SkuCode = "A",
                        Qty = qtyA,
                        DiscountPercentage = Constant.ProductADiscount,
                        ProductMinCountPromotion = Constant.ProductMinCountPromotionForA,
                        PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                        UnitPrice = Constant.ProductAPrice
                    };

                    orders.Add(order);
                }
                Console.WriteLine("Enter Product B Qty: ");

                int.TryParse(Console.ReadLine(), out int qtyB);
                if (qtyB > 0)
                {
                    order = new Order
                    {
                        Id = 2,
                        OrderId = 1,
                        SkuCode = "B",
                        Qty = qtyB,
                        DiscountPercentage = Constant.ProductBDiscount,
                        ProductMinCountPromotion = Constant.ProductMinCountPromotionForB,
                        PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                        UnitPrice = Constant.ProductBPrice
                    };

                    orders.Add(order);

                }
                Console.WriteLine("Enter Product C Qty: ");
                int.TryParse(Console.ReadLine(), out int qtyC);

                if (qtyC > 0)
                {
                    order = new Order
                    {
                        Id = 3,
                        OrderId = 1,
                        SkuCode = "C",
                        Qty = qtyC,
                        DiscountPercentage = Constant.ProductCDDiscount,
                        ProductMinCountPromotion = Constant.ProductMinCountPromotionForCD,
                        PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                        UnitPrice = Constant.ProductCPrice
                    };

                    orders.Add(order);
                }

                Console.WriteLine("Enter Product D Qty: ");
                int.TryParse(Console.ReadLine(), out int qtyD);

                if (qtyD > 0)
                {
                    order = new Order
                    {
                        Id = 4,
                        OrderId = 1,
                        SkuCode = "D",
                        Qty = 1,
                        DiscountPercentage = Constant.ProductCDDiscount,
                        ProductMinCountPromotion = Constant.ProductMinCountPromotionForCD,
                        PromotionPriceTypeEnum = EnumHelper.PromotionPriceTypeEnum.Combination,
                        UnitPrice = Constant.ProductDPrice
                    };

                    orders.Add(order);
                }

                PromotionEngine promotionEngine = new PromotionEngine();

                double result = promotionEngine.CalculatePromotion(orders);

                Console.WriteLine("Total: " + result);

                /*
                int resultA = 0;

                int remainderA = productA / 3;
                int quotientA = productA / 3;

                resultA = (quotientA * 130) + (remainderA * 50);

                Console.WriteLine("---------------------------------------");
                Console.WriteLine("         Calculation Result");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Calculation of A    : "+ resultA);

                int remainderB = productB / 2;
                int quotientB = productB / 2;

                var resultB = (quotientB * 45) + (remainderB * 30);

                Console.WriteLine("Calculation of B    : " + resultB);

                int resultCD = 0;
                if(productC == productD)
                {
                    resultCD = productC * 30;
                }
                else if(productC > productD)
                {
                    int remainderC = productC - productD;
                    resultCD = ((productC - remainderC) * 30) + (remainderC * 20);

                }
                else if (productC < productD)
                {
                    int remainderD = productD - productC;
                    resultCD = ((productD - remainderD) * 30) + (remainderD * 15);
                }
                Console.WriteLine("Calculation of C & D : " + resultCD);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("                 Total : " + (resultA+ resultB+ resultCD));
                Console.WriteLine("---------------------------------------");
                */
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
