using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class playerWeapon : MonoBehaviour
{
    [Header("Player Weapon")]
    public float currentAmmo = 5;
    public float extraAmmo = 5;
    [SerializeField]
    float weaponRange = 5;
    [SerializeField]
    float weaponCoolDown = 0.25f;
    public valueObject accuracyValue;
    public AudioSource AudioSource;
    public AudioClip gunShotAC;

    public GameObject bulletHole;
    int clipMax = 6;
    bool firedWeapon = false;
    Vector3 orgin;
    Vector3 direction;

    readonly float lowAcc = 0.5f;
    readonly float medAcc = 1.0f;
    readonly float highAcc = 5.0f;

    public Vector3 _movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        drawRange();
        weaponInput();
        changeAccuracy();

        if (currentAmmo <= 0 && !firedWeapon)
        {
            StartCoroutine(reloadWeapon());
        }
    }
    void weaponInput()
    {
        orgin = transform.position + transform.forward + (transform.up);
        direction = transform.forward;
        if (Input.GetMouseButton(0) && !firedWeapon)
        {
            StartCoroutine(fireWeapon());
        }
    }
    void drawRange()
    {
        Debug.DrawRay(orgin, direction * weaponRange, Color.red);
    }
    IEnumerator reloadWeapon()
    {
        float _newAmmo = Mathf.Clamp(extraAmmo, 0, clipMax);
        firedWeapon = true;
        yield return new WaitForSeconds(3);
        currentAmmo = _newAmmo;
        extraAmmo -= _newAmmo;
        firedWeapon = false;
    }
    IEnumerator fireWeapon()
    {
        RaycastHit hit;
        firedWeapon = true;
        AudioSource.PlayOneShot(gunShotAC);
        currentAmmo--;
        if (Physics.Raycast(orgin, direction, out hit, weaponRange))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("cover"))
                {
                    Debug.Log($"hit {hit.collider.gameObject.name} at {transform.forward.z * weaponRange}m away");
                    GameObject _tempBullet = Instantiate(bulletHole, hit.point, Quaternion.identity);

                    Vector3 direction = (transform.position - _tempBullet.transform.position).normalized;
                    _tempBullet.transform.position += (direction / 10);
                    _tempBullet.transform.eulerAngles = hit.collider.transform.eulerAngles;
                }
            }
        }
        yield return new WaitForSeconds(weaponCoolDown);
        firedWeapon = false;
    }
    
    void changeAccuracy()
    {
        if (_movement == Vector3.zero)
        {
            accuracyValue.value = highAcc;
        }
        else
        {
            accuracyValue.value = lowAcc;
        }
    }
}
