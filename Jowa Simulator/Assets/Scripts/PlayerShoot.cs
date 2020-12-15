using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    //this class is to instantiate bullets
    [SerializeField] private GameObject bulletContainer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //bulletContainer.GetComponent<BulletSpawner>().spawnBullets();
            //shootBullet();
        }
    }

    public void shootBullet()
    {
        this.gameObject.GetComponent<Animator>().SetBool("isAttacking", true);
       // this.gameObject.GetComponent<Animator>().loo
        bulletContainer.GetComponent<BulletSpawner>().spawnBullets();
        GlobalAudio.Instance.playSound("Shoot", 1);
    }
}
