namespace ConsolePulse.Common;

public class MathHelper
{

    /// <summary>
    /// Calculates the least common multiple (LCM) of two integers
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int CalculateLeastCommonMultiple(int a, int b)
    {
        //convert to positive numbers
        a = Math.Abs(a);
        b = Math.Abs(b);

        int greatestCommonDivisor = CalculateGreatestCommonDivisor(a, b);

        return (a * b) / greatestCommonDivisor;
    }

    /// <summary>
    /// Calculates the Greatest Common Divisor (GCD) of two integers
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int CalculateGreatestCommonDivisor(int a, int b)
    {
        while (b != 0) //until reduce
        {
            int temp = b;
            b = a % b; //update res
            a = temp;
        }
        return a;
    }
}
