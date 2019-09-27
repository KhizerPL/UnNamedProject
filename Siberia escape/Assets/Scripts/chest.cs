using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public string nameOfChest;
    public item[] items;
  


    void Start()
    {
        items= new item[15];
    }


}
