using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class pileOfRocks : MonoBehaviour
{
    [SerializeField] rocks r;
    [SerializeField] Text centerText;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.transform.GetComponent<pileOfRocks>())
            {
                centerText.text = r.rocksCollected.ToString() + "/" + "5";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    r.addRockTopile();

                }


            }
            else
            {
                centerText.text = "";
            }
                

        }
        else
        {
            centerText.text = "";
        }


    }


}

