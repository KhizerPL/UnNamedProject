using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jobManager : MonoBehaviour
{
    public inventory inv;

    [SerializeField] dayAndNight dan;
    [SerializeField] rocks r;


   




    private void Update()
    {
       if(dan.minutes == 0)
        {

            r.rocksCollected = 0;
            r.endedDailyWork = false;

        }


    }




}
