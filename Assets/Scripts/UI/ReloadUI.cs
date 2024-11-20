using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReloadUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI reloadingText;
    [SerializeField] private TextMeshProUGUI ammoAmountText;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private Image bulletImage;

    [SerializeField] private Shooting _shooting;

    private void Awake()
    {
        _shooting = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
    }

    private void Update()
    {
        if(!_shooting.isReloading)
        {
            ActivateReloadUI(true);
            reloadingText.gameObject.SetActive(false);
            ammoAmountText.text = _shooting.ammoAmount.ToString() + "x";
        }
        else
        {
            ActivateReloadUI(false);
            reloadingText.gameObject.SetActive(true);
        }
    }

    private void ActivateReloadUI(bool activate)
    {
        if(activate)
        {
            ammoAmountText.gameObject.SetActive(true);
            ammoText.gameObject.SetActive(true);
            bulletImage.gameObject.SetActive(true);
        }
        else
        {
            ammoAmountText.gameObject.SetActive(false);
            ammoText.gameObject.SetActive(false);
            bulletImage.gameObject.SetActive(false);
        }
    }
}
