using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleScript : MonoBehaviour
{
    //public ToggleGroup toggleGroup;
    public Text toggleText;
    public Toggle keqing;
    public Toggle qiqi;
    public Toggle mona;
    public Toggle diluc;
    Toggle activeToggle;
    string value;

    // Start is called before the first frame update
    void Start()
    {
        /*toggleGroup.GetComponent<ToggleGroup>();
        Debug.Log("Current Toggle Value : " + toggleGroup.ActiveToggles().FirstOrDefault());*/
    }

    // Update is called once per frame
    void Update()
    {
        /*activeToggle = toggleGroup.ActiveToggles().FirstOrDefault();
        toggleText.text = activeToggle.ToString();*/
        if (keqing.isOn)
            toggleText.text = "Keqing";
        else if (qiqi.isOn)
            toggleText.text = "Qiqi";
        else if (mona.isOn)
            toggleText.text = "Mona";
        else if (diluc.isOn)
            toggleText.text = "Diluc";
    }
}
