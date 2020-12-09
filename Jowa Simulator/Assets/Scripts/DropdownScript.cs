using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour
{
    public Dropdown dropdown;
    public Text dropdownText;
    int menuIndex;
    string value;

    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        Debug.Log("Starting Dropdown Value : " + menuIndex);
    }
    void Update()
    {
        menuIndex = dropdown.value;
        Debug.Log(menuIndex);
        value = dropdown.options[menuIndex].text;
        Debug.Log(value);
        dropdownText.text = value;
    }
}
