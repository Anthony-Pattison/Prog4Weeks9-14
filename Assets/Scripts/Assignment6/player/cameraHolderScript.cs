using UnityEngine;

public class cameraHolderScript : MonoBehaviour
{
    public Transform playerOrientation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerOrientation.position;
        transform.rotation = playerOrientation.rotation;
    }
}
