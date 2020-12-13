using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int waveNumber = 0;
    public bool paused;
    public List<GameObject> enemyContainer;
    public List<GameObject> bulletContainer;
    public int enemyCount;

    private void Awake()
    {
        waveNumber = 0;
        paused = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //onBulletDestroy();
        //onEnemyDestroy();

        /*if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < enemyContainer.Count; i++)
            {
                Destroy(enemyContainer[i]);
            }
            enemyContainer.Clear();
        }*/
    }

    public int getEnemyCount()
    {
        return enemyContainer.Count;
    }

    public void destroyEnemy(GameObject enemytodestroy)
    {
        for(int i = 0; i<enemyContainer.Count; i++)
        {
            if(enemyContainer[i] == enemytodestroy && enemyContainer[i] != null && enemytodestroy != null)
            {
                enemyContainer.Remove(enemyContainer[i]);
                Destroy(enemytodestroy.gameObject);
            }
        }
    }

    public void destroyBullet(GameObject bullettodestroy)
    {
        for (int i = 0; i < bulletContainer.Count; i++)
        {
            if (bulletContainer[i] == bullettodestroy && bulletContainer[i] != null && bullettodestroy != null)
            {
                bulletContainer.Remove(bulletContainer[i]);
                Destroy(bullettodestroy.gameObject);
            }
        }
    }
}
