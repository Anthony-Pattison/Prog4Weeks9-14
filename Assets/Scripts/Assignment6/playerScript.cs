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

    Rigidbody thisRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        Vector3 rotation = transform.eulerAngles;
        rotation += mouseInput() * mouseSens * Time.deltaTime;

        currPlayerWeapon._movement = KeyboardInput();
        transform.eulerAngles = rotation;
        transform.position += KeyboardInput() * movementSpeed * Time.deltaTime;

        crouch();
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

    Vector3 mouseInput()
    {
        float xLook = -Input.GetAxis("Mouse Y");
        float yLook = Input.GetAxis("Mouse X");

        return new Vector2( xLook, yLook);
    }
    Vector3 KeyboardInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 movement = (transform.TransformDirection(Vector3.forward) * yInput) + (transform.TransformDirection(Vector3.right) * xInput);
        return movement;  
    } 
}
