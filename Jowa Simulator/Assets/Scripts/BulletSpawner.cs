using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gamemanagerObject;
    private GameManager gamemanager;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject playerReference;
    //[SerializeField] private List<GameObject> bulletList;

    private Transform spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = gamemanagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnBullets()
    {
        GameObject spawn = Instantiate(bullet, playerReference.transform.position, Quaternion.identity);
        spawn.SetActive(true);
        gamemanager.bulletContainer.Add(spawn);
        
    }

    /*public List<GameObject> getBulletList()
    {
        return bulletList;
    }*/
}
