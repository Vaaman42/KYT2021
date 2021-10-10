using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Tooltip;
    public void ShowTooltip()
    {
        Tooltip.text = "Recruter";
    }
    public void HideTooltip()
    {
        Tooltip.text = "";
    }
}
