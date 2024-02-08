public class DoubleAxe : Weapon
{
    public override bool UnclockCondition()
    {
        return UserData.Stage >= 0;
    }
}