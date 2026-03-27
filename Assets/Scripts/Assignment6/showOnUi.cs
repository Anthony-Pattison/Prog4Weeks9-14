using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class showOnUi : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    playerWeapon weaponScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weaponScript = GetComponent<playerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
    }

    void updateUI()
    {
        ammoText.text = $"{weaponScript.currentAmmo}/{weaponScript.extraAmmo}";
    }
}
