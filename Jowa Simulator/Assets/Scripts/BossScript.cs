using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update

    //place global singleton here
    [SerializeField] private GameObject gamemanagerObject;
    private GameManager gamemanager;

    //Text
    [SerializeField] private GameObject _text;
    private ChangeText text;

    //enemy type
    [SerializeField] private int health = 1;
    [SerializeField] private float speed;
    [SerializeField] private int type; //0 = red, 1 = green, 2 = blue 
    [SerializeField] private int damage = 1;

    //Enemy Sprites
    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private Transform spawnStart;
    [SerializeField] private List<RuntimeAnimatorController> enemyAnimationList;

    //enemy specifics
    [SerializeField] private float angle;

    [SerializeField] private SpriteRenderer sr;

    private void Awake()
    {
        Start();
        gameObject.SetActive(true);
    }
    void Start()
    {
        health = 20;
        gamemanager = gamemanagerObject.GetComponent<GameManager>();
        text = _text.GetComponent<ChangeText>();
        type = Random.Range(0, 3);

        switch (type)
        {
            //red
            case 0:
                health = 10 + (gamemanager.waveNumber * 2);//
                speed = 0.05f + (float)gamemanager.waveNumber * 0.04f; //+(float)gamemanager.waveNumber * 0.2f
                damage = type;
                break;
            //green
            case 1:
                health = 8 + (gamemanager.waveNumber * 2);
                speed = 0.07f + (float)gamemanager.waveNumber * 0.04f;
                damage = type;
                break;
            //blue
            case 2:
                health = 5 + (gamemanager.waveNumber * 2);
                speed = 0.1f + (float)gamemanager.waveNumber * 0.04f;
                damage = type;
                break;

        }

        //initialize sprites based on their type
        angle = Random.Range(0.0f, 360.0f);
        transform.rotation = Quaternion.Euler(transform.forward * angle);
        transform.position = spawnStart.position;
        sr.sprite = spriteList[type];
        this.GetComponent<Animator>().runtimeAnimatorController = enemyAnimationList[type];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            Debug.Log("Collided with Boss");
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (collision.gameObject.tag == "Bullet")
        {
            //check bullet type
            //if the same
            if (collision.gameObject.GetComponent<Bullet>().type == type)
            {
                GameObject bulletReference = collision.gameObject;
                health -= bulletReference.GetComponent<Bullet>().damage;

                gamemanager.destroyBullet(collision.gameObject);

                if (health <= 0)
                {
                    //add some score here
                    int currency = GlobalManager.Instance.Currency + (gamemanager.waveNumber * 10);
                    GlobalManager.Instance.Currency = currency;
                    text.changeCurrencyText(currency);
                    gamemanager.destroyBoss(this.gameObject);
                }

            }
            //if not the same type
            else
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Debug.Log("Collided with Enemy!");
        }

    }
}
