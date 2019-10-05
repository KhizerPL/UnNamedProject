using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heatSpot : MonoBehaviour
{

   [SerializeField] heatManager h;

    private void Start()
    {
        h = GameObject.FindGameObjectWithTag("Global").GetComponent<heatManager>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            h.playerWarm = heatManager.playerWarmState.warmingUp;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            h.playerWarm = heatManager.playerWarmState.freezing;
        }

    }

}
