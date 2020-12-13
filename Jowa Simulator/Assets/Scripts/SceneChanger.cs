using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string SceneName;

    public void onButtonClicked()
    {
        SceneManager.LoadScene(SceneName);
    }
}
