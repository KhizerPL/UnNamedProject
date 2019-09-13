using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler
{ 

    public int itemId;
    public bool empty = true;
    public GameObject picOfItemHandler;
    inventory inv;
    Sprite itemIcon;
    [SerializeField] inventoryMouseDetect invmd;
    [SerializeField] itemsManager iM;
    public bool mouseOver;
    bool draggingItem;
    GameObject player;
    

    private void Awake()
    {
        picOfItemHandler = transform.GetChild(0).gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        inv = player.GetComponent<inventory>();
    }

    public void addItemToSlot(Sprite _itemIcon, int id)
    {
        picOfItemHandler.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        itemIcon = _itemIcon;
        picOfItemHandler.GetComponent<Image>().sprite = itemIcon;
        picOfItemHandler.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        itemId = id;
        empty = false;
    }

   public void clearSlot()     
    {
        empty = true;
        itemId = 0;
        itemIcon = null;
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
         picOfItemHandler.transform.position = Input.mousePosition;
        
      }
        
        

    }
    void itemTransaction(GameObject slot)
    {     
        slot.GetComponent<slot>().addItemToSlot(itemIcon, itemId);
       
        clearSlot();

    }

   


    public void OnEndDrag(PointerEventData eventData)
    {
        //if outside  of inventory == drop
        if (draggingItem)
        {
            for (int i = 0; i < inv.slots.Length;)
            {
                if (inv.slots[i].GetComponent<slot>().mouseOver && inv.slots[i].GetComponent<slot>().empty)
                {

                    itemTransaction(inv.slots[i]);
                    draggingItem = false;
                    return;
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
