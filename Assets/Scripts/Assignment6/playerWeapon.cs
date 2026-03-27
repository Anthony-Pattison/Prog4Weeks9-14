using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class playerWeapon : MonoBehaviour
{
    [Header("Player Weapon")]
    [SerializeField]
    float currentAmmo = 5;
    [SerializeField]
    float extraAmmo = 5;
    [SerializeField]
    float weaponRange = 5;
    [SerializeField]
    float weaponCoolDown = 0.25f;
    public AudioSource AudioSource;
    public AudioClip gunShotAC;


    bool firedWeapon = false;
    Vector3 orgin;
    Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        drawRange();
        weaponInput();
    }
    void weaponInput()
    {
        orgin = transform.position + transform.forward + (transform.up);
        direction = transform.forward;
        if (Input.GetMouseButtonDown(0) && !firedWeapon)
        {
            StartCoroutine(fireWeapon());
        }
    }
    void drawRange()
    {
        Debug.DrawRay(orgin, direction * weaponRange, Color.red);
    }
    
    IEnumerator fireWeapon()
    {
        RaycastHit hit;
        firedWeapon = true;
        AudioSource.PlayOneShot(gunShotAC);
        if (Physics.Raycast(orgin, direction, out hit, weaponRange))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider != null)
            {
                Debug.Log($"hit {hit.collider.gameObject.name} at {transform.forward.z * weaponRange}m away");
            }
        }
        yield return new WaitForSeconds(weaponCoolDown);
        firedWeapon = false;
    }
}
