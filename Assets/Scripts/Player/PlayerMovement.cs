using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxOffsetX;
    [SerializeField] private float maxOffsetY;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Plane aimPlane;
    private Vector2 mousePosition;
    private bool allowMovement = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aimPlane = new(Vector3.back, Vector3.zero);
    }

    void Update()
    {
        GetMovementInput();
        GetMousePosition();
    }

    void FixedUpdate()
    {
        if (allowMovement) MoveAndRotate();
    }

    private void GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (aimPlane.Raycast(ray, out float enter))
        {
            mousePosition = ray.GetPoint(enter);
        }
    }

    private void GetMovementInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetBool("IsFlying", movement.x != 0 || movement.y != 0);
    }

    private void MoveAndRotate()
    {
        if (!rb) return;
        Vector2 newPosition = rb.position + moveSpeed * Time.fixedDeltaTime * movement;
        rb.MovePosition(new Vector2(
            Mathf.Clamp(newPosition.x, -maxOffsetX, maxOffsetX),
            Mathf.Clamp(newPosition.y, -maxOffsetY, maxOffsetY)
        ));
        Vector2 lookDirection = mousePosition - rb.position;
        rb.SetRotation(Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f);
    }

    public void SetAllowMovement(bool isAllowed)
    {
        allowMovement = isAllowed;
    }
}
