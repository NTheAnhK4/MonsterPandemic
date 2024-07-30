

public class MaleWalkerMonsterCtrl : MonsterCtrl
{
    

    protected override void ResetEntityId()
    {
        this.entityId = 0;
    }

    protected override void ResetEntityType()
    {
        this.entityType = "VanguardMonster";
    }

    protected override void ResetTimeDespawn()
    {
        this.timeDespawn = 1.4f;

    }
}

