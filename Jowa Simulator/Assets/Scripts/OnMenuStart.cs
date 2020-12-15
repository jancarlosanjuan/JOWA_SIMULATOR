using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMenuStart : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        if (!GlobalAudio.Instance.isSoundPlaying())
        {
            GlobalAudio.Instance.playSound("MainOST", 0.5f);
            Debug.LogWarning("Is this working");
        }
        
    }

}
