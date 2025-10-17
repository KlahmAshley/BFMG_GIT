using UnityEngine;
using UnityEngine.EventSystems;

public class Playermove2 : MonoBehaviour
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

    public GameObject WandBehind;
    public GameObject WandFront;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        WandBehind.SetActive(true);
        WandFront.SetActive(false);

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
            Bodyanimator.SetBool("IsFloating", false);
            WandBehind.SetActive(true);
            WandFront.SetActive(false);
            isGrounded = true;
        }
    }

    private void FixedUpdate()
    {

        if (horizontal != 0f)
        {
            Bodyanimator.SetBool("IsWalking", true);
        }

        if (horizontal == 0f)
        {
            Bodyanimator.SetBool("IsWalking", false);
        }

        if (vertical != 0f)
        {
            Bodyanimator.SetBool("IsWalking", true);
        }


        if (Input.GetAxisRaw("Jump") < 0f && !isGrounded)
        {
            Bodyanimator.SetBool("IsFloating", true);
            WandBehind.SetActive(false);
            WandFront.SetActive(true);
        }

        if (Input.GetAxisRaw("Jump") > 0f) //&& currentPower > 0f)
        {
            // currentPower -= Time.deltaTime;
            //rb.AddForce(rb.transform.up * powerForce, ForceMode2D.Impulse);
            // bubbleEffect.gameObject.SetActive(true);

            Bodyanimator.SetBool("IsWalking", false);
            Bodyanimator.SetBool("IsFalling", false);
            Bodyanimator.SetBool("IsFloating", true);
            WandBehind.SetActive(false);
            WandFront.SetActive(true);
        }

        else
        {
            // bubbleEffect.gameObject.SetActive(false);
            Bodyanimator.SetBool("ISWalking", false);
            Bodyanimator.SetBool("IsFloating", false);
            Bodyanimator.SetBool("IsFalling", true);
            WandBehind.SetActive(true);
            WandFront.SetActive(false);
        }

        if (isGrounded == true)
        {
            Bodyanimator.SetBool("IsFloating", false);
            Bodyanimator.SetBool("IsFalling", false);
            WandBehind.SetActive(true);
            WandFront.SetActive(false);
            // bubbleEffect.gameObject.SetActive(false);

        }
    }
}
