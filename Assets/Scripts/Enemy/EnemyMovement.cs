using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] float moveRange;
    [SerializeField] float moveSpeed;
    protected GameObject player;
    protected Rigidbody2D rb;


    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        if (!player || !rb) return;
        Vector2 playerPos = player.transform.position;
        Vector2 lookDir = playerPos - rb.position;
        rb.rotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }

    protected void ApplyMovement(Vector2 direction, float speedMultiplier = 1f)
    {
        bool isDead = gameObject.GetComponent<Health>().IsObjectDead();
        rb.velocity = isDead ? Vector2.zero : moveSpeed * speedMultiplier * direction;

        if (Mathf.Approximately(rb.velocity.magnitude, 0)) animator.SetBool("IsFlying", false);
        else animator.SetBool("IsFlying", true);
    }

    protected bool CheckIsPlayerClose()
    {
        if (!player) return false;
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= moveRange;
    }
}
