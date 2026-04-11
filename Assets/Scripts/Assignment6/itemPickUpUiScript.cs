using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class upgradeUiRef
{
    public Image iconImage;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI contentText;
}

public class itemPickUpUiScript : MonoBehaviour
{
    public GameObject uiHolder;
    public upgradeUiRef upgradeUiRef;
    eventCore EventCore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventCore = GameObject.Find("EventCore").GetComponent<eventCore>();
        EventCore.EV_upgradePickUp.AddListener(setUpUi);
    }


    void setUpUi(onScreenText _currentText)
    {
        uiHolder.SetActive(true);
        upgradeUiRef.iconImage.sprite = _currentText.showImageSprite;
        upgradeUiRef.titleText.text = _currentText.titleText;
        upgradeUiRef.contentText.text = _currentText.discriptionText;
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Time.timeScale = 1.0f;
            uiHolder.SetActive(false);
        }
    }
}
