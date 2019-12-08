using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class dialogueSystem : MonoBehaviour
{
    [SerializeField] Text dialogueTextBox;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] float pauseDuration;
    public dialogues _dialogues;//AsPrus: zamień public na [SerializeField], a w definicji klasy dodaj [System.Serializable]
    GameManager GM;
    bool isTalking;
    public int placeInDialogue;
    public State dialogueState;
    public enum State {nothing,Writing,waitingForPlayerInput,pause};
    string writtenSentence;
    float tPause;

    IEnumerator writeText(string sentence, Text place,float delay)
    {
        place.text = "";
        writtenSentence = sentence;
       
        for (int i = 0; i < sentence.Length; i++)
        {
          
            place.text += sentence[i];
            yield return new WaitForSeconds(delay);
             
        }
        dialogueState = State.pause;
        tPause = 0;
    }
   
    public void startConversation(npc _npc)
    {
        //_dialogues = _npc._dialogues; //AsPrus: error here
        isTalking = true;
        dialogueBox.SetActive(true);
        placeInDialogue = 0;
        dialogueState = State.Writing;
        StartCoroutine(writeText(_dialogues.sentences[placeInDialogue], dialogueTextBox, 0.03f));
    }


    void skip()
    {
       

    }

    void Update()
    {

        if(isTalking)
        {
            if(Input.anyKeyDown)
            {
                skip();
            }


        }


        if(dialogueState == State.pause)
        {
            tPause += Time.deltaTime;           
            if(tPause >= pauseDuration)
            {
                if (placeInDialogue + 1 == _dialogues.sentences.Length)
                {
                    dialogueState = State.waitingForPlayerInput;
                    GM._UiManager.showNPCpanel();
                    dialogueBox.SetActive(false);
                    // or end conversation

                }
                else
                {
                    dialogueState = State.Writing;
                    placeInDialogue += 1;
                    StartCoroutine(writeText(_dialogues.sentences[placeInDialogue], dialogueTextBox, 0.03f));
                    tPause = 0;

                }
            }

        }


    }

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Global").GetComponent<GameManager>();//AsPrus: takie rozwiązania są baaardzo nieoptymalne: FindGameObjectWithTag przechodzi przez wszystkie GameObjecty na scenie, a do tego GetComponent też zajmuje strasznie dużo czasu procesorowi. Najlepiej mieć statyczny obiekt w GameManagerze wskazujący na obiekt na scenie (więcej w GameManager.cs)
    }

}
