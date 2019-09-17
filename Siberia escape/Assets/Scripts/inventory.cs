using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class inventory : MonoBehaviour
{
         

    [SerializeField] GameObject inventoryPanel;
    [SerializeField] Transform slotsHandler;
    [SerializeField] playerController pC;
    [SerializeField] Text itemNameOverlay;
    [SerializeField] GameObject inventoryPopOut;

    #region privateVariables

    bool isInventoryOpen;
    public GameObject[] slots;

    #endregion

    void assignSlots()
    {
        slots = new GameObject[slotsHandler.childCount];
        for (int i = 0; i < slotsHandler.childCount; i++)
        {
            slots[i] = slotsHandler.GetChild(i).gameObject;
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
            inventoryPanel.SetActive(true);
            pC.movementAndLookEnabled = false;
            pC.mouseVisibleAndUnlocked = true;
        }
        else {
            inventoryPanel.SetActive(false);
            pC.movementAndLookEnabled = true;
            pC.mouseVisibleAndUnlocked = false;
        }
    }
    GameObject returnFreeSlot()
    {
        for(int i = 0; i < slots.Length;)
        {
            if(slots[i].GetComponent<slot>().empty) //if empty
            {
                return slots[i];
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
            ToggleInventoryVisibility();
        }




    }


   

}
