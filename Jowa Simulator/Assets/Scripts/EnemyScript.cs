using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    //place global singleton here
    [SerializeField] private GameObject gamemanagerObject;
    private GameManager gamemanager;

    //enemy type
    [SerializeField] private int health;
    [SerializeField] private float speed;
    [SerializeField] private int type; //0 = red, 1 = green, 2 = blue 
    [SerializeField] private int damage;

    //Enemy Sprites
    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private Transform spawnStart;

    //enemy specifics
    [SerializeField] private Transform transform;
    [SerializeField] private float angle;

    [SerializeField] private SpriteRenderer sr;


    private void Awake()
    {
        Start();

    }

    void Start()
    {
        gameObject.SetActive(true);
        gamemanager = gamemanagerObject.GetComponent<GameManager>();
        type = Random.Range(0, 3);

        switch (type)
        {
            //red
            case 0:
                health = 3;
                speed = 0.05f;
                damage = type + 1;
                break;
            //green
            case 1:
                health = 2;
                speed = 0.07f;
                damage = type + 1;
                break;
            //blue
            case 2:
                health = 1;
                speed = 0.1f;
                damage = type + 1;
                break;

        }

        //initialize sprites based on their type
        angle = Random.Range(0.0f, 360.0f);
        transform.rotation = Quaternion.Euler(transform.forward * angle);
        transform.position = spawnStart.position;
        sr.sprite = spriteList[type];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject);
            gamemanager.onEnemyDestroy();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (collision.gameObject.tag == "Bullet")
        {
            

            //check bullet type
            //if the same
            if(collision.gameObject.GetComponent<Bullet>().type == type)
            {
                GameObject bulletReference = collision.gameObject;
                health -= bulletReference.GetComponent<Bullet>().damage;
                Destroy(collision.gameObject);
                gamemanager.onBulletDestroy();
            }
            //if not the same type
            else
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }

        /*if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Debug.Log("Collided with Enemy!");
        }*/
    }
}
