using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    public Text currencyText;
    public Text shieldText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = "Affection Points: " + GlobalManager.Instance.Currency;
        shieldText.text = "Currently Owned: " + GlobalManager.Instance.Shields;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpgradeWeapon()
    {
        Debug.Log("Weapon enhanced!");
        //insert weapon enhance script
    }

    public void UpgradeHealth()
    {
        Debug.Log("Health enhanced!");
        //insert health enhance script
    }

    public void UpgradeSpeed()
    {
        Debug.Log("Movement speed enhanced!");
        //insert movement speed enhance script
    }

    public void BuyShield()
    {
        Debug.Log("Shield Bought!");
        GlobalManager.Instance.Currency -= 500;
        GlobalManager.Instance.Shields += 1;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
