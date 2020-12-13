using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject DebugPanel;
    // Start is called before the first frame update
    public void LoadGameScene()
    {
        Debug.Log("Loading Game Menu...");
        SceneManager.LoadScene("GameMenu");
    }

    public void LoadDebugPanel()
    {
        DebugPanel.SetActive(!DebugPanel.activeSelf);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
    }

}
