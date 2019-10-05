using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heatManager : MonoBehaviour
{
    [SerializeField] Animator[] coldAnim;
    [SerializeField] PlayerScript PS;

    public float warmingUpSpeed;
    public float freezingSpeed;

   public enum playerWarmState {warmingUp,freezing };
   public playerWarmState playerWarm;


    void animationUpdate()
    {
        if (playerWarm == playerWarmState.freezing)
        {
            
            if(PS.playerHeat < 80 && PS.playerHeat > 60)
            {
                coldAnim[0].ResetTrigger("warmUp");
                coldAnim[0].SetTrigger("freeze");

            }
            else if(PS.playerHeat < 60 && PS.playerHeat > 30)
            {
                coldAnim[1].ResetTrigger("warmUp");
                coldAnim[1].SetTrigger("freeze");

            }
            else if (PS.playerHeat < 30 && PS.playerHeat > 0)           
            {
                coldAnim[2].ResetTrigger("warmUp");
                coldAnim[2].SetTrigger("freeze");

            }


        }
        if (playerWarm == playerWarmState.warmingUp)
        {
            if (PS.playerHeat < 30 && PS.playerHeat > 0)
            {
                coldAnim[2].ResetTrigger("freeze");
                coldAnim[2].SetTrigger("warmUp");

            }
            else if(PS.playerHeat < 60 && PS.playerHeat > 30)
            {
                coldAnim[1].ResetTrigger("freeze");
                coldAnim[1].SetTrigger("warmUp");

            }
            else if(PS.playerHeat < 80 && PS.playerHeat > 60)
            {
                coldAnim[0].ResetTrigger("freeze");
                coldAnim[0].SetTrigger("warmUp");

            }


        }


    }

    void LateUpdate()
    {
        animationUpdate();
    }

    void Update()
    {
       

        if(playerWarm == playerWarmState.warmingUp)
        {
            if (PS.playerHeat < 100)
            {

                PS.playerHeat += warmingUpSpeed * Time.deltaTime;

            }

        }
        else if(playerWarm == playerWarmState.freezing)
        {
            if (PS.playerHeat > 0)
            {

                PS.playerHeat -= freezingSpeed * Time.deltaTime;

            }

        }

    }


}
