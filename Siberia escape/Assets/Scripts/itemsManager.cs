using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsManager : MonoBehaviour
{
    public Transform[] itemsPrefabs;
    GameManager GM;


    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Global").GetComponent<GameManager>();
    }

    public void spawnItem(int id, Vector3 position, Quaternion rotation)
    {
        Instantiate(itemsPrefabs[id], position, rotation);
    }

    public void itemUse(int id, slot slot)
    {
        if(id == 1)
        {
            GM._PlayerScript.currentHunger += 10;
            if(GM._PlayerScript.currentHunger > 100)
            {
                GM._PlayerScript.currentHunger = 100;
            }
            slot.clearSlot();
        }

    }

   

}
