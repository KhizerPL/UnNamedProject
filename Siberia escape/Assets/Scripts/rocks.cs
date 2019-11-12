using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocks : MonoBehaviour
{
    entity e;
    [HideInInspector]
    public jobManager jM;

    [SerializeField] Transform rock;
   
    [HideInInspector]
    public int rocksCollected;

    public bool endedDailyWork;

    void Start()
    {
        e = GetComponent<entity>();
        jM = GameObject.FindGameObjectWithTag("Global").GetComponent<jobManager>();
      
    }

    void addRock()
    {
        jM.inv.addItem(rock);
    }
    public void addRockTopile()
    {
        if(jM.inv.slotWithItem(4) != null)
        {
            jM.inv.slotWithItem(4).GetComponent<slot>().clearSlot();
            rocksCollected += 1;
            jM.inv.popOutSomething("Rock added to pile!", new Color(0, 1, 0, 1));
            if(rocksCollected >= 5)
            {
                endedDailyWork = true;
            }
          
        }
        else
        {
            jM.inv.popOutSomething("You dont have any rocks!", new Color(1, 0, 0, 1));
        }



    }
    private void Update()
    {
        
        if(e.hp <= 0)
        {
            e.hp = 50;
            addRock();

        }



    }

}
