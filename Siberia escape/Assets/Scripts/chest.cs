using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public string nameOfChest;

    public item[] items;
 

    void assignItemsScript()
    {
        items = new item[transform.childCount];
        for(int i = 0; i < transform.childCount;)
        {
            items[i] = transform.GetChild(i).GetComponent<item>();
            i++;
        }


    }

    void Start()
    {
        assignItemsScript();


    }


}

