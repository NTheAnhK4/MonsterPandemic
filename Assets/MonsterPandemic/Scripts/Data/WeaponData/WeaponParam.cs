

public class WeaponParam : EntityParam
{
    public float maxHp;
    public float hpGrowthRate;
    public Usage usage;

    public float GetMaxHp(int objectLevel)
    {
        return (objectLevel - level) * hpGrowthRate + maxHp;
    }
}
