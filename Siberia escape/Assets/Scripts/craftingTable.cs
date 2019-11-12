using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craftingTable : MonoBehaviour
{
     crafting craft;


   void Start()
    {
        craft = GameObject.FindGameObjectWithTag("Global").GetComponent<crafting>();

    }



    public void open()
    {
        craft.open();
    }


}
