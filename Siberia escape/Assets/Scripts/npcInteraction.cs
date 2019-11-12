using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcInteraction : MonoBehaviour
{

    GameManager GM;

   

    Transform npcPlayerIsTalkingTo;
    
    IEnumerator smoothLookAt(Vector3 objPos, float dur)
    {
        float t = 0f;
        while (t < dur)
        {
            t += Time.deltaTime;
            float factor = t / dur;

            Quaternion targetRotation = Quaternion.LookRotation(objPos - Camera.main.transform.position);

            Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, targetRotation, factor * Time.deltaTime);
            yield return null;
        }

    }
   
    public void tradeWithNpc()
    {
        GM._UiManager.showNpcTradePanel();
        GM._NPCtradeSystem.setupTradePanel(npcPlayerIsTalkingTo);

        
    }
    public void endInteractionWithNPC()
    {
        npcPlayerIsTalkingTo = null;
        GM._playerController.movementAndLookEnabled = true;
        GM._playerController.mouseVisibleAndUnlocked = false;
        GM._UiManager.hideNPCpanel();

    }
    public IEnumerator interactionWithNPC(Transform npc)
    {
        npcPlayerIsTalkingTo = npc;
        GM._playerController.movementAndLookEnabled = false;
        GM._playerController.mouseVisibleAndUnlocked = true;
        StartCoroutine(smoothLookAt(new Vector3(npc.transform.position.x, npc.transform.position.y + npc.GetComponent<npc>().height, npc.transform.position.z), 2f));
        //  StartCoroutine(npc.GetComponent<npc>().smoothLookAt(transform.position, 1.5f));
        yield return new WaitForSeconds(2.5f);
        GM._UiManager.showNPCpanel();

    }
    
    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Global").GetComponent<GameManager>();
    }

}
