public class Excalibur : Weapon
{
    public override bool UnclockCondition()
    {
        return UserData.Stage >= 2; //������� �������� ������� (5 ������ = ���)
    }
}