
using UnityEngine;

public class InputCtrl : ComponentBehavior
{
    private static InputCtrl instance;

   
    [SerializeField] private LayerMask layer;
    private Vector3 inputPos;
    private RaycastHit2D hit;
    public static InputCtrl Instance => instance;
    public RaycastHit2D Hit => hit;

    public Vector3 InputPos => inputPos;
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
        layer = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        if (Camera.main != null) inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            inputPos.z = -1;
            hit = Physics2D.Raycast(inputPos, Vector3.forward, 3, layer);
            if (hit.collider == null) return;
            if(hit.collider.CompareTag("LandTile") && hit.collider.transform.childCount == 0) ItemManager.Instance.CreateNewObject(inputPos, hit.collider.transform);
        }
    }
}
