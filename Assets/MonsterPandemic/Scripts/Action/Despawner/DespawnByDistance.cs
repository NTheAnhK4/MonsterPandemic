
using UnityEngine;

public class DespawnByDistance : AutoDespawn
{
    [SerializeField] protected Camera mainCam;
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float curDis;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainCam();
    }

   

    protected virtual void LoadMainCam()
    {
        if (mainCam != null) return;
        mainCam = Transform.FindObjectOfType<Camera>();
        if(mainCam != null)
        {
            var transform1 = transform;
            Debug.Log(transform1.parent.name + " " + transform1.name + " Load Main cam successful");
        }
    }
    protected override bool CanDespawn()
    {
        return curDis >= disLimit;
    }

    protected override void UpdateLogic()
    {
        curDis = Vector3.Distance(mainCam.transform.position, transform.parent.position);
    }
}
