using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

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

    public float maxPower = 1f;
    private float currentPower;
    public float powerForce = 0.5f;

    public GameObject spawnPoint;

    public Animator Bodyanimator;

    public GameObject WandBehind;
    public GameObject WandFront;

    public TMP_Text EBCounter;
    public int remainingEB = 15;
    public int collected = 0;

    public GameObject EndScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        currentPower = maxPower;
        WandBehind.SetActive(true);
        WandFront.SetActive(false);
        EBCounter.text = collected + "/" + remainingEB;
        EndScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (isGrounded)
        {
            if (currentPower < maxPower)
            {
                currentPower += Time.deltaTime;
            }
        }
        

        Debug.Log("Current power is: " + currentPower);

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(collected == remainingEB)
        {
           Time.timeScale = 0f;
            EndScreen.SetActive(true);
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

        if (Input.GetAxisRaw("Jump") > 0f && currentPower > 0f)
        {
            Debug.Log("She bubble on my floatie till i Mcgee");
            currentPower -= Time.deltaTime;
            rb.AddForce(rb.transform.up * powerForce, ForceMode.Impulse);

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

    private void Movement()
    {
       // float horizontal = Input.GetAxis("Horizontal");
      //  float vertical = Input.GetAxis("Vertical");
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
            isGrounded = true;

            Bodyanimator.SetBool("IsFalling", false);
            Bodyanimator.SetBool("IsFloating", false);
            WandBehind.SetActive(true);
            WandFront.SetActive(false);
        }

        if (collision.gameObject.tag == ("Bubble"))
        {
            collected++;
            EBCounter.text = collected + "/" + remainingEB;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == ("GameOver"))
        {
            rb.transform.position = spawnPoint.transform.position;
        }
    }

    public float GetPowerProportion()
    {
        return currentPower / maxPower;
    }
}
