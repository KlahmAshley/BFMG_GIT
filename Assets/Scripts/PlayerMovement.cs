using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float horizontal;
    private float vertical;
    public float speed = 6f;
    private Vector3 moveDirection;
    public float jump;
    public Rigidbody rb;
    private bool isGrounded = true;
    public Animator Bodyanimator;
    public Animator Hairanimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void Movement()
    {
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            Bodyanimator.SetBool("IsFalling", false);
            Hairanimator.SetBool("IsFloating", false);
            isGrounded = true;
        }
    }

    private void FixedUpdate()
    {

        if (horizontal != 0f)
        {
            Bodyanimator.SetBool("IsWalking", true);
            Hairanimator.SetBool("IsWalking", true);
        }

        if (horizontal == 0f)
        {
            Bodyanimator.SetBool("IsWalking", false);
            Hairanimator.SetBool("IsWalking", false);
        }

        if (vertical == 0f)
        {
            Hairanimator.SetBool("IsFalling", false);
            Hairanimator.SetBool("IsFloating", false);

            Bodyanimator.SetBool("IsFalling", false);
            Bodyanimator.SetBool("IsFloating", false);
        }


        if (Input.GetAxisRaw("Jump") < 0f && !isGrounded)
        {
            Bodyanimator.SetBool("IsFloating", true);
            Hairanimator.SetBool("IsFloating", true);
        }

        if (Input.GetAxisRaw("Jump") > 0f) //&& currentPower > 0f)
        {
            // currentPower -= Time.deltaTime;
            //rb.AddForce(rb.transform.up * powerForce, ForceMode2D.Impulse);
            // bubbleEffect.gameObject.SetActive(true);

            Bodyanimator.SetBool("IsWalking", false);
            Bodyanimator.SetBool("IsFalling", false);
            Bodyanimator.SetBool("IsFloating", true);

            Hairanimator.SetBool("IsWalking", false);
            Hairanimator.SetBool("IsFalling", false);
            Hairanimator.SetBool("IsFloating", true);
        }
        /*else if (Physics.Raycast(grounded.position, Vector2.down, 1f, LayerMask.GetMask("Ground")))//&& currentPower < maxPower || currentPower == 0.0f)
        {
            currentPower += Time.deltaTime;
            bubbleEffect.gameObject.SetActive(false);
            animator.SetBool("IsFloating", false);
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsWalking", false);

        }
        */
        else
        {
            // bubbleEffect.gameObject.SetActive(false);
            Hairanimator.SetBool("ISWalking", false);
            Hairanimator.SetBool("IsFloating", false);
            Hairanimator.SetBool("IsFalling", true);

            Bodyanimator.SetBool("ISWalking", false);
            Bodyanimator.SetBool("IsFloating", false);
            Bodyanimator.SetBool("IsFalling", true);
        }

        if (isGrounded == true)
        {
            Bodyanimator.SetBool("IsFloating", false);
            Bodyanimator.SetBool("IsFalling", false);

            Hairanimator.SetBool("IsFloating", false);
            Hairanimator.SetBool("IsFalling", false);
            // bubbleEffect.gameObject.SetActive(false);

        }
    }
}
