using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Polecam zrobić tutaj singleton

    //public static GameManager Instance;

    //private void Awake()
    //{
    //    Instance = this;
    //}

    //obiekty podpisane jako static mogą być wywoływane "GameManager.Instance" - nie potrzeba tutaj mieć samego obiektu ze sceny, ale akutat tutaj zrobiłem przykład który wskazuje na samego siebie więc można go używać jak referencji do GameManagera więc w innych skryptach można pisać: GameManager.Instance._UiManager i to nam daje referencję do UiManagera - proste prawda? Najlepiej mieć jak najmniej takich rozwiązań (max 5) bo później mogą się mieszać. 
    //static ma jeszcze jedną fajną funkcjonalność, a mianowicie dane zapisane w statycznym obiekcie przechodzą wraz ze zmianą sceny. A więc załóżmy że na scenie "A" zapiszę w statycznym int jakąś wartość i przejdę na scenę "B" to ten int będzie miał tą samą wartość

    public PlayerScript _PlayerScript;
    public inventory _invnetory;
    public playerController _playerController;
    public UiManager _UiManager;
    public tradeWithNPC _NPCtradeSystem;
    public itemsManager _itemsManager;
    public npcInteraction _npcInteraction;
    public dialogueSystem _dialogueSystem;
    

}
