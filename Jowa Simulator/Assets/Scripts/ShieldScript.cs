﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private GameManager gamemanager;
    [SerializeField] private GameObject gamemanagerObject;

    [SerializeField] private GameObject _shieldText;
    private ChangeText shieldText;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = gamemanagerObject.GetComponent<GameManager>();
        AccelerometerScript.Instance.OnShake += Begone;
        shieldText = _shieldText.GetComponent<ChangeText>();
        shieldText.changeCurrencyText(GlobalManager.Instance.Shields);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Begone();
        }
    }

    private void OnDestroy()
    {
        AccelerometerScript.Instance.OnShake -= Begone;
    }

    public void Begone()
    {
        if(GlobalManager.Instance.Shields > 0)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < gameObjects.Length; i++)
            {
                /*gamemanager.enemyContainer.Remove(gameObjects[i]);
                Destroy(gameObjects[i]);*/
                gamemanager.destroyEnemy(gameObjects[i]);
            }
            GlobalManager.Instance.Shields--;
            shieldText.changeCurrencyText(GlobalManager.Instance.Shields);
            Debug.Log("Enemies: " + gamemanager.enemyContainer.Count);
        }
    }

}
