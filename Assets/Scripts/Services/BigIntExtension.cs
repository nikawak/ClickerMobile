using System.Numerics;

public static class BigIntExtension
{
    public static BigInteger Muliply(this BigInteger bigInt, float value)
    {
        var intVal = (int)(value * 100);
        var res = bigInt * intVal / 100;
        return res;
    }
}