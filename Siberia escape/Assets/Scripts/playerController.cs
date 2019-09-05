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
    }


    void movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

<<<<<<< Updated upstream
        transform.position += Camera.main.transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput)) * Time.deltaTime * speed;
=======
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);

        transform.Translate(moveDirection * Time.deltaTime * speed, Space.Self);


        


>>>>>>> Stashed changes

       

      
    }

    void mouseLook()
    {
        rotX += Input.GetAxis("Mouse X") * sensitivity;
        rotY += Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -80, 80);
<<<<<<< Updated upstream
        Camera.main.transform.localEulerAngles = new Vector3(-rotY, rotX,0);
=======
        Camera.main.transform.eulerAngles = new Vector3(-rotY, rotX,0);
       
        
>>>>>>> Stashed changes
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
