using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    #region Components

    GameObject DoorOpen;

    #endregion

    [SerializeField] TextMeshProUGUI Tooltip;

    void Start()
    {
        DoorOpen = transform.GetChild(0).gameObject;

        DoorOpen.SetActive(false);
    }

    public void OpenDoor(GameManager manager)
    {
        DoorOpen.SetActive(true);
        Tooltip.text = manager.isInterviewInProgress ? "Demander de partir..." : "Accueillir la personne suivante";
    }

    public void CloseDoor()
    {
        DoorOpen.SetActive(false);
    }

    public void OnClick()
    {
        Tooltip.text = Tooltip.text == "Demander de partir..." ? "Accueillir la personne suivante" : "Demander de partir...";
    }
}
