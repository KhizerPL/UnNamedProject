using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
   
    public enum onScreen {nothing,inventory,chest};

    public onScreen screen;

    void Awake()
    {
        screen = onScreen.nothing;

    }

}
