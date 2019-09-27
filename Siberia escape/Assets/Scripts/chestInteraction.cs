using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestInteraction : MonoBehaviour
{


    [SerializeField] GameObject chestPanel;
    [SerializeField] GameObject chestSlotHandler;
    [SerializeField] GameObject playerSlotHandler;
    [SerializeField] inventory inv;
    [SerializeField] playerController pC;


    GameObject[] chestSlots;
    GameObject[] playerSlots;

    void assignSlots()
    {
        for (int i = 0; i < chestSlotHandler.transform.childCount;)
        {
            chestSlots[i] = chestSlotHandler.transform.GetChild(i).gameObject;
            i++;
        }

        for(int i = 0; i < playerSlotHandler.transform.childCount;)
        {

            playerSlots[i] = playerSlotHandler.transform.GetChild(i).gameObject;
            i++;
        }


    }

    void Start()
    {

        assignSlots();



        
    }


    void assignItems(chest ch)
    {
        for(int i = 0; i < ch.items.Length;)
        {
            chestSlots[i].GetComponent<slot>().addItemToSlot(ch.items[i].icon, ch.items[i].id, ch.items[i].type);
            i++;
        }
        for (int i = 0; i < inv.slots.Length;)
        {
            if (!inv.slots[i].GetComponent<slot>().empty)
            {
                playerSlots[i].GetComponent<slot>().addItemToSlot(inv.slots[i].GetComponent<slot>().itemIcon, inv.slots[i].GetComponent<slot>().itemId, inv.slots[i].GetComponent<slot>().itemType);
             }
           
            i++;
        }



    }
    public void open(chest ch)
    {
        chestPanel.SetActive(true);
        pC.movementAndLookEnabled = false;
        pC.mouseVisibleAndUnlocked = true;

        assignItems(ch);





    }


}
