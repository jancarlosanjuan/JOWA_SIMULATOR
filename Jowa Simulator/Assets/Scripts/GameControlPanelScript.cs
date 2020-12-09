using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlPanelScript : MonoBehaviour
{
    public GameObject GameControlPanel;
    public GameObject OptionsPanel;
    public GameObject StagesPanel;
    // Start is called before the first frame update
    public void OpenOptionsPanel()
    {
        OptionsPanel.SetActive(true);
        GameControlPanel.SetActive(false);
        StagesPanel.SetActive(false);
    }

    // Update is called once per frame
    public void OpenStagesPanel()
    {
        OptionsPanel.SetActive(false);
        GameControlPanel.SetActive(false);
        StagesPanel.SetActive(true);
    }
}
