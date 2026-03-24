using UnityEngine;

public class playerScript : MonoBehaviour
{
    [Header("For movement")]
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float mouseSens;

    Rigidbody thisRB;
    Transform orientation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        thisRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += mouseInput() * mouseSens * Time.deltaTime;
        transform.position += KeyboardInput() * movementSpeed * Time.deltaTime;
    }

    Vector3 mouseInput()
    {
        return new Vector2( -Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
    }
    Vector3 KeyboardInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 movement = (transform.TransformDirection(Vector3.forward) * yInput) + (transform.TransformDirection(Vector3.right) * xInput);
        return movement;  
    } 
}
