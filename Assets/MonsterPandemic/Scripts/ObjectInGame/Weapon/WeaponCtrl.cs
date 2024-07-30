
using UnityEngine;

public abstract class WeaponCtrl : EntityCtrl
{
    protected override void LoadData()
    {
        if(data != null) return;
        string resPath = "Weapon/";
        switch (entityType)
        {
            case "VanguardWeapon":
                resPath += "VanguardWeaponData";
                break;
            case "RangedWeapon":
                resPath += "RangedWeaponData";
                break;
            case "ToughWeapon":
                resPath += "ToughtWeaponData";
                break;
                
        }

        data = Resources.Load<ScriptableObject>(resPath);
        if(data != null)
            Debug.Log(transform.name + " Load Data successful");
    }
    
    
}
