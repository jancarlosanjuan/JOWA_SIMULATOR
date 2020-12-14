using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject gamemanagerObject;
    private GameManager gamemanager;
    [SerializeField] private int waveNumber;

    //wave counter text UI
    [SerializeField] private GameObject _counterText;
    private ChangeText counterText;

    //spawn location
    [SerializeField] private Transform spawnLocation; 
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = gamemanagerObject.GetComponent<GameManager>();
        waveNumber = gamemanager.waveNumber;

        counterText = _counterText.GetComponent<ChangeText>();
        counterText.changeCurrencyText(waveNumber);
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
            counterText.changeCurrencyText(gamemanager.waveNumber);

            for (int i = 0; i<waveNumber + 10; i++)
            {
                GameObject spawn = Instantiate(prefab, spawnLocation.position, Quaternion.identity);
                spawn.SetActive(true);
                gamemanager.enemyContainer.Add(spawn);
            }
            

        }
        
        
    }
}
