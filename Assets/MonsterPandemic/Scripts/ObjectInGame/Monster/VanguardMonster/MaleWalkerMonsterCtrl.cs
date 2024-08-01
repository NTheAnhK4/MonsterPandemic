

public class MaleWalkerMonsterCtrl : VanguardMonsterCtrl
{
    

    protected override void ResetEntityId()
    {
        this.entityId = 0;
    }

   

    protected override void ResetTimeDespawn()
    {
        this.timeDespawn = 1.4f;

    }
}

