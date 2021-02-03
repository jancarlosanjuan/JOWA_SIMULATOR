using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class ShopScript : MonoBehaviour
{
    public Text currencyText;

    public Text weaponText;
    public Text healthText;
    public Text speedText;
    public Text shieldText;

    public Text weaponButtonText;
    public Text healthButtonText;
    public Text speedButtonText;
    public Text shieldButtonText;

    public AdsManager adsManager;

    // Start is called before the first frame update
    private void Start()
    {
        adsManager.OnAdDone += AdsManager_OnAdDone;
    }

    private void AdsManager_OnAdDone(object sender, AdFinishedEventArgs e)
    {
        if (e.PlacementID == AdsManager.RewardedAd)
        {
            switch (e.AdShowResult)
            {
                case ShowResult.Failed: Debug.Log("Ad failed"); break;
                case ShowResult.Skipped: Debug.Log("Ad was skipped"); break;
                case ShowResult.Finished:
                    Debug.Log("Ad finished! Rewarding free Jowa Shield!");
                    GlobalManager.Instance.Shields += 1;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = "Affection Points: " + GlobalManager.Instance.Currency;
        weaponText.text = "Weapon Damage: " + (10 + GlobalManager.Instance.DamageAdd);
        healthText.text = "Max Health: " + (10 + GlobalManager.Instance.HealthAdd);
        speedText.text = "Player Speed Multiplier: " + GlobalManager.Instance.SpeedMultiplier;
        shieldText.text = "Currently Owned: " + GlobalManager.Instance.Shields;

        weaponButtonText.text = GlobalManager.Instance.damagePrice.ToString();
        healthButtonText.text = GlobalManager.Instance.healthPrice.ToString();
        speedButtonText.text = GlobalManager.Instance.speedPrice.ToString();
        shieldButtonText.text = GlobalManager.Instance.shieldPrice.ToString();

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
            GlobalManager.Instance.Currency -= GlobalManager.Instance.damagePrice;
            GlobalManager.Instance.DamageAdd += 5;
            GlobalManager.Instance.damagePrice += 5;
            GlobalAudio.Instance.playSound("ButtonClick", 1f);
        }
    }

    public void UpgradeHealth()
    {
        if (GlobalManager.Instance.Currency > 0)
        {
            Debug.Log("Health enhanced!");
            GlobalManager.Instance.Currency -= GlobalManager.Instance.healthPrice;
            GlobalManager.Instance.HealthAdd += 5;
            GlobalManager.Instance.healthPrice += 5;
            GlobalAudio.Instance.playSound("ButtonClick", 1f);
        }
    }

    public void UpgradeSpeed()
    {
        if (GlobalManager.Instance.Currency > 0)
        {
            Debug.Log("Movement speed enhanced!");
            GlobalManager.Instance.Currency -= GlobalManager.Instance.speedPrice;
            GlobalManager.Instance.SpeedMultiplier += 0.3f;
            GlobalManager.Instance.speedPrice += 5;
            GlobalAudio.Instance.playSound("ButtonClick", 1f);
        }
    }

    public void BuyShield()
    {
        if (GlobalManager.Instance.Currency > 0)
        {
            Debug.Log("Shield Bought!");
            GlobalManager.Instance.Currency -= GlobalManager.Instance.shieldPrice;
            GlobalManager.Instance.Shields += 1;
            GlobalManager.Instance.shieldPrice += 10;
            GlobalAudio.Instance.playSound("ButtonClick", 1f);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameMenu");
        GlobalAudio.Instance.playSound("ChangeScene", 1f);
    }
}
