using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{

    #region publicVariables

    int health;
    int hunger;
    int hydration;
    int cash;

    #endregion

    #region editorVariables

    [SerializeField] GameObject inventoryPanel;

    #endregion

    #region privateVariables
    bool isInventoryOpen;
    GameObject[] slots;

    #endregion

    void ToggleInventoryVisibility()
    {
        isInventoryOpen = !isInventoryOpen;

        if (isInventoryOpen) {
            inventoryPanel.SetActive(true);
    
        }
        else {
            inventoryPanel.SetActive(false);

        }
          





        

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventoryVisibility();
        }



    }

}
