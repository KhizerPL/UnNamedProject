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
    public Sprite itemIcon;
    public bool empty = true;
    public bool mouseOver;
    public string slotType;
    public int itemId;
    public string itemType;

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
        itemType = null;
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
      if(!empty)
      {
         draggingItem = true;
         picOfItemHandler.transform.SetParent(transform.parent);
         picOfItemHandler.transform.position = Input.mousePosition;
        
      }
        
        

    }
    void itemTransaction(GameObject slot)
    {     
        slot.GetComponent<slot>().addItemToSlot(itemIcon, itemId,itemType);
       
        clearSlot();

    }

   


    public void OnEndDrag(PointerEventData eventData)
    {       
        if (draggingItem)
        {
            picOfItemHandler.transform.SetParent(transform);
            for (int i = 0; i < inv.slots.Length;)
            {
                if (inv.slots[i].GetComponent<slot>().mouseOver && inv.slots[i].GetComponent<slot>().empty)
                {                 
                        if(inv.slots[i].GetComponent<slot>().slotType != "normal")
                        {
                            if(itemType == inv.slots[i].GetComponent<slot>().slotType)
                            {
                                itemTransaction(inv.slots[i]);
                              
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
                            itemTransaction(inv.slots[i]);                        
                            draggingItem = false;
                            return;

                        }                        
                }
                else
                {
                    i++;
                }
          
            }
            if(!invmd.mouseOver)
            {
                dropItem();
            }
            else
            {
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
