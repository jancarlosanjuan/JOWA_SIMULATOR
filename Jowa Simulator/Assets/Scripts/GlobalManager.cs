using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    //SINGLETON DO NOT EDIT 
    private static GlobalManager _instance;
    public static GlobalManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GlobalManager>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GlobalManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;

        }
        else if (_instance != this)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    //variables here
    public int Currency = 0;

    public int DamageAdd = 0;
    public int HealthAdd = 0;
    public float SpeedMultiplier = 1.0f;
    public int Shields = 0;

    public int damagePrice = 5;
    public int healthPrice = 5;
    public int speedPrice = 5;
    public int shieldPrice = 15;
}
