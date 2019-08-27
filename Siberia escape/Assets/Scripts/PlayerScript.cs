using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    #region StaticVars
    public static PlayerScript THIS;

    #endregion

    #region InspectorVars
    [Header("Player Basic Settings: ")]
    [SerializeField] float _CurrentHealth;
    [SerializeField] float _MaxHealth;


    #endregion

    #region PublicVars
    public float CurrentHealth{ get { return _CurrentHealth; } }
    public string HealthString{ get { return _CurrentHealth + " / " + _MaxHealth; } }


    #endregion

    #region UnityMethods

    private void Awake()
    {
        THIS = this;
    }

    #endregion


}
