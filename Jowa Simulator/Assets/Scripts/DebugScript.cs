using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugScript : MonoBehaviour
{
    public int addedCurrency;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFirstLevel()
    {
        Debug.Log("Loading Level 1...");
        SceneManager.LoadScene("GameMenu");
    }

    public void PlaySecondLevel()
    {
        Debug.Log("Loading Level 2...");
    }

    public void PlayThirdLevel()
    {
        Debug.Log("Loading Level 3...");
    }

    public void Notification()
    {
        Debug.Log("Loading Notification Settings...");
    }

    public void AddCurrency()
    {
        addedCurrency = 10000;
        GlobalManager.Instance.Currency += addedCurrency;
        Debug.Log("Currency: " + GlobalManager.Instance.Currency);
    }

    public void AddShield()
    {
        GlobalManager.Instance.Shields += 1;
        Debug.Log("Shield Power-ups Owned: " + GlobalManager.Instance.Shields);
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("ShopMenu");
    }
}
