using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowRFD : MonoBehaviour, IPointerClickHandler
{
    public GameObject RFD;
    public void OnPointerClick(PointerEventData eventData)
    {
        RFD.SetActive(true);
    }
}
