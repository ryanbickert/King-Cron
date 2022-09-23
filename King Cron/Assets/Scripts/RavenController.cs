using UnityEngine;
using System.Collections;

public class RavenController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private Transform launchingPad;
    [SerializeField] private GameObject ravenGroup;

    private Rigidbody2D rigid;
    private Animator animator;
    private float horizontal;
    private float vertical;
    private bool facingRight = true;
    private bool stepOne;
    private bool stepTwo;
    private bool stepThree;
    private bool stepFour;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(nameof(StartAllCoroutines));
    }

    private IEnumerator StartAllCoroutines()
    {
        yield return new WaitForSeconds(5f);
        animator.SetBool("Flying", true);
        stepOne = true;
        StartCoroutine(nameof(FlyOffScreen));
    }

    private IEnumerator FlyOffScreen()
    {
        yield return new WaitForSeconds(2.1f);
        stepOne = false;
        rigid.velocity = Vector2.zero;
        animator.SetBool("Flying", false);
        StartCoroutine(nameof(WaitOnScreen));
    }

    private IEnumerator WaitOnScreen()
    {
        yield return new WaitForSeconds(2f);
        stepTwo = true;
        animator.SetBool("Flying", true);
        StartCoroutine(nameof(FlyOnScreen));
    }

    private IEnumerator FlyOnScreen()
    {
        yield return new WaitForSeconds(1f);
        stepTwo = false;
        rigid.velocity = Vector2.zero;
        ravenGroup.transform.position = launchingPad.position;
        stepThree = true;
        StartCoroutine(nameof(StopOnScreen));
    }

    private IEnumerator StopOnScreen()
    {
        yield return new WaitForSeconds(1.5f);
        stepThree = false;
        rigid.velocity = Vector2.zero;
        animator.SetBool("Flying", false);
    }

    private void FixedUpdate()
    {
        if (stepOne)
        {
            rigid.velocity = new Vector2(speed * Time.deltaTime, verticalSpeed * Time.deltaTime);
        }
        else if (stepTwo)
        {
            rigid.velocity = new Vector2(speed * Time.deltaTime, verticalSpeed * Time.deltaTime);
        }
        else if (stepThree)
        {
            rigid.velocity = new Vector2(speed * Time.deltaTime, verticalSpeed * Time.deltaTime);
        }
    }
}
