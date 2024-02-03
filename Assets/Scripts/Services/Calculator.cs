
using System.Numerics;


public class Calculator
{
    public BigInteger CurrentValue = 17;
    private int _currentStage = 100000;
    private int _currentLevel = 100000;

    public BigInteger CalculateHP(int level, int stage)
    {
        var value = Calculate(level, stage) * 2 + 15;
        return value;
    }
    public BigInteger CalculateDamage(int level, int stage)
    {
        var value = Calculate(level, stage);
        return value;
    }
    public BigInteger CalculateReward(int level, int stage)
    {
        var value = Calculate(level, stage) / 2 + 15;
        return value;
    }
    public BigInteger CalculateLevelPrice(int level, int stage)
    {
        var value = Calculate(level, stage) * 2 + 17;
        return value;
    }
    private BigInteger Calculate(int level, int stage)
    {
        if (!NeedCalculate(level, stage)) return CurrentValue;
        _currentLevel = level;
        _currentStage = stage;
        

        stage = stage == 0 ? 2 : stage + 1;

        var value = BigInteger.Pow(level + 1, stage);
        var random = new System.Random().NextDouble();
        value += (int)(random * 100) * value / 100;

        CurrentValue = value;

        return value;
    }
    private BigInteger Calculate(int level, BigInteger startValue)
    {
        if (!NeedCalculate(level, 0)) return CurrentValue;
        var value = BigInteger.Pow(startValue, level + 1);

        _currentLevel = level;
        CurrentValue = value;
        return value;
    }
    public bool NeedCalculate(int level, int stage = 0)
    {
        return !(_currentLevel == level && stage == _currentStage);
    }
}