using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float horizontal;
    private float vertical;
    public float speed = 6f;
    public float rotationSpeed = 1000f;
    private Vector3 moveDirection;
    public float jump;
    public Rigidbody rb;
    private bool isGrounded = true;
    private RaycastHit hit;

    public float maxPower = 1f;
    private float currentPower;
    public float powerForce = 0.5f;

    public GameObject spawnPoint;

    public Animator Bodyanimator;

    public GameObject WandBehind;
    public GameObject WandFront;

    public GameObject dialogueOne;
    public GameObject dialogueTwo;
    public GameObject dialogueThree;
    private bool Bogalogue = false;
    private bool Bogalogue2 = false;
    private bool Bogalogue3 = false;
    private float waitTime = 0f;

    public TMP_Text EBCounter;
    public int remainingEB = 10;
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
    private void Update()
    {
        //Debug.Log(waitTime);
        waitTime += Time.deltaTime;
        Dialogue();

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
        Rotation();
        Movement();
        

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
            Bodyanimator.SetBool("IsWalking", false);
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
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

        if (collision.gameObject.tag == ("Bog"))
        {
            Bogalogue = true;
            dialogueOne.SetActive(true);
            dialogueTwo.SetActive(true);
            dialogueThree.SetActive(true);
        }
    }

    public float GetPowerProportion()
    {
        return currentPower / maxPower;
    }

    private void Rotation()
    {
        var mousePosition = Input.mousePosition;
        var cameraRay = Camera.main.ScreenPointToRay(mousePosition);
        var layerMask = LayerMask.GetMask("Ground");

        if (Physics.Raycast(cameraRay, out hit, 100, layerMask))
        {
            var forward = hit.point - this.transform.position;
            var rotation = Quaternion.LookRotation(forward);

            this.transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w).normalized;
        }
    }

    private void Dialogue()
    {
        while (Bogalogue && waitTime >= 0.5)
        {
            if (Input.GetKey(KeyCode.E))
            {
                waitTime = 0;
                Debug.Log("are you working?");
                dialogueOne.SetActive(false);

                Bogalogue = false;
                Bogalogue2 = true;
            }
            
            break;
        }
        

        while (Bogalogue2 && waitTime >= 0.5)
        {
            ;
            if (Input.GetKey(KeyCode.E))
            {
                waitTime = 0;
                Debug.Log("test");
                dialogueTwo.SetActive(false);

                Bogalogue2 = false;
                Bogalogue3 = true;

            }
            
            break;
        }

        
        while (Bogalogue3 && waitTime >= 0.5)
        {

            if (Input.GetKey(KeyCode.E))
            {
                waitTime = 0;
                Debug.Log("test2");
                dialogueThree.SetActive(false);
                Bogalogue3 = false;
            }
            
            
            break;
        }

        
    }
}
