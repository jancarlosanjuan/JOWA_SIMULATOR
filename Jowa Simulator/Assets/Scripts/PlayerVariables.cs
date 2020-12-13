using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{

    // Start is called before the first frame update

    //these are also upgradable;

    public float movementSpeed;
    public float bulletSpeed;
    public int health;
    public int currency;
    public int type;
    public int bulletDamage;
    public int numShields;
    void Start()
    {
        //bulletDamage = 10;
        currency = GlobalManager.Instance.Currency;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currency++;
            GlobalManager.Instance.Currency = currency;
            Debug.Log("CURRENCY IS: " + GlobalManager.Instance.Currency);
        }

    }
    public void setHealth(int newhealth)
    {
        health = newhealth;
    }

    public void setBulletDamage(int damage)
    {
        bulletDamage = damage;
    }
    public void setMovementSpeed(float newspeed)
    {
        movementSpeed = newspeed;
    }

    public void setPlayerType(int newtype)
    {
        type = newtype;
        bulletDamage = 10;
        bulletSpeed = 0.2f;
    }

    
}
