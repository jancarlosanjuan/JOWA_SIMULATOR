using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    public Text sliderText;
    string value;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        value = slider.value.ToString();
        Debug.Log("Slider Value : " + slider.value);
        sliderText.text = value;
    }
}
