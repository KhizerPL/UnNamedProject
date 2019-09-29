using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class inventory : MonoBehaviour
{
         

    [SerializeField] GameObject inventoryPanel;
    [SerializeField] Transform playerSlotsHandler;
    [SerializeField] Transform hotbarSlotsHandler;
    [SerializeField] Transform equipableSlotsHandler;
    [SerializeField] playerController pC;
    [SerializeField] Text itemNameOverlay;
    [SerializeField] GameObject inventoryPopOut;
    [SerializeField] UiManager UI;
    public chestInteraction cI;


    #region privateVariables

    bool isInventoryOpen;
    public GameObject[] playerSlots;
    public GameObject[] hotBarSlots;
    public GameObject[] equipableSlots;
    #endregion

    void assignSlots()
    {
        playerSlots = new GameObject[playerSlotsHandler.childCount];
        for (int i = 0; i < playerSlotsHandler.childCount; i++)
        {
            playerSlots[i] = playerSlotsHandler.GetChild(i).gameObject;
        }
        equipableSlots = new GameObject[equipableSlotsHandler.childCount];
        for (int i = 0; i < equipableSlotsHandler.childCount; i++)
        {
            equipableSlots[i] = equipableSlotsHandler.GetChild(i).gameObject;
        }



    }


    private void Start()
    {
        assignSlots();
        inventoryPanel.SetActive(false);
    }


    void ToggleInventoryVisibility()
    {
        isInventoryOpen = !isInventoryOpen;

        if (isInventoryOpen) {
            UI.screen = UiManager.onScreen.inventory;
            inventoryPanel.SetActive(true);
            pC.movementAndLookEnabled = false;
            pC.mouseVisibleAndUnlocked = true;
        }
        else {
            UI.screen = UiManager.onScreen.nothing;
            inventoryPanel.SetActive(false);
            pC.movementAndLookEnabled = true;
            pC.mouseVisibleAndUnlocked = false;
        }
    }
    GameObject returnFreeSlot()
    {
        for(int i = 0; i < playerSlots.Length;)
        {
            if(playerSlots[i].GetComponent<slot>().empty) //if empty
            {
                return playerSlots[i];
            }
            else
            {             
                i++;
            }
        }
        return null;    
    }
    void popOutNotEnoughSpace()
    {

        inventoryPopOut.GetComponent<Animator>().SetTrigger("popOut");
        inventoryPopOut.GetComponent<Text>().color = new Color(1, 0, 0, 1);
        inventoryPopOut.GetComponent<Text>().text = "Not enough space";

    }
    void popOutItemAdded()
    {
        inventoryPopOut.GetComponent<Animator>().SetTrigger("popOut");
        inventoryPopOut.GetComponent<Text>().color = new Color(0, 1, 0, 1);
        inventoryPopOut.GetComponent<Text>().text = "Item Added";

    }


    void addItem(Transform item)
    {
        if(returnFreeSlot() != null)
        {
            returnFreeSlot().GetComponent<slot>().addItemToSlot(item.GetComponent<item>().icon, item.GetComponent<item>().id, item.GetComponent<item>().type);
            popOutItemAdded();
            Destroy(item.gameObject);
        }
        else
        {
            popOutNotEnoughSpace();
        }

    }


    void raycast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
       

            if(hit.transform.GetComponent<item>() && Vector3.Distance(this.transform.position, hit.transform.position) < 15)
            {
                itemNameOverlay.text = hit.transform.GetComponent<item>().nameOfItem;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    addItem(hit.transform);             
                }

            }       
            else if (hit.transform.GetComponent<chest>() && Vector3.Distance(this.transform.position, hit.transform.position) < 15)
            {
                itemNameOverlay.text = hit.transform.GetComponent<chest>().nameOfChest;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (UI.screen == UiManager.onScreen.nothing)
                    {
                        cI.open(hit.transform.GetComponent<chest>());
                    }
                }

            }
            else
            {
                itemNameOverlay.text = "";
            }





        }


    }
   

    void Update()
    {
        raycast();

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (UI.screen == UiManager.onScreen.inventory)
            {
                ToggleInventoryVisibility();
            }
            else if(UI.screen == UiManager.onScreen.nothing)
            {
                ToggleInventoryVisibility();
            }

        }




    }


   

}
