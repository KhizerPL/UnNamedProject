using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{

    [SerializeField] string name;
    public dialogues _dialogues;
    public bool isAbleToTrade;
    public int  firstItemToTrade;
    public int  secondItemToTrade;
    public int  tradeResult;
    public float height;

    [SerializeField] GameObject neck;



   public IEnumerator smoothLookAt(Vector3 player, float dur)
    {
        float t = 0f;
        while (t < dur)
        {
            t += Time.deltaTime;
            float factor = t / dur;

            Quaternion targetRotation = Quaternion.LookRotation(player - neck.transform.position);

            neck.transform.localRotation = Quaternion.Slerp(neck.transform.rotation, targetRotation, factor * Time.deltaTime);
            yield return null;
        }

    }








}
