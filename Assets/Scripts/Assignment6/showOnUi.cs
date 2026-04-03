using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class showOnUi : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public Slider healthSlider;
    playerWeapon weaponScript;
    playerHealth healthScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weaponScript = GetComponent<playerWeapon>();
        healthScript = GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
    }

    void updateUI()
    {
        ammoText.text = $"{weaponScript.currentAmmo}/{weaponScript.extraAmmo}";
        healthSlider.value = healthScript.playerHeath.value;
    }
}
