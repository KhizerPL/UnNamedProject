using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public string nameOfChest;
    public GameObject slotHandler;
   public Animator anim;
    public item[] items;
 

    void assignItemsScript()
    {
        items = new item[15];
        for(int i = 0; i < 15;)
        {
            items[i] = slotHandler.transform.GetChild(i).GetComponent<item>();
            i++;
        }


    }

    void Start()
    {
        assignItemsScript();


    }


}

