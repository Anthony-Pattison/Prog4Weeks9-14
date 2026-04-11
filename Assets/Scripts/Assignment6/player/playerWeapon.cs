using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class playerWeapon : MonoBehaviour
{
    [Header("Player Weapon")]
    public float currentAmmo = 5;
    public float extraAmmo = 5;
    public int clipMax = 6;
    [SerializeField]
    float weaponRange = 5;
    [SerializeField]
    float weaponCoolDown = 0.25f;
    [Header("Looking at")]
    public Transform playerCamera;
    public GameObject lookingAt;
    [Header("Assets")]
    public valueObject accuracyValue;
    public AudioSource AudioSource;
    public AudioClip gunShotAC;
    public AudioClip gunReloadAC;
    public GameObject bulletHole;
    public float weaponDamge;
    bool firedWeapon = false;
    Vector3 orgin;
    Vector3 direction;
    public Vector3 crouchDiff = Vector3.zero;
    readonly float lowAcc = 0.5f;
    //readonly float medAcc = 1.0f;
    readonly float highAcc = 5.0f;
    public Vector3 _movement;

    eventCore EventCore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        EventCore.EV_increasePlayerAmmo.AddListener(increaseAmmo);
        EventCore.EV_pauseGame.AddListener(pauseThis);
        EventCore.EV_unPauseGame.AddListener(unPauseThis);
    }

    // Update is called once per frame
    void Update()
    {
        weaponInput();
        drawRange();
        changeAccuracy();
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(reloadWeapon());
        if (currentAmmo <= 0 && !firedWeapon)
        {
            StartCoroutine(reloadWeapon());
        }
    }
  
    void weaponInput()
    {
        orgin = (playerCamera.position) - crouchDiff;
        direction = transform.forward;
        if (Input.GetMouseButton(0) && !firedWeapon && currentAmmo > 0)
        {
            StartCoroutine(fireWeapon());
        }
    }
    void drawRange()
    {
        Debug.DrawRay(orgin, direction * weaponRange, Color.red);
        if (Physics.Raycast(orgin, direction, out RaycastHit hit, weaponRange))
        {
            lookingAt = hit.collider.gameObject;
        }
        else
        {
            lookingAt = null;   
        }
    }
    IEnumerator reloadWeapon()
    {
        EventCore.EV_playerReload.Invoke();
        AudioSource.PlayOneShot(gunReloadAC);
        float _newAmmo = Mathf.Clamp(extraAmmo, 0, clipMax);
        float usedAmmo = _newAmmo - currentAmmo;
        firedWeapon = true;
        yield return new WaitForSeconds(2);
        currentAmmo = _newAmmo;
        extraAmmo -= usedAmmo;
        firedWeapon = false;
    }
    IEnumerator fireWeapon()
    {
        RaycastHit hit;
        firedWeapon = true;
        AudioSource.PlayOneShot(gunShotAC);
        currentAmmo--;
        EventCore.EV_playerShoot.Invoke();
        // direction based on the accuracy
        if (!isAccuracyLow())
        {
            direction.x += Random.Range(-0.10f, 0.10f);
            direction.y += Random.Range(-0.10f, 0.10f);
        }
        if (Physics.Raycast(orgin, direction, out hit, weaponRange))
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("target"))
                {
                    EventCore.EV_targetShot.Invoke(hit.collider.gameObject.name);
                }
                if (hit.collider.CompareTag("enemy"))
                {
                    EventCore.EV_enemyDamage.Invoke(hit.collider.gameObject.name, weaponDamge);
                }
                if (hit.collider.CompareTag("cover"))
                {
                    //Debug.Log($"hit {hit.collider.gameObject.name} at {transform.forward.z * weaponRange}m away");
                    GameObject _tempBullet = Instantiate(bulletHole, hit.point, Quaternion.identity);

                    Vector3 direction = (transform.position - _tempBullet.transform.position).normalized;
                    _tempBullet.transform.position += (direction / 10);
                    Quaternion rotation = Quaternion.LookRotation(direction);
                    _tempBullet.transform.rotation = rotation;
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

    bool isAccuracyLow()
    {
        if (accuracyValue.value == highAcc)
        {
            return true;
        }
        return false;
    }
    void increaseAmmo(float increaseAmount)
    {
        extraAmmo += increaseAmount;
    }

    void pauseThis()
    {
        this.enabled = false;
    }

    void unPauseThis()
    {
        this.enabled = true;
    }
}
