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

    #region privateVariables

    bool isInventoryOpen;
    GameObject[] slots;

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

    void raycast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);

            if(hit.transform.GetComponent<item>())
            {
                itemNameOverlay.text = hit.transform.GetComponent<item>().nameOfItem;
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
