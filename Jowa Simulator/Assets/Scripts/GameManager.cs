using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int waveNumber;
    public bool paused;
    public List<GameObject> enemyContainer;
    public List<GameObject> bulletContainer;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 0;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        onBulletDestroy();
        onEnemyDestroy();

        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < enemyContainer.Count; i++)
            {
                Destroy(enemyContainer[i]);
            }
            enemyContainer.Clear();
        }
    }

    public int getEnemyCount()
    {
        return enemyContainer.Count;
    }

    public void onEnemyDestroy()
    {
        for(int i = 0; i<enemyContainer.Count; i++)
        {
            if(enemyContainer[i] == null)
            {
                enemyContainer.Remove(enemyContainer[i]);
            }
        }
    }

    public void onBulletDestroy()
    {
        for (int i = 0; i < bulletContainer.Count; i++)
        {
            if (bulletContainer[i] == null)
            {
                bulletContainer.Remove(bulletContainer[i]);
            }
        }
    }
}
