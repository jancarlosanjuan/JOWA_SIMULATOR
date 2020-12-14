using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject spriteExplosion; 
    public int waveNumber = 0;
    public bool paused;
    public List<GameObject> enemyContainer;
    public List<GameObject> bossContainer;
    public List<GameObject> bulletContainer;
    public List<GameObject> explosionContainer;
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
        for(int i = 0; i< explosionContainer.Count; i++)
        {
            if(explosionContainer[i].GetComponent<Animator>().GetBool("Exploded"))
            {
                //Debug.LogError("THIS WORKS");
                Destroy(explosionContainer[i].gameObject);
                explosionContainer.RemoveAt(i);
            }
        }
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
                //create explosion instance
                Transform _transform = enemyContainer[i].transform;
                GameObject explosion = Instantiate(spriteExplosion, _transform.position, Quaternion.identity);
                explosion.SetActive(true);
                explosionContainer.Add(explosion.gameObject);


                //enemyContainer.Remove(enemyContainer[i]);
                enemyContainer.RemoveAt(i);
                Destroy(enemytodestroy.gameObject);
            }
        }
    }

    public void destroyBoss(GameObject bosstodestroy)
    {
        for (int i = 0; i < bossContainer.Count; i++)
        {
            if (bossContainer[i] == bosstodestroy && bossContainer[i] != null && bosstodestroy != null)
            {
                //create explosion instance
                Transform _transform = bossContainer[i].transform;
                GameObject explosion = Instantiate(spriteExplosion, _transform.position, Quaternion.identity);
                explosion.SetActive(true);
                explosionContainer.Add(explosion.gameObject);


                //enemyContainer.Remove(enemyContainer[i]);
                bossContainer.RemoveAt(i);
                Destroy(bosstodestroy.gameObject);
            }
        }
    }
    public void destroyBullet(GameObject bullettodestroy)
    {
        for (int i = 0; i < bulletContainer.Count; i++)
        {
            if (bulletContainer[i] == bullettodestroy && bulletContainer[i] != null && bullettodestroy != null)
            {
                bulletContainer.RemoveAt(i);
                Destroy(bullettodestroy.gameObject);
            }
        }
    }
}
