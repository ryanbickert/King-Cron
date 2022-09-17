using UnityEngine;

public class RavenController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float verticalSpeed;

    private Rigidbody2D rigid;
    private Animator animator;
    private float horizontal;
    private float vertical;
    private bool facingRight = true;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal >= 0.1 || horizontal <= -0.1)
        {
            animator.SetBool("Flying", true);
        }
        else
        {
            animator.SetBool("Flying", false);
        }

        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Vector3 scaleStore = transform.localScale;
            scaleStore.x *= -1;
            transform.localScale = scaleStore;
            facingRight = !facingRight;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(vertical);
        rigid.velocity = new Vector2(horizontal * speed * Time.deltaTime, vertical * verticalSpeed * Time.deltaTime);
    }
}
