using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsManager : MonoBehaviour
{
    public Transform[] itemsPrefabs;


    public void spawnItem(int id, Vector3 position, Quaternion rotation)
    {
        Instantiate(itemsPrefabs[id], position, rotation);
    }

}
