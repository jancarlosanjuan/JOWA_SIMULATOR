using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    [SerializeField] private GameObject _healthText;
    private ChangeText healthText;
    [SerializeField] private GameObject _currencyText;
    private ChangeText currencyText;
//    [SerializeField] private GameObject _shieldText;
 //   private ChangeText shieldText;
    // Start is called before the first frame update

    //these are also upgradable;

    public float movementSpeed;
    public float bulletSpeed;
    public int health;
    public int currency;
    public int type;
    public int bulletDamage;
    public int numShields;
    public float bulletDirection;
    void Start()
    {
        bulletDamage = 10 + GlobalManager.Instance.DamageAdd;
        health = 10 + GlobalManager.Instance.HealthAdd;
        bulletSpeed = 1 * GlobalManager.Instance.SpeedMultiplier;
        currency = GlobalManager.Instance.Currency;
//        numShields = GlobalManager.Instance.Shields;

        healthText = _healthText.GetComponent<ChangeText>();
        healthText.changeCurrencyText(health);

        currencyText = _currencyText.GetComponent<ChangeText>();
        currencyText.changeCurrencyText(currency);

//        shieldText = _shieldText.GetComponent<ChangeText>();
 //       shieldText.changeCurrencyText(numShields);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            currency++;
            GlobalManager.Instance.Currency = currency;
            Debug.Log("CURRENCY IS: " + GlobalManager.Instance.Currency);
        }*/

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

    public void setBulletDirection(float angle)
    {
        bulletDirection = angle;
    }


}
