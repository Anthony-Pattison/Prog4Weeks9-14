using Unity.VectorGraphics;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [Header("For movement")]
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float mouseSens;
    public GameObject cameraTransform;
    playerWeapon currPlayerWeapon;

    public float collisonCheckDistance = 1.5f;
    Rigidbody thisRB;
    float sprintSpeedMulit = 1;
    Vector3 playerStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStart = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        thisRB = GetComponent<Rigidbody>();
        if (GetComponent<playerWeapon>())
        {
            currPlayerWeapon = GetComponent<playerWeapon>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for the player falling out of the world
        killFloor();
        // check player crouch
        crouch();
        // check player sprint
        sprint();
        // if the player is moving lower accuracy
        currPlayerWeapon._movement = KeyboardInput();

        // player looking 
        Vector3 rotation = transform.eulerAngles;
        rotation += mouseInput() * mouseSens * Time.deltaTime;

        transform.eulerAngles = rotation;


        transform.position += KeyboardInput() * movementSpeed * sprintSpeedMulit * Time.deltaTime;
    }

    void killFloor()
    {
        if (transform.position.y <= -10)
        {
            transform.position = playerStart;
        }
    }
    void crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.C))
        {
            transform.localScale = new Vector3(1, .25f, 1);
            currPlayerWeapon.crouchDiff = new Vector3(0, .75f, 0);
            return;
        }
        currPlayerWeapon.crouchDiff = Vector3.zero;
        transform.localScale = Vector3.one;
    }
    void sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintSpeedMulit = 2;
        }
        else
        {
            sprintSpeedMulit = 1;
        }
    }
    Vector3 mouseInput()
    {
        float xLook = -Input.GetAxis("Mouse Y");
        float yLook = Input.GetAxis("Mouse X");
        if (transform.eulerAngles.x >= 80 && transform.eulerAngles.x <= 90)
        {
            xLook = Mathf.Clamp(xLook, -1, 0);
        }
        if (transform.eulerAngles.x >= 200 && transform.eulerAngles.x <= 300)
        {
            xLook = Mathf.Clamp(xLook, 0, 1);
        }
        return new Vector2( xLook, yLook);
    }
    Vector3 KeyboardInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        yInput = applyForwardCollison(yInput);
        xInput = applyRightCollison(xInput);

        Vector3 movement = (transform.TransformDirection(Vector3.forward) * yInput) + (transform.TransformDirection(Vector3.right) * xInput);
        return movement;  
    }

    float applyForwardCollison(float forwardMovement)
    {
        if (checkForCollison(transform.forward))
        {
            forwardMovement = Mathf.Clamp(forwardMovement, -1, 0);
        }
        else if (checkForCollison(transform.forward * -1))
        {
            forwardMovement = Mathf.Clamp(forwardMovement, 0, 1);
        }
        return forwardMovement;
    }

    float applyRightCollison(float rightMovement)
    {
        if (checkForCollison(transform.right))
        {
            rightMovement = Mathf.Clamp(rightMovement, -1, 0);
        }
        else if (checkForCollison(transform.right * -1))
        {
            rightMovement = Mathf.Clamp(rightMovement, 0, 1);
        }
        return rightMovement;
    }
   
    bool checkForCollison(Vector3 direction)
    {
        RaycastHit hit;
        Debug.DrawRay((transform.position - new Vector3(0, transform.localScale.y/2, 0)), direction * collisonCheckDistance, Color.red);
        if (Physics.Raycast((transform.position - new Vector3(0,transform.localScale.y/2,0)), direction, out hit, collisonCheckDistance))
        {
            return true;
        }
        return false;
    }
}
