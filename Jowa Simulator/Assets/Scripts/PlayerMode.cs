using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode : MonoBehaviour
{
    [SerializeField] private PlayerVariables playervar;
    [SerializeField] private int playerMode;
    [SerializeField] private float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerMode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            changeMode();
            playervar.type = playerMode;
        }
    }

    void changeMode()
    {
        playerMode++;
        if(playerMode > 2)
        {
            playerMode = 0;
        }
    }
}
