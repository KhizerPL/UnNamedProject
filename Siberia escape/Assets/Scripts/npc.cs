using System.Collections;
using UnityEngine;

public class npc : MonoBehaviour
{

    [SerializeField] string name;
    public bool isAbleToTrade;
    public int firstItemToTrade;
    public int secondItemToTrade;
    public int tradeResult;
    public float height;

    [SerializeField] GameObject neck; //AsPrus: jeśli potrzebne ci to tylko po to żeby korzystać z komponentu "Transform" to zamiast pisać "GameObject" napisz "Transform" - operacje na tym obiekcie będą lżejsze, a kod odrobinę czytelniejszy



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
