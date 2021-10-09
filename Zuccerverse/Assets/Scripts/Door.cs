using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    #region Components

    GameObject DoorOpen;

    #endregion

    void Start()
    {
        DoorOpen = transform.GetChild(0).gameObject;
        DoorOpen.SetActive(false);
    }

    public void OpenDoor()
    {
        DoorOpen.SetActive(true);
    }

    public void CloseDoor()
    {
        DoorOpen.SetActive(false);
    }

    public void ClickOnDoor()
    {
        //...
    }
}
