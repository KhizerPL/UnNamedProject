using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestInteraction : MonoBehaviour
{
    bool showedUp;

    [SerializeField] GameObject chestPanel;
    [SerializeField] GameObject chestSlotHandler;
    [SerializeField] GameObject playerSlotHandler;
    [SerializeField] inventory inv;
    [SerializeField] playerController pC;
    [SerializeField] UiManager UI;

    public GameObject[] chestSlots;
    public GameObject[] playerSlots;


    chest actualChest;

    void assignSlots()
    {
        for (int i = 0; i < chestSlotHandler.transform.childCount;)
        {
            chestSlots[i] = chestSlotHandler.transform.GetChild(i).gameObject;
            i++;
        }

        for (int i = 0; i < playerSlotHandler.transform.childCount;)
        {

            playerSlots[i] = playerSlotHandler.transform.GetChild(i).gameObject;
            i++;
        }


    }

    void Start()
    {

        chestSlots = new GameObject[chestSlotHandler.transform.childCount];
        playerSlots = new GameObject[playerSlotHandler.transform.childCount];
        assignSlots();
        chestPanel.SetActive(false);


    }


    void assignItems()
    {
        for (int i = 0; i < actualChest.items.Length;)
        {
            if (actualChest.items[i].id != 0)         // <==============
            {
                chestSlots[i].GetComponent<slot>().addItemToSlot(actualChest.items[i].icon, actualChest.items[i].id, actualChest.items[i].type);
                Debug.Log(i);
            }
            i++;
        }
        for (int i = 0; i < inv.playerSlots.Length;) 
        {
            if (!inv.playerSlots[i].GetComponent<slot>().empty)
            {
                playerSlots[i].GetComponent<slot>().addItemToSlot(inv.playerSlots[i].GetComponent<slot>().itemIcon, inv.playerSlots[i].GetComponent<slot>().itemId, inv.playerSlots[i].GetComponent<slot>().itemType);
            }

            i++;
        }



    }
    private void Update()
    {
        if (showedUp)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {           
                close();
            }

        }

    }

    void itemsUpdate()
    {
        for(int i = 0; i < inv.playerSlots.Length; i++)
        {
            inv.playerSlots[i].GetComponent<slot>().clearSlot();       
        }
        for(int i = 0; i < inv.playerSlots.Length;)
        {
            if(!playerSlots[i].GetComponent<slot>().empty)
            {
                inv.playerSlots[i].GetComponent<slot>().addItemToSlot(playerSlots[i].GetComponent<slot>().itemIcon, playerSlots[i].GetComponent<slot>().itemId, playerSlots[i].GetComponent<slot>().itemType);
            }
            i++;

        }

        //TODO ZAMIENIC NA SKRYPT SLOT
        for(int i = 0; i < chestSlots.Length;)
        {
            actualChest.items[i].id = 0;
            actualChest.items[i].name = null;
            actualChest.items[i].description = null;
            actualChest.items[i].type = null;
            i++;
        }
        for (int i = 0; i < chestSlots.Length;)
        {
            if(!chestSlots[i].GetComponent<slot>().empty)
            {
                actualChest.items[i].id = chestSlots[i].GetComponent<slot>().itemId;
           
                actualChest.items[i].type = chestSlots[i].GetComponent<slot>().itemType;
                actualChest.items[i].icon = chestSlots[i].GetComponent<slot>().itemIcon;

            }

            i++;
        }


    }


    void close()
    {
        
        showedUp = false;
        chestPanel.SetActive(false);
        pC.movementAndLookEnabled = true;
        pC.mouseVisibleAndUnlocked = false;
        itemsUpdate();
        UI.screen = UiManager.onScreen.nothing;
        actualChest = null;

    }


    void itemsInChestClear()
    {
        for(int i = 0; i < chestSlots.Length;)
        {
            chestSlots[i].GetComponent<slot>().clearSlot();
            i++;
        }
        for (int i = 0; i < playerSlots.Length;)
        {
           playerSlots[i].GetComponent<slot>().clearSlot();
            i++;
        }

    }


    public void open(chest ch)
    {
        if (UI.screen == UiManager.onScreen.nothing)
        {
            UI.screen = UiManager.onScreen.chest;
            actualChest = ch;
            showedUp = true;
            chestPanel.SetActive(true);
            pC.movementAndLookEnabled = false;
            pC.mouseVisibleAndUnlocked = true;
            itemsInChestClear();
            assignItems();
        }





    }


}
