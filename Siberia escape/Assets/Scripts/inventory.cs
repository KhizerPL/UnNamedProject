using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class inventory : MonoBehaviour
{

    public hotBar hb;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] Transform playerSlotsHandler;
    [SerializeField] Transform hotbarSlotsHandler;
    [SerializeField] Transform equipableSlotsHandler;
    public playerController pC;
    public Text itemNameOverlay;
    [SerializeField] GameObject inventoryPopOut;
    public UiManager UI;
    public crafting craft;
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
        hotBarSlots = new GameObject[hotbarSlotsHandler.childCount];
        for (int i = 0; i < hotbarSlotsHandler.childCount; i++)
        {
            hotBarSlots[i] = hotbarSlotsHandler.GetChild(i).gameObject;
        }



    }

   public Transform slotWithItem(int id)
    {
        for(int i = 0; i < playerSlots.Length;)
        {
            if(playerSlots[i].GetComponent<slot>().itemId == id)
            {
                return playerSlots[i].transform;
            }
            i++;
        }
        return null;
    }

        


    private void Start()
    {
        assignSlots();
        if(inventoryPanel.active)
        {
            inventoryPanel.SetActive(false);
        }
        else
        {
            inventoryPanel.SetActive(true);
            inventoryPanel.SetActive(false);
        }

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
   public GameObject returnFreeSlot()
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


    public void popOutSomething(string text, Color color)
    {
        inventoryPopOut.GetComponent<Animator>().SetTrigger("popOut");
        inventoryPopOut.GetComponent<Text>().color = color;
        inventoryPopOut.GetComponent<Text>().text = text;

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



   public void addItem(Transform item)
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
            else if (hit.transform.GetComponent<craftingTable>() && Vector3.Distance(this.transform.position, hit.transform.position) < 15)
            {
                itemNameOverlay.text = "Crafting Table";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (UI.screen == UiManager.onScreen.nothing)
                    {
                        hit.transform.GetComponent<craftingTable>().open();
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
