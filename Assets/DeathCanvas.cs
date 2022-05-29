using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI text;
    void Start()
    {
        text.text = Stats.Instance.alienKillContainer.GetValue().ToString();
    }
}
