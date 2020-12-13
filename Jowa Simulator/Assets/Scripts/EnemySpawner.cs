﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject gamemanagerObject;
    private GameManager gamemanager;
    [SerializeField] private int waveNumber;

    //spawn location
    [SerializeField] private Transform spawnLocation; 
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = gamemanagerObject.GetComponent<GameManager>();
        waveNumber = gamemanager.waveNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
        waveNumber = gamemanager.waveNumber;
        int store = gamemanager.enemyContainer.Count;
        
        if (store == 0)
        {
            gamemanager.waveNumber++;
            
            Debug.Log("WAVE : " + gamemanager.waveNumber);
            
            
            for(int i = 0; i<waveNumber + 10; i++)
            {
                GameObject spawn = Instantiate(prefab, spawnLocation.position, Quaternion.identity);
                spawn.SetActive(true);
                gamemanager.enemyContainer.Add(spawn);
            }
            

        }
        
        
    }
}
