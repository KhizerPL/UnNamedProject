using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPlayerHand : MonoBehaviour
{

    [SerializeField] hotBar bar;
    [SerializeField] playerController pC;
    [SerializeField] Animator armsAnimator;

    public int choosenSlot = 0;

    bool allowSwing = true;
    
    

    



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
    
    IEnumerator pickaxeSwing()
    {
        armsAnimator.SetBool("mouseLeftClick", true);
        allowSwing = false;
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray,out hit,10f))
        {
           if(hit.transform.GetComponent<entity>())
            {
                hit.transform.GetComponent<entity>().hp = hit.transform.GetComponent<entity>().hp - 10;
            }

        }
        yield return new WaitForSeconds(1.042f);
        allowSwing = true;
        armsAnimator.SetBool("mouseLeftClick", false);
    }


    void itemUse()
    {
        if(bar.hotBarSlots[choosenSlot - 1].GetComponent<slot>().itemId == 3) //pickaxe usage
        {
            if (allowSwing)
            {
                StartCoroutine(pickaxeSwing());
            }
        }



    }


    void checkInput()
    {
        if(Input.GetMouseButton(0))
        {
            itemUse();
        }



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
