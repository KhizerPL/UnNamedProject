using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class slot : MonoBehaviour
{
    public int itemId;
    public bool empty = true;
    public GameObject picOfItemHandler;
    Sprite itemIcon;

    private void Awake()
    {
        picOfItemHandler = transform.GetChild(0).gameObject;
    }

    public void addItemToSlot(Sprite itemIcon, int id)
    {
        picOfItemHandler.GetComponent<Image>().sprite = itemIcon;
        picOfItemHandler.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        itemId = id;
        empty = false;


    }
    

}
