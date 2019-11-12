using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class dayAndNight : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject sun;
    public float cycleTimeInMinutes;

    public float daysPassed;

   public int hours;
   public int minutes;

    bool blendingBack;

    private float cycleTimeInSeconds;

    public Text clockUI;



    float gameSpeed = 1;


    private void Start()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 0);
        RenderSettings.skybox.SetFloat("_Blend", 1);

        cycleTimeInSeconds = cycleTimeInMinutes * 60;

        rotationSpeed = 720 / cycleTimeInSeconds;

       


    }

  
    
    void clockUpdate()
    {
        minutes = Mathf.RoundToInt(RenderSettings.skybox.GetFloat("_Rotation") * 2);

        hours = minutes / 60;

        clockUI.text = hours.ToString() + ":" + (minutes - (hours * 60)).ToString();

    }

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation",RenderSettings.skybox.GetFloat("_Rotation") + (Time.deltaTime * rotationSpeed));
        sun.transform.eulerAngles -= new Vector3(0, Time.deltaTime * rotationSpeed, 0);

        clockUpdate();

        


        if (RenderSettings.skybox.GetFloat("_Rotation") >= 720)
        {
            RenderSettings.skybox.SetFloat("_Rotation", 0);
            RenderSettings.skybox.SetFloat("_Blend", 1);

            daysPassed += 1;
            
        }

        //day comes

        if(RenderSettings.skybox.GetFloat("_Rotation") < 360 && RenderSettings.skybox.GetFloat("_Rotation") > 180 &&  RenderSettings.skybox.GetFloat("_Blend") > 0)
        {
            RenderSettings.skybox.SetFloat("_Blend", RenderSettings.skybox.GetFloat("_Blend") - (Time.deltaTime * 0.01f));

        }



  
        //night comes

        if(RenderSettings.skybox.GetFloat("_Rotation") >= 500 && RenderSettings.skybox.GetFloat("_Blend") < 1)
        {

            RenderSettings.skybox.SetFloat("_Blend", RenderSettings.skybox.GetFloat("_Blend") + (Time.deltaTime * 0.01f));

        }


        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            if(gameSpeed > 1)
            {
                gameSpeed -= 0.25f;
            }


        }


        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            if (gameSpeed < 7)
            {
                gameSpeed += 0.25f;
            }

        }

        Time.timeScale = gameSpeed;

    }



}
