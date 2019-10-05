using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    #region publicVariables

    [Header("Player Basic Statistics: ")]
    public float currentHealth;
    public float currentHunger;
    public float currentHydration;
    public int cash;
    public float playerHeat = 100;

    #endregion

    [SerializeField] float hungerSpeed;
    [SerializeField] float hydrationSpeed;
    [SerializeField] float hpLosingByHungerSpeed;
    [SerializeField] float hpLosingByHydrationSpeed;

    [SerializeField] Text hpText;
    [SerializeField] Text hungerText;
    [SerializeField] Text hydrationText;


    [SerializeField] public GameObject itemPrefab;





    void needsUpdate()
    {
        if (currentHunger > 0)
        {         
            currentHunger -= hungerSpeed * Time.deltaTime;
        }
        else
        {
            currentHealth -= hpLosingByHungerSpeed * Time.deltaTime;
        }
       
        if(currentHydration > 0)
        {
            currentHydration -= hydrationSpeed * Time.deltaTime;
        }
        else
        {
            currentHealth -= hpLosingByHydrationSpeed * Time.deltaTime;
        }

        hpText.text = Mathf.RoundToInt(currentHealth).ToString();
        hungerText.text = Mathf.RoundToInt(currentHunger).ToString();
        hydrationText.text = Mathf.RoundToInt(currentHydration).ToString();


    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(itemPrefab, new Vector3(transform.position.x, transform.position.y + 15, transform.position.z), Quaternion.identity);
        }

        needsUpdate();

        



    }








}
