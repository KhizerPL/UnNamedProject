﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
   public float speed;
   public float sensitivity;
    public bool movementAndLookEnabled;
    public bool mouseVisibleAndUnlocked;
    public bool useGravity;
    public bool isPlayerWalking;
  

    float rotX = 0F;
    float rotY = 0f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");


      

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        moveDirection = transform.TransformDirection(moveDirection);      
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);

        moveDirection.y = 0;
        transform.localPosition += (moveDirection * Time.deltaTime * speed);

        if (horizontalInput != 0)
        {
            isPlayerWalking = true;
        }
        else if (verticalInput != 0)
        {
            isPlayerWalking = true;
        }
        else
        {
            isPlayerWalking = false;
        }
        




       

      
    }

    void mouseLook()
    {
        rotX += Input.GetAxis("Mouse X") * sensitivity;
        rotY += Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -80, 80);

      

        Camera.main.transform.eulerAngles = new Vector3(-rotY, rotX,0);
       
        

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
        else
        {
            isPlayerWalking = false;
        }

        if(useGravity)
        {
            rb.useGravity = true;

        }
        else if(!useGravity)
        {
            rb.useGravity = false;
        }

    }

}
