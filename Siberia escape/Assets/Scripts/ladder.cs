using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
   public GameManager GM;
   public GameObject player;
   public GameObject upperCollider;
   public GameObject lowerCollider;

    public bool onLadder;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Global").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void goOnLadder()
    {
        onLadder = true;
        GM._playerController.movementAndLookEnabled = false;
        GM._playerController.useGravity = false;
    }


    private void Update()
    {
        if(onLadder)
        {


            if(Input.GetKey(KeyCode.W))  //up
            {
                player.transform.Translate(new Vector3(0, 0, 4) * Time.deltaTime, transform);
                
            }
            else if(Input.GetKey(KeyCode.S)) //down
            {

                player.transform.Translate(new Vector3(0, 0, -4) * Time.deltaTime, transform);

            }

            


        }

    }

}