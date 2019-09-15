using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    #region publicVariables

    [Header("Player Basic Statistics: ")]
    public int currentHealth;
    public int currentHunger;
    public int currentHydration;
    public int cash;

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
            currentHunger = currentHunger - Mathf.RoundToInt(hungerSpeed * Time.deltaTime);
        }
        else
        {
            currentHealth = currentHealth - Mathf.RoundToInt(hpLosingByHungerSpeed * Time.deltaTime);
        }
       
        if(currentHydration > 0)
        {
            currentHydration = currentHydration - Mathf.RoundToInt(hydrationSpeed * Time.deltaTime);
        }
        else
        {
            currentHealth = currentHealth - Mathf.RoundToInt(hpLosingByHydrationSpeed * Time.deltaTime);
        }

        hpText.text = currentHealth.ToString();
        hungerText.text = currentHunger.ToString();
        hydrationText.text = currentHydration.ToString();


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
