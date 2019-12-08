using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogues", menuName = "Dialogue")]

//AsPrus: dodaj [System.Serializable], aby klasa mogła być serializowana
public class dialogues : ScriptableObject
{  
    public string[] sentences;


}
