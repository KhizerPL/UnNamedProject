using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler
{
    #region privateVariables
  
    bool draggingItem;
    inventory inv;
  
    public GameObject picOfItemHandler;
    GameObject player;
    #endregion

    #region editorVariables

    [SerializeField] inventoryMouseDetect invmd;
    [SerializeField] itemsManager iM;

    #endregion

    #region publicVariables
    [Header("ItemVariables")]
    public Sprite itemIcon;
    public int itemId;
    public string itemType;

    [Header("SlotVariables")]
    public string slotEnviroment;
    public bool empty = true;
    public bool mouseOver;
    public string slotType;
    public bool slotFreezed = false;
    

    #endregion

    private void Awake()
    {
        picOfItemHandler = transform.GetChild(0).gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        inv = player.GetComponent<inventory>();
    }

    public void addItemToSlot(Sprite _itemIcon, int id, string type)
    {
        picOfItemHandler.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        itemIcon = _itemIcon;
        picOfItemHandler.GetComponent<Image>().sprite = itemIcon;
        picOfItemHandler.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        itemId = id;
        itemType = type;
        empty = false;
    }

   public void clearSlot()     
    {
        empty = true;
        itemId = 0;
        itemIcon = null;
        itemType = "";
        picOfItemHandler.GetComponent<Image>().sprite = null;
        picOfItemHandler.GetComponent<Image>().color = new Color(1, 1, 1, 0);

    }

    void dropItem()
    {
        clearSlot();
        iM.spawnItem(itemId, new Vector3(player.transform.position.x , player.transform.position.y, player.transform.position.z),player.transform.rotation);
        
       
    }
    


    public void OnDrag(PointerEventData eventData)
    {
      if(!empty && !slotFreezed)
      {
         draggingItem = true;
         picOfItemHandler.transform.SetParent(transform.parent);
         picOfItemHandler.transform.position = Input.mousePosition;
        
      }
        
        

    }
    void itemTransfer(GameObject slot)
    {     
        slot.GetComponent<slot>().addItemToSlot(itemIcon, itemId,itemType);
       
        clearSlot();

    }

   


    


    public void OnEndDrag(PointerEventData eventData)
    {       
        if (draggingItem)
        {
            picOfItemHandler.transform.SetParent(transform);
            if (slotEnviroment == "inventory")
            {


                for (int i = 0; i < inv.playerSlots.Length;)
                {
                    if (inv.playerSlots[i].GetComponent<slot>().mouseOver && inv.playerSlots[i].GetComponent<slot>().empty)
                    {
                        itemTransfer(inv.playerSlots[i]);
                        draggingItem = false;
                        inv.hb.updateHotBar();
                        return;
                    }
                    else
                    {
                        i++;
                    }

                }
                for (int i = 0; i < inv.equipableSlots.Length;)
                {
                    if (inv.equipableSlots[i].GetComponent<slot>().mouseOver && inv.equipableSlots[i].GetComponent<slot>().empty)
                    {
                        if (itemType == inv.equipableSlots[i].GetComponent<slot>().slotType)
                        {
                            itemTransfer(inv.equipableSlots[i]);
                            draggingItem = false;
                            return;
                        }

                        else
                        {
                            picOfItemHandler.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                            draggingItem = false;
                            return;
                        }
                    }
                    else
                    {
                        i++;
                    }

                }
                for (int i = 0; i < inv.hotBarSlots.Length;)
                {
                    if (inv.hotBarSlots[i].GetComponent<slot>().mouseOver && inv.hotBarSlots[i].GetComponent<slot>().empty && itemType == inv.hotBarSlots[i].GetComponent<slot>().slotType)
                    {
                        itemTransfer(inv.hotBarSlots[i]);
                        inv.hb.updateHotBar();
                        draggingItem = false;
                        return;
                    }
                    i++;

                }

                if (!invmd.mouseOver)
                {
                    dropItem();
                    inv.hb.updateHotBar();
                }
                else
                {
                    picOfItemHandler.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                    draggingItem = false;

                }
            }          
            else if(slotEnviroment == "chest")
            {
                for (int i = 0; i < inv.cI.chestSlots.Length;)
                {
                    if (inv.cI.chestSlots[i].GetComponent<slot>().mouseOver && inv.cI.chestSlots[i].GetComponent<slot>().empty)
                    {
                        itemTransfer(inv.cI.chestSlots[i]);
                        draggingItem = false;
                        return;
                    }
                    else
                    {
                        i++;
                    }

                }
                for(int i = 0; i < inv.cI.playerSlots.Length;)
                {
                    if (inv.cI.playerSlots[i].GetComponent<slot>().mouseOver && inv.cI.playerSlots[i].GetComponent<slot>().empty)
                    {
                        itemTransfer(inv.cI.playerSlots[i]);
                        draggingItem = false;
                        return;
                    }
                    else
                    {
                        i++;
                    }
                  
                }
                picOfItemHandler.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                draggingItem = false;


            }           
            else if(slotEnviroment == "craftingTable")
            {
                for (int i = 0; i < inv.craft.playerSlots.Length;)
                {
                    if (inv.craft.playerSlots[i].GetComponent<slot>().empty && inv.craft.playerSlots[i].GetComponent<slot>().mouseOver && !inv.craft.playerSlots[i].GetComponent<slot>().slotFreezed)
                    {
                        itemTransfer(inv.craft.playerSlots[i]);
                        inv.craft.craftingSlotsUpdate();
                        draggingItem = false;
                        return;
                    }
                    else
                    {
                        i++;
                    }

                }

                for (int i = 0; i < inv.craft.craftingSlots.Length;)
                {
                    if (inv.craft.craftingSlots[i].GetComponent<slot>().empty && inv.craft.craftingSlots[i].GetComponent<slot>().mouseOver && !inv.craft.craftingSlots[i].GetComponent<slot>().slotFreezed)
                    {
                        itemTransfer(inv.craft.craftingSlots[i]);
                        inv.craft.craftingSlotsUpdate();
                        draggingItem = false;
                        return;
                    }
                    else
                    {
                        i++;
                    }

                }

                picOfItemHandler.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                draggingItem = false;




            }

        }

    }

    public void OnPointerEnter(PointerEventData eventdata)
    {
        mouseOver = true;      
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }


}
