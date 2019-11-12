using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crafting : MonoBehaviour
{

    UiManager UI;

    [SerializeField] inventory inv;

    [SerializeField] GameObject craftingInTablePanel;

    [SerializeField] GameObject playerSlotsHandler;

    

    public GameObject[] playerSlots;
    public GameObject[] craftingSlots;

   [SerializeField] itemsManager iM;


   public bool waitingForCraft;



    void assignSlots()
    {
        playerSlots = new GameObject[playerSlotsHandler.transform.childCount];

        for(int i = 0; i < playerSlotsHandler.transform.childCount;)
        {
            playerSlots[i] = playerSlotsHandler.transform.GetChild(i).gameObject;
            i++;
        }


    }

    void assignItems()
    {
        for (int i = 0; i < inv.playerSlots.Length;)
        {
            if (!inv.playerSlots[i].GetComponent<slot>().empty)
            {
                playerSlots[i].GetComponent<slot>().addItemToSlot(inv.playerSlots[i].GetComponent<slot>().itemIcon, inv.playerSlots[i].GetComponent<slot>().itemId, inv.playerSlots[i].GetComponent<slot>().itemType);
            }

            i++;
        }




    }

    void updateInventory()
    {
        for(int i = 0; i < inv.playerSlots.Length;)
        {
            inv.playerSlots[i].GetComponent<slot>().clearSlot();
            i++;
        }


        for(int i = 0; i < inv.playerSlots.Length;)
        {

            if(!playerSlots[i].GetComponent<slot>().empty)
            {
                inv.playerSlots[i].GetComponent<slot>().addItemToSlot(playerSlots[i].GetComponent<slot>().itemIcon, playerSlots[i].GetComponent<slot>().itemId, playerSlots[i].GetComponent<slot>().itemType);

            }
            i++;

        }



    }



    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("Global").GetComponent<UiManager>();

        if (craftingInTablePanel.active)
        {
            craftingInTablePanel.SetActive(false);
        }
        else
        {
            craftingInTablePanel.SetActive(true);
            craftingInTablePanel.SetActive(false);
        }

        assignSlots();

    }

    public void open()
    {
        craftingInTablePanel.SetActive(true);
        UI.screen = UiManager.onScreen.craftingTable;
        inv.pC.mouseVisibleAndUnlocked = true;
        inv.pC.movementAndLookEnabled = false;

        assignItems();
    }

    public void close()
    {   
        UI.screen = UiManager.onScreen.nothing;
        inv.pC.mouseVisibleAndUnlocked = false;
        inv.pC.movementAndLookEnabled =  true;

        updateInventory();

        craftingInTablePanel.SetActive(false);

    }


    public void craftingSlotsUpdate()
    {
        if(waitingForCraft)
        {
            waitingForCraft = false;
            for (int i = 0; i < craftingSlots.Length;)
            {
                craftingSlots[i].GetComponent<slot>().clearSlot();
                i++;
            }
        }


       if(craftingSlots[0].GetComponent<slot>().itemId == 2 && craftingSlots[1].GetComponent<slot>().itemId == 2 && craftingSlots[2].GetComponent<slot>().itemId == 1)
        {
            craftingSlots[3].GetComponent<slot>().addItemToSlot(iM.itemsPrefabs[2].GetComponent<item>().icon, iM.itemsPrefabs[2].GetComponent<item>().id, iM.itemsPrefabs[2].GetComponent<item>().type);
            craftingSlots[3].GetComponent<slot>().slotFreezed = false;
            waitingForCraft = true;
        }
        else
        {
            craftingSlots[3].GetComponent<slot>().clearSlot();
            craftingSlots[3].GetComponent<slot>().slotFreezed = true;
            waitingForCraft = false;
        }



    }

  
    



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && inv.UI.screen == UiManager.onScreen.craftingTable)
        {
            close();
        } 
    }
}
