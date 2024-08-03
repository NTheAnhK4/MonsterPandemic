


using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class MoveItemUp : ComponentBehavior
{
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private RectTransform item;
    [SerializeField] protected float speed = 100f;
    [SerializeField] private float padding = 2f;
    private enum  State
    {
        ScrollUp,
        Stop
    }

    [SerializeField] private State curState;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigid();
        this.LoadRectTransform();
    }

    private void LoadRectTransform()
    {
        if (item != null) return;
        item = transform.GetComponent<RectTransform>();
        if(item != null)
            Debug.Log(transform.name + " Load RectTransform successful");
    }

    private void LoadCollider()
    {
        if (_boxCollider2D != null) return;
        _boxCollider2D = transform.GetComponent<BoxCollider2D>();
        if (_boxCollider2D != null)
        {
            ChangeColliderInfor();
            Debug.Log(transform.name + " Load collider successful");
        }
           
    }

    private void LoadRigid()
    {
        if (_rigidbody2D != null) return;
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        if (_rigidbody2D != null)
        {
            ChangeRigidInfor();
            Debug.Log(transform.name + " Load Rigid successful");
        }
    }

    private void ChangeRigidInfor()
    {
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.gravityScale = 0;
    }
    private void ChangeColliderInfor()
    {
        _boxCollider2D.isTrigger = true;
        _boxCollider2D.offset = new Vector2(0, 0);
        _boxCollider2D.size = new Vector2(1, 1.1f);
    }

    

    private void OnEnable()
    {
        curState = State.ScrollUp;
        this.ResetInitiallyIndex();
        
    }

    private void ResetInitiallyIndex()
    {
        item.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,transform.parent.GetComponent<RectTransform>().rect.width - padding);
        item.anchoredPosition = new Vector2(item.anchoredPosition.x, -Screen.height + 500);
    }
    

    private void ScrollUp()
    {
        item.anchoredPosition += new Vector2(0, speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.transform.position.y > transform.position.y) curState = State.Stop;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.position.y > transform.position.y) curState = State.ScrollUp;
    }

    private void Update()
    {
        if(curState == State.ScrollUp) ScrollUp();
    }
    
}
