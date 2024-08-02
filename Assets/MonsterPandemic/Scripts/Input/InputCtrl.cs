
using UnityEngine;

public class InputCtrl : ComponentBehavior
{
    private static InputCtrl instance;

    public static InputCtrl Instance => instance;
    [SerializeField] private LayerMask layer;
    protected override void Awake()
    {
        if(instance != null)
            Debug.LogError("Only 1 Input Ctrl allow to exist");
        instance = this;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetLayer();
    }

    private void ResetLayer()
    {
        layer = LayerMask.GetMask("Weapon Item", "Ground");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            inputPos.z = -1;
            RaycastHit2D hit = Physics2D.Raycast(inputPos, Vector3.forward, 3, layer);
            if(hit.collider != null)
                Debug.Log(hit.collider.tag);
        }
    }
}
