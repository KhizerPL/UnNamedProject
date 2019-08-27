using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
   public float speed;
   public float sensitivity;
    public bool movementAndLookEnabled;
    public bool mouseVisibleAndUnlocked;
   Rigidbody rb;

    float rotX = 0F;
    float rotY = 0f;


    private void Start()
    {   
        rb = GetComponent<Rigidbody>();
        Debug.Log("Current health of player is " + PlayerScript.THIS.CurrentHealth + " or in others " + PlayerScript.THIS.HealthString);
    }


    void movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        transform.position += Camera.main.transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput)) * Time.deltaTime * speed;

       

      
    }

    void mouseLook()
    {
        rotX += Input.GetAxis("Mouse X") * sensitivity;
        rotY += Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -80, 80);
        Camera.main.transform.localEulerAngles = new Vector3(-rotY, rotX,0);
    }
    void Update()
    {
        if(mouseVisibleAndUnlocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (movementAndLookEnabled)
        {
            movement();
            mouseLook();
        }



    }

}
