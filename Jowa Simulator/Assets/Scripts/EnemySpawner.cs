using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject gamemanagerObject;
    private GameManager gamemanager;
    private GameObject spawn;
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
     //   counterText.changeCurrencyText(waveNumber+1);
    }

    // Update is called once per frame
    void Update()
    {
        
        waveNumber = gamemanager.waveNumber;
        int store = gamemanager.enemyContainer.Count;

        int bossStore = gamemanager.bossContainer.Count;

        if (store == 0 && bossStore == 0)
        {
            gamemanager.waveNumber++;
            counterText.changeCurrencyText(gamemanager.waveNumber);
            Debug.Log("WAVE : " + gamemanager.waveNumber);

            if (gamemanager.waveNumber % 5 == 0)
            {
                Debug.Log("Boss Wave!");
                for (int i = 0; i < 1; i++)
                {
                    spawn = Instantiate(bossPrefab, spawnLocation.position, Quaternion.identity);
                    spawn.SetActive(true);
                    gamemanager.bossContainer.Add(spawn);
                }
            }
            else
            {
                for (int i = 0; i < waveNumber + 10; i++)
                {
                    spawn = Instantiate(prefab, spawnLocation.position, Quaternion.identity);
                    spawn.SetActive(true);
                    gamemanager.enemyContainer.Add(spawn);
                }
            }
        }
    }
}
