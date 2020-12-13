using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject GameManager;
    private GameManager gamemanager;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private GameObject playervar;
    //[SerializeField] private Transform transform;
    [SerializeField] private Transform midpoint;
    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private SpriteRenderer sr;

    //initialize these
    public int type;
    public float bulletspeed;
    public int damage;
    // Start is called before the first frame update

    private void Awake()
    {
        Start();
        gameObject.SetActive(true);
    }


    void Start()
    {
        
        type = playervar.GetComponent<PlayerVariables>().type;
        bulletspeed = playervar.GetComponent<PlayerVariables>().bulletSpeed;
        damage = playervar.GetComponent<PlayerVariables>().bulletDamage;

        sr.sprite = spriteList[type];

        Vector3 diff = midpoint.position - playerPosition.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * bulletspeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
   
    /*private void OnBecameInvisible()
    {
        //   GameManager.GetComponent<GameManager>().bulletContainer.Remove(this.gameObject);
        //    Destroy(this.gameObject);
        if (GameManager.GetComponent<GameManager>() != null && this.gameObject != null)
        {
            Debug.Log("Does this work");
            GameManager.GetComponent<GameManager>().destroyBullet(this.gameObject);
        }
        
    }*/
}
