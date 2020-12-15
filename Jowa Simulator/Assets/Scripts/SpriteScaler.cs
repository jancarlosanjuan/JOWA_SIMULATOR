using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScaler : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float height;
    [SerializeField] private float width;
    [SerializeField] private float multiplyerLandscape;
    [SerializeField] private float multiplyerPortrait;
    float valueChange;

    void Start()
    {
        //multiplyerPortrait = 1;
        //multiplyerLandscape = 1;
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;

        //landscape
        if (width > height)
        {
            this.gameObject.transform.localScale = new Vector3((height / width), (height / width), 0) * multiplyerLandscape;
        }
        //portrait
        else
        {
            this.gameObject.transform.localScale = new Vector3((width / height), (width / height), 0) * multiplyerPortrait;
        }
        valueChange = width;
    }

    // Update is called once per frame
    void Update()
    {
        valueChange = width;
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
       // Debug.Log("LANDSCAPE MODE");
        //landscape
        if (width != valueChange)
        {
            if (width > height)
            {
                Debug.Log("LANDSCAPE MODE");
                this.gameObject.transform.localScale = new Vector3((height / width), (height / width), 0) * multiplyerLandscape;//multiplyerLandscape
                //this.gameObject.transform.localScale = new Vector3(cam.aspect, cam.aspect, 0);
            }
            //portrait
            else
            {
                Debug.Log("Portrait MODE");
                this.gameObject.transform.localScale = new Vector3((width / height), (width / height), 0) * multiplyerPortrait;
            }
        }
        
    }
}
