using UnityEngine;

public class playerCam : MonoBehaviour
{
    float yRotation;
    float xRotation;
    public GameObject orientation;
    [SerializeField]
    float mouseSens;
    //UI//
    public void mouseSensChange(float change)
    {
        mouseSens = change;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xLook = Input.GetAxisRaw("Mouse X") * mouseSens;
        float yLook = -Input.GetAxisRaw("Mouse Y") * mouseSens;

        yRotation += xLook;

        xRotation += yLook;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
