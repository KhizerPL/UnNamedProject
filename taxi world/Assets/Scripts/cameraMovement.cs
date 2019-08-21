using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    Vector3 touchStart;
    Vector3 mousePos;
    public float sensivity;

    void Update()
    {

        mousePos = Input.mousePosition;
        mousePos.z = 1;

        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(mousePos);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(mousePos);
            Camera.main.transform.localPosition += new Vector3(direction.x, 0, direction.z);
        }





    }
}
