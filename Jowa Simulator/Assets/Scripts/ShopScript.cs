using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    public Text currencyText;
    public Text weaponText;
    public Text healthText;
    public Text speedText;
    public Text shieldText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = "Affection Points: " + GlobalManager.Instance.Currency;
        weaponText.text = "Weapon Damage: " + (10 + GlobalManager.Instance.DamageAdd);
        healthText.text = "Max Health: " + (10 + GlobalManager.Instance.HealthAdd);
        speedText.text = "Player Speed Multiplier: " + GlobalManager.Instance.SpeedMultiplier;
        shieldText.text = "Currently Owned: " + GlobalManager.Instance.Shields;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpgradeWeapon()
    {
        if (GlobalManager.Instance.Currency > 0)
        {
            Debug.Log("Weapon enhanced!");
            GlobalManager.Instance.Currency -= 500;
            GlobalManager.Instance.DamageAdd += 5;
        }
    }

    public void UpgradeHealth()
    {
        if (GlobalManager.Instance.Currency > 0)
        {
            Debug.Log("Health enhanced!");
            GlobalManager.Instance.Currency -= 500;
            GlobalManager.Instance.HealthAdd += 5;
        }
    }

    public void UpgradeSpeed()
    {
        if (GlobalManager.Instance.Currency > 0)
        {
            Debug.Log("Movement speed enhanced!");
            GlobalManager.Instance.Currency -= 500;
            GlobalManager.Instance.SpeedMultiplier += 0.3f;
        }
    }

    public void BuyShield()
    {
        if(GlobalManager.Instance.Currency > 0)
        {
            Debug.Log("Shield Bought!");
            GlobalManager.Instance.Currency -= 500;
            GlobalManager.Instance.Shields += 1;
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
