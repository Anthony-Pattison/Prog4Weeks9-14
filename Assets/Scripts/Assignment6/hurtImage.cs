using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class hurtImage : MonoBehaviour
{
    Image hurtImageUI;
    eventCore EventCore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hurtImageUI = gameObject.GetComponent<Image>();
		EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        EventCore.playerDamage.AddListener(startFlashing);
    }

    void startFlashing(float _arg)
    {
        StartCoroutine(flashDamage());
    }
    IEnumerator flashDamage()
    {
        Color currentImageColor = hurtImageUI.color;
        float changeColorAmount = 0.25f;
        currentImageColor.a = changeColorAmount;
        hurtImageUI.color = currentImageColor;

        while (changeColorAmount > 0)
        {
            changeColorAmount -= 0.02f;
            currentImageColor.a = changeColorAmount;
            hurtImageUI.color = currentImageColor;
            yield return new WaitForSeconds(0.15f);
        }
    }
}
