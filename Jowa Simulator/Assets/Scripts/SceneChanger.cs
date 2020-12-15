using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string SceneName;

    public void onButtonClicked()
    {
        GlobalAudio.Instance.playSound("ChangeScene", 1f);
        SceneManager.LoadScene(SceneName);
    }
}
