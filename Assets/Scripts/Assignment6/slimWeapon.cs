using UnityEngine;

public class slimWeapon : MonoBehaviour
{
    public float weaponRange;
    Vector3 orgin;
    Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        orgin = transform.position;
        direction = transform.forward;
        drawRange();
    }

    void drawRange()
    {
        Debug.DrawRay(orgin, direction * weaponRange, Color.red);
    }
}
