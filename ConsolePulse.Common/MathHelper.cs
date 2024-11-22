using System.Security.Cryptography;

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

	/// <summary>
    /// Generate an integers number range 
    /// </summary>
    /// <param name="size"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    public static List<uint> GenerateRandomIntegers(uint size, uint min, uint max)
	{
		if (min > max)
            throw new ArgumentException("min cannot be greater than max");

		List<uint> randomNumbers = new List<uint>();
        var randomBytes = new byte[4];

        while (size > 0) {
			using (var randomGenerator = RandomNumberGenerator.Create())
			{
				randomGenerator.GetBytes(randomBytes);
				uint randomValue = BitConverter.ToUInt32(randomBytes, 0);

                uint range = max - min + 1;
                uint randomInRange = (randomValue % range) + min;

				randomNumbers.Add(randomInRange);
			}
			size--;
        }
       
        return randomNumbers;
	}
}
