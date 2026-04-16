using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupOnClick : MonoBehaviour
{
    public GameObject popup;

    public void displayPopup()
    {
        popup.SetActive(true);
    }
}
