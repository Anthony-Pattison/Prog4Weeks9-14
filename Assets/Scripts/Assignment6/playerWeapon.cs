using UnityEngine;

public class playerWeapon : MonoBehaviour
{
    [Header("Player Weapon")]
    [SerializeField]
    float currentAmmo = 5;
    [SerializeField]
    float extraAmmo = 5;
    [SerializeField]
    float weaponRange = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        drawRange();
    }

    void drawRange()
    {
        Vector3 orgin = transform.position + transform.forward + (transform.up);
        Vector3 direction = transform.forward;
        Physics.Raycast(orgin, direction, weaponRange);
        Debug.DrawRay(orgin, direction * weaponRange, Color.pink);
    }
}
