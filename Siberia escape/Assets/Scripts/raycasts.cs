using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasts : MonoBehaviour
{
    GameManager GM;


    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Global").GetComponent<GameManager>();
    }


    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.GetComponent<npc>())
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                   StartCoroutine(GM._npcInteraction.interactionWithNPC(hit.transform));
                }
             
            }
            else if (hit.transform.GetComponent<ladder>())
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<ladder>().goOnLadder();
                }

            }




        }



    }


}
