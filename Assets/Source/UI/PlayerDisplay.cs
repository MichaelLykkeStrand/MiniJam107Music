using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] private HealthContainer healthContainer;
    [SerializeField] private CurrencyContainer currencyContainer;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI currencyText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
        healthContainer.OnChange += UpdateUI;
        currencyContainer.OnChange += UpdateUI;
    }


    void UpdateUI()
    {
        healthText.text = healthContainer.GetValue().ToString();
        currencyText.text = currencyContainer.GetValue().ToString();
    }
}
