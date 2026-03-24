using UnityEngine;

public class slimScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + (transform.forward * 4) - (Vector3.right * -2), Color.red);
        Debug.DrawLine(transform.position, transform.position + (transform.forward * 6) - (Vector3.right * 2), Color.red);
    }
}
