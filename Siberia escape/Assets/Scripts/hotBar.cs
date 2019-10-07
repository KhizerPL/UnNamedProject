using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotBar : MonoBehaviour
{
    public GameObject[] hotBarSlots;
    [SerializeField] GameObject[] hotBarSlotsInventory;
    [SerializeField] onPlayerHand playerHand;


    public void updateHotBar()
    {
        for(int i = 0; i < hotBarSlotsInventory.Length;)
        {
            if (!hotBarSlotsInventory[i].GetComponent<slot>().empty)
            {
                hotBarSlots[i].GetComponent<slot>().addItemToSlot(hotBarSlotsInventory[i].GetComponent<slot>().itemIcon, hotBarSlotsInventory[i].GetComponent<slot>().itemId, hotBarSlotsInventory[i].GetComponent<slot>().itemType);
            }
            else
            {
                hotBarSlots[i].GetComponent<slot>().clearSlot();
            }
            i++;
        }
        playerHand.updatePlayerHand();

    }


}
