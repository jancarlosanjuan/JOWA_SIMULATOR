using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsPanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMainMenuScene()
    {
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene("MainMenu");
    }
}
