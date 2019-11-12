using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    #region uiElements

    [SerializeField] GameObject npcInteractionPanel;
    [SerializeField] GameObject npcTradePanel;

    #endregion


    public enum onScreen {nothing,inventory,chest, craftingTable};

    public onScreen screen;

    void Awake()
    {
        screen = onScreen.nothing;

    }

   public void showNPCpanel()
   {
        npcInteractionPanel.SetActive(true);

   }

    public void showNpcTradePanel()
    {
        npcTradePanel.SetActive(true);
        npcInteractionPanel.SetActive(false);
    }
    public void hideNpcTradePanel()
    {
        npcTradePanel.SetActive(false);
        npcInteractionPanel.SetActive(true);
    }
    public void hideNPCpanel()
    {
        npcInteractionPanel.SetActive(false);

    }

}
