using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   
}

