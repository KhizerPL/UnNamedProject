using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    #region publicVariables

    [Header("Player Basic Statistics: ")]
    public int currentHealth;
    public int maxHealth;
    public int hydration;
    public int hunger;
    public int cash;

    #endregion

    public GameObject itemPrefab;

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(itemPrefab, new Vector3(transform.position.x, transform.position.y + 15, transform.position.z), Quaternion.identity);
        }



    }








}
