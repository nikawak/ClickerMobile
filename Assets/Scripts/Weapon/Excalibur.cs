public class Excalibur : Weapon
{
    public override bool UnclockCondition()
    {
        return UserData.Stage >= 0; //сделать просмотр рекламы (5 реклам = меч)
    }
}