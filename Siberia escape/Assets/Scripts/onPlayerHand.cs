using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPlayerHand : MonoBehaviour
{

    [SerializeField] hotBar bar;
    [SerializeField] playerController pC;
    [SerializeField] Animator armsAnimator;

    public int choosenSlot = 0;

   
    
    

    



    public void updatePlayerHand()
    {
        if(choosenSlot == 0)
        {
            armsAnimator.SetInteger("item", 0);
        }    
        else if(bar.hotBarSlots[choosenSlot - 1].GetComponent<slot>().itemId == 3)
        {
            armsAnimator.SetInteger("item", 3);
        }
        else
        {
            armsAnimator.SetInteger("item", 0);
        }


        


    }


    void checkInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(choosenSlot == 1)
            {
                choosenSlot = 0;               
                
            }
            else
            {
                choosenSlot = 1;
            }
            updatePlayerHand();

        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(choosenSlot == 2)
            {
                choosenSlot = 0;
            }
            else
            {
                choosenSlot = 2;
            }
            updatePlayerHand();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (choosenSlot == 3)
            {
                choosenSlot = 0;
            }
            else
            {
                choosenSlot = 3;
            }
            updatePlayerHand();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (choosenSlot == 4)
            {
                choosenSlot = 0;

            }
            else
            {
                choosenSlot = 4;

            }
            updatePlayerHand();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (choosenSlot == 5)
            {

                choosenSlot = 0;

            }
            else
            {
                choosenSlot = 5;
            }
            updatePlayerHand();

        }






    }

    void Update()
    {
        checkInput();
        
        if(pC.isPlayerWalking)
        {
            armsAnimator.SetBool("walking", true);
                
        }
        else
        {
            armsAnimator.SetBool("walking", false);
        }

    }



}
