using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeapon : MonoBehaviour
{
    [Header("Player Weapon")]
    public List<gunValue> weaponInventory;
    public gunValue gunInHand;
    public float currentAmmo = 5;
    public float extraAmmo = 5;
    public int clipMax = 6;
    [SerializeField]
    float weaponRange = 5;
    [SerializeField]
    float weaponCoolDown = 0.25f;
    public GameObject pistolHands;
    public GameObject rifleHands;
    [Header("Looking at")]
    public Transform playerCamera;
    public GameObject lookingAt;
    [Header("Assets")]
    public valueObject accuracyValue;
    public AudioSource AudioSource;
    public AudioClip gunShotAC;
    public AudioClip gunReloadAC;
    public AudioClip[] rifleFireAC;
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
    public bool pistolOut = true;
    eventCore EventCore;
    public GameObject cameraObject;
    public GameObject golumObject;
    public CameraAnimation cameraAnimation;
    Vector3 cameraPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        EventCore.EV_increasePlayerAmmo.AddListener(increaseAmmo);
        EventCore.EV_pauseGame.AddListener(pauseThis);
        EventCore.EV_unPauseGame.AddListener(unPauseThis);
        EventCore.EV_playCameraAnimations.AddListener(pausePlayer);
        EventCore.EV_finshCameraAnimation.AddListener(unPausePlayer);
        
    }
    void unPausePlayer()
    {
        this.gameObject.SetActive(true);
        cameraObject.transform.localPosition = Vector3.zero;
        cameraObject.transform.localEulerAngles = Vector3.zero;
    }
    void pausePlayer()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (golumObject.activeInHierarchy == false)
        {
            cameraAnimation.startCameraMovement();
            this.enabled = false;
        }
        weaponInput();
        drawRange();
        changeAccuracy();
        changeWeapon();
        if (Input.GetKeyDown(KeyCode.R) && !firedWeapon && extraAmmo != 0)
            StartCoroutine(reloadWeapon());
        if (currentAmmo <= 0 && !firedWeapon && extraAmmo != 0)
        {
            StartCoroutine(reloadWeapon());
        }
    }

    void changeWeapon()
    {
        currentAmmo = gunInHand.currentAmmo;
        extraAmmo = gunInHand.extraAmmo;
        clipMax = gunInHand.maxAmmo;
        weaponRange = gunInHand.weaponRange;
        weaponCoolDown = gunInHand.weaponCoolDown;

        if (Input.mouseScrollDelta.y > 0)
        {
            if (gunInHand.weapon == weapon.pistol)
            {
                foreach(gunValue weapon in weaponInventory)
                {
                    if (weapon.weapon == global::weapon.rifle)
                    {
                        pistolHands.SetActive(false);
                        rifleHands.SetActive(true);
                        gunInHand = weapon;
                        return;
                    }
                }
            }
            if (gunInHand.weapon == weapon.rifle)
            {
                foreach (gunValue weapon in weaponInventory)
                {
                    if (weapon.weapon == global::weapon.pistol)
                    {
                        pistolHands.SetActive(true);
                        rifleHands.SetActive(false);
                        gunInHand = weapon;
                        return;
                    }
                }
            }
        }

    }
    void weaponInput()
    {
        orgin = (playerCamera.position) - crouchDiff;
        direction = playerCamera.forward;
        if (Input.GetMouseButton(0) && !firedWeapon && currentAmmo > 0)
        {
            StartCoroutine(fireWeapon());
        }
    }
    void drawRange()
    {
        Debug.DrawRay(orgin, direction * gunInHand.weaponRange, Color.red);
        if (Physics.Raycast(orgin, direction, out RaycastHit hit, gunInHand.weaponRange))
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
        firedWeapon = true;
        EventCore.EV_playerReload.Invoke();
        AudioSource.PlayOneShot(gunReloadAC);
        int _newAmmo = Mathf.Clamp(gunInHand.extraAmmo, 0, gunInHand.maxAmmo);
        int usedAmmo = _newAmmo - gunInHand.currentAmmo;
        yield return new WaitForSeconds(2);
        gunInHand.currentAmmo = _newAmmo;
        gunInHand.extraAmmo -= usedAmmo;
        firedWeapon = false;
    }
    IEnumerator fireWeapon()
    {
        RaycastHit hit;
        firedWeapon = true;
        if (gunInHand.weapon == weapon.rifle)
        {
            AudioSource.PlayOneShot(rifleFireAC[Random.Range(0, rifleFireAC.Length)]);
        }
        else {
            AudioSource.PlayOneShot(gunShotAC);
        }
        gunInHand.currentAmmo--;
        EventCore.EV_playerShoot.Invoke();
        // direction based on the accuracy
        if (!isAccuracyLow())
        {
            direction.x += Random.Range(-0.10f, 0.10f);
            direction.y += Random.Range(-0.10f, 0.10f);
        }
        if (Physics.Raycast(orgin, direction, out hit, gunInHand.weaponRange))
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
        yield return new WaitForSeconds(gunInHand.weaponCoolDown);
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
        int valueChange = (int)increaseAmount;
        gunInHand.extraAmmo += valueChange;
        foreach (gunValue _Value in weaponInventory)
        {
            _Value.extraAmmo += valueChange;
        }
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
