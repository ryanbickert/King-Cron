using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private CompositeCollider2D tilemapCollider;

    private Rigidbody2D rigid;
    private CircleCollider2D myCollider;
    private AudioSource myAudioSource;
    private float horizontal;
    private bool facingRight = true;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CircleCollider2D>();
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Vector3 scaleStore = transform.localScale;
            scaleStore.x *= -1;
            transform.localScale = scaleStore;
            facingRight = !facingRight;
        }

        if (myCollider.IsTouching(tilemapCollider) && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            myAudioSource.Play();
            rigid.AddForce(new Vector2(rigid.velocity.x, jumpHeight));
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(horizontal * speed * Time.deltaTime, rigid.velocity.y);
    }
}
