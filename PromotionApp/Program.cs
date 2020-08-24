using System;

namespace PromotionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Product A Count:");
            var productA = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Product B Count:");
            var productB = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Product C Count:");
            var productC = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Product D Count:");
            var productD = Convert.ToInt32(Console.ReadLine());


            PromotionEngine pe = new PromotionEngine();

            double result = pe.PromotionSingle(10, 50, 40, 3);

            Console.WriteLine(result);


            /*
            int resultA = 0;

            int remainderA = productA % 3;
            int quotientA = productA / 3;

            resultA = (quotientA * 130) + (remainderA * 50);
            
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("         Calculation Result");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Calculation of A    : "+ resultA);

            int remainderB = productB % 2;
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
            Console.ReadLine();
            */
        }        
    }
}
