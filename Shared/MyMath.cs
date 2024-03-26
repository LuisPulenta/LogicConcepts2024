namespace Shared
{
    public class MyMath
    {
        public static double Factorial(int n)
        {
            double fact = 1;

            for (int i = 2; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}