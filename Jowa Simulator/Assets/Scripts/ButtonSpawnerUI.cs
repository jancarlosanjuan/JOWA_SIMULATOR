using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawnerUI : MonoBehaviour
{
    public GameObject prefabButton;
    public RectTransform ParentPanel;

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < 100; i++)
        {
            GameObject newButton = (GameObject)Instantiate(prefabButton);
            newButton.transform.SetParent(ParentPanel, false);
            newButton.transform.localScale = new Vector3(1, 1, 1);

            int buttonNumber = i + 1;
            newButton.GetComponentInChildren<Text>().text = buttonNumber.ToString();
        }
    }
}
