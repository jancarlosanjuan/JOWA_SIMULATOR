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
    void Start()
    {
        //bulletDamage = 10;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void setMovementSpeed(float newspeed)
    {
        movementSpeed = newspeed;
    }

    public void setPlayerType(int newtype)
    {
        type = newtype;
        bulletDamage = 10;
    }

    
}
