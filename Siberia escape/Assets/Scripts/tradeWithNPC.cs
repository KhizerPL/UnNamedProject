using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tradeWithNPC : MonoBehaviour
{

    [SerializeField] GameObject firstSlot;
    [SerializeField] GameObject secondSlot;
    [SerializeField] GameObject result;
    [SerializeField] GameObject tradeButton;
    [SerializeField] GameObject notAvaibleButton;
    GameManager GM;
    Transform npcPlayerIsTalkingTo;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Global").GetComponent<GameManager>();
    }
    public void tradeButtonFunc()
    {
        GM._invnetory.slotWithItem(npcPlayerIsTalkingTo.GetComponent<npc>().firstItemToTrade).GetComponent<slot>().clearSlot();
        GM._invnetory.slotWithItem(npcPlayerIsTalkingTo.GetComponent<npc>().secondItemToTrade).GetComponent<slot>().clearSlot();
        GameObject freeSlot = GM._invnetory.returnFreeSlot();
        freeSlot.GetComponent<slot>().addItemToSlot(GM._itemsManager.itemsPrefabs[npcPlayerIsTalkingTo.GetComponent<npc>().tradeResult - 1].GetComponent<item>().icon, GM._itemsManager.itemsPrefabs[npcPlayerIsTalkingTo.GetComponent<npc>().tradeResult - 1].GetComponent<item>().id, GM._itemsManager.itemsPrefabs[npcPlayerIsTalkingTo.GetComponent<npc>().tradeResult - 1].GetComponent<item>().type);

        if (GM._invnetory.slotWithItem(npcPlayerIsTalkingTo.GetComponent<npc>().firstItemToTrade) != null && GM._invnetory.slotWithItem(npcPlayerIsTalkingTo.GetComponent<npc>().secondItemToTrade) != null)
        {
            tradeButton.SetActive(true);
            notAvaibleButton.SetActive(false);
        }
        else
        {
            tradeButton.SetActive(false);
            notAvaibleButton.SetActive(true);
        }
    }
    public void setupTradePanel(Transform npc)
    {
        npcPlayerIsTalkingTo = npc;
        for(int i = 0; i < GM._itemsManager.itemsPrefabs.Length;)
        {
            if(npc.GetComponent<npc>().firstItemToTrade - 1 == i)
            {
                firstSlot.GetComponent<slot>().addItemToSlot(GM._itemsManager.itemsPrefabs[i].GetComponent<item>().icon, GM._itemsManager.itemsPrefabs[i].GetComponent<item>().id, GM._itemsManager.itemsPrefabs[i].GetComponent<item>().type);
                break;

            }
            i++;

        }
        for (int i = 0; i < GM._itemsManager.itemsPrefabs.Length;)
        {
            if (npc.GetComponent<npc>().secondItemToTrade - 1 == i)
            {
                secondSlot.GetComponent<slot>().addItemToSlot(GM._itemsManager.itemsPrefabs[i].GetComponent<item>().icon, GM._itemsManager.itemsPrefabs[i].GetComponent<item>().id, GM._itemsManager.itemsPrefabs[i].GetComponent<item>().type);
                break;

            }
            i++;

        }
        for (int i = 0; i < GM._itemsManager.itemsPrefabs.Length;)
        {
            if (npc.GetComponent<npc>().tradeResult - 1 == i)
            {
                result.GetComponent<slot>().addItemToSlot(GM._itemsManager.itemsPrefabs[i].GetComponent<item>().icon, GM._itemsManager.itemsPrefabs[i].GetComponent<item>().id, GM._itemsManager.itemsPrefabs[i].GetComponent<item>().type);
                break;

            }
            i++;

        }
        if(GM._invnetory.slotWithItem(npc.GetComponent<npc>().firstItemToTrade) != null && GM._invnetory.slotWithItem(npc.GetComponent<npc>().secondItemToTrade) != null)
        {
            tradeButton.SetActive(true);
            notAvaibleButton.SetActive(false);

        }
        else
        {
            tradeButton.SetActive(false);
            notAvaibleButton.SetActive(true);
        }



    }

}
