using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class inventoryMouseDetect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

   public bool mouseOver;


    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }

}
